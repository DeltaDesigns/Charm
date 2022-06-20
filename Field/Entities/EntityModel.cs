﻿using Field.General;
using Field.Models;

namespace Field.Entities;

public class EntityModel : Tag
{
    public D2Class_076F8080 Header;
    
    public EntityModel(TagHash hash) : base(hash)
    {
    }

    protected override void ParseStructs()
    {
        Header = ReadHeader<D2Class_076F8080>();
    }

    public List<DynamicPart> Load(ELOD detailLevel)
    {
        List<D2Class_CB6E8080> dynamicParts = GetPartsOfDetailLevel(detailLevel);
        List<DynamicPart> parts = GenerateParts(dynamicParts);
        return parts;
    }
    
    private List<D2Class_CB6E8080> GetPartsOfDetailLevel(ELOD detailLevel)
    {
        List<D2Class_CB6E8080> parts = new List<D2Class_CB6E8080>();
        HashSet<sbyte> details = new HashSet<sbyte>();
        foreach (D2Class_CB6E8080 part in Header.Meshes[0].Parts)
        {
            details.Add((sbyte)part.DetailLevel);
        }

        if (details.Count == 0) return new List<D2Class_CB6E8080>();
        sbyte minDetailLevel = details.Min();
        sbyte maxDetailLevel = details.Max();
        
        if (detailLevel == ELOD.MostDetail)
        {
            foreach (D2Class_CB6E8080 part in Header.Meshes[0].Parts)
            {
                if ((sbyte)part.DetailLevel == minDetailLevel)
                {
                    parts.Add(part);
                }
            }
        }
        else if (detailLevel == ELOD.LeastDetail)
        {
            foreach (D2Class_CB6E8080 part in Header.Meshes[0].Parts)
            {
                if ((sbyte)part.DetailLevel == maxDetailLevel)
                {
                    parts.Add(part);
                }
            }
        }
        else
        {
            foreach (D2Class_CB6E8080 part in Header.Meshes[0].Parts)
            {
                parts.Add(part);
            }
        }
        
        return parts;
    }
    
    private List<DynamicPart> GenerateParts(List<D2Class_CB6E8080> dynamicParts)
    {
        List<DynamicPart> parts = new List<DynamicPart>();
        if (Header.Meshes.Count > 1) throw new Exception("Multiple meshes not supported");
        if (Header.Meshes.Count == 0) return new List<DynamicPart>();
        D2Class_C56E8080 mesh = Header.Meshes[0];
        foreach (D2Class_CB6E8080 part in dynamicParts)
        {
            DynamicPart dynamicPart = new DynamicPart(part);
            dynamicPart.GetAllData(mesh, Header);
            parts.Add(dynamicPart);
        }
        return parts;
    }

}

public class DynamicPart : Part
{
    public List<Vector4> VertexWeights = new List<Vector4>();

    public DynamicPart(D2Class_CB6E8080 part) : base()
    {
        IndexOffset = part.IndexOffset;
        IndexCount = part.IndexCount;
        PrimitiveType = (EPrimitiveType)part.PrimitiveType;
    }
    
    public DynamicPart() : base()
    {
    }

    public void GetAllData(D2Class_C56E8080 mesh, D2Class_076F8080 model)
    {
        Indices = mesh.Indices.Buffer.ParseBuffer(PrimitiveType, IndexOffset, IndexCount);
        // Get unique vertex indices we need to get data for
        HashSet<uint> uniqueVertexIndices = new HashSet<uint>();
        foreach (UIntVector3 index in Indices)
        {
            uniqueVertexIndices.Add(index.X);
            uniqueVertexIndices.Add(index.Y);
            uniqueVertexIndices.Add(index.Z);
        }
        VertexIndices = uniqueVertexIndices.ToList();
        // Have to call it like this b/c we don't know the format of the vertex data here
        mesh.Vertices1.Buffer.ParseBuffer(this, uniqueVertexIndices);
        mesh.Vertices2.Buffer.ParseBuffer(this, uniqueVertexIndices);

        TransformPositions(model);
        TransformUVs(model);
    }
    
    private void TransformUVs(D2Class_076F8080 header)
    {
        for (int i = 0; i < VertexUVs.Count; i++)
        {
            VertexUVs[i] = new Vector2(
                VertexUVs[i].X * header.UVScale.X + header.UVTranslation.X,
                VertexUVs[i].Y * -header.UVScale.Y + 1 - header.UVTranslation.Y
            );
        }
    }

    private void TransformPositions(D2Class_076F8080 header)
    {
        for (int i = 0; i < VertexPositions.Count; i++)
        {
            VertexPositions[i] = new Vector4(
                VertexPositions[i].X * header.ModelScale.X + header.ModelTranslation.X,
                VertexPositions[i].Y * header.ModelScale.Y + header.ModelTranslation.Y,
                VertexPositions[i].Z * header.ModelScale.Z + header.ModelTranslation.Z,
                VertexPositions[i].W
            );
        }
    }
}