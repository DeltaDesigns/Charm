
//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (http://www.swig.org).
// Version 3.0.12
//
// Do not make changes to this file unless you know what you are doing--modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------

namespace Autodesk.Fbx {

public class FbxMesh : FbxGeometry {
  internal FbxMesh(global::System.IntPtr cPtr, bool ignored) : base(cPtr, ignored) { }

  // override void Dispose() {base.Dispose();}

  public new static FbxMesh Create(FbxManager pManager, string pName) {
    global::System.IntPtr cPtr = NativeMethods.FbxMesh_Create__SWIG_0(FbxManager.getCPtr(pManager), pName);
    FbxMesh ret = (cPtr == global::System.IntPtr.Zero) ? null : new FbxMesh(cPtr, false);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
    return ret;
  }

  public new static FbxMesh Create(FbxObject pContainer, string pName) {
    global::System.IntPtr cPtr = NativeMethods.FbxMesh_Create__SWIG_1(FbxObject.getCPtr(pContainer), pName);
    FbxMesh ret = (cPtr == global::System.IntPtr.Zero) ? null : new FbxMesh(cPtr, false);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
    return ret;
  }

  private void BeginPolygonUnchecked(int pMaterial, int pTexture, int pGroup, bool pLegacy) {
    NativeMethods.FbxMesh_BeginPolygonUnchecked(swigCPtr, pMaterial, pTexture, pGroup, pLegacy);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
  }

  private void AddPolygonUnchecked(int pIndex, int pTextureUVIndex) {
    NativeMethods.FbxMesh_AddPolygonUnchecked(swigCPtr, pIndex, pTextureUVIndex);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
  }

  private void EndPolygonUnchecked() {
    NativeMethods.FbxMesh_EndPolygonUnchecked(swigCPtr);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
  }

  public int GetPolygonCount() {
    int ret = NativeMethods.FbxMesh_GetPolygonCount(swigCPtr);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
    return ret;
  }

  public int GetPolygonSize(int pPolygonIndex) {
    int ret = NativeMethods.FbxMesh_GetPolygonSize(swigCPtr, pPolygonIndex);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
    return ret;
  }

  public int GetPolygonVertex(int pPolygonIndex, int pPositionInPolygon) {
    int ret = NativeMethods.FbxMesh_GetPolygonVertex(swigCPtr, pPolygonIndex, pPositionInPolygon);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
    return ret;
  }

  public bool GetPolygonVertexNormal(int pPolyIndex, int pVertexIndex, out FbxVector4 pNormal) {
    bool ret = NativeMethods.FbxMesh_GetPolygonVertexNormal(swigCPtr, pPolyIndex, pVertexIndex, out pNormal);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
    return ret;
  }

  public int GetPolygonVertexCount() {
    int ret = NativeMethods.FbxMesh_GetPolygonVertexCount(swigCPtr);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
    return ret;
  }

  public bool SplitPoints(FbxLayerElement.EType pTypeIdentifier) {
    bool ret = NativeMethods.FbxMesh_SplitPoints__SWIG_0(swigCPtr, (int)pTypeIdentifier);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
    return ret;
  }

  public bool SplitPoints() {
    bool ret = NativeMethods.FbxMesh_SplitPoints__SWIG_1(swigCPtr);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
    return ret;
  }

  public override int GetHashCode(){
      return swigCPtr.Handle.GetHashCode();
  }

  public bool Equals(FbxMesh other) {
    if (object.ReferenceEquals(other, null)) { return false; }
    return this.swigCPtr.Handle.Equals (other.swigCPtr.Handle);
  }

  public override bool Equals(object obj){
    if (object.ReferenceEquals(obj, null)) { return false; }
    /* is obj a subclass of this type; if so use our Equals */
    var typed = obj as FbxMesh;
    if (!object.ReferenceEquals(typed, null)) {
      return this.Equals(typed);
    }
    /* are we a subclass of the other type; if so use their Equals */
    if (typeof(FbxMesh).IsSubclassOf(obj.GetType())) {
      return obj.Equals(this);
    }
    /* types are unrelated; can't be a match */
    return false;
  }

  public static bool operator == (FbxMesh a, FbxMesh b) {
    if (object.ReferenceEquals(a, b)) { return true; }
    if (object.ReferenceEquals(a, null) || object.ReferenceEquals(b, null)) { return false; }
    return a.Equals(b);
  }

  public static bool operator != (FbxMesh a, FbxMesh b) {
    return !(a == b);
  }

  [System.SerializableAttribute]
  public class BadBracketingException : System.NotSupportedException {
    public    BadBracketingException() : base() { }
    public    BadBracketingException(string message, System.Exception innerException) : base("Improper bracketing of Begin/Add/EndPolygon: " + message, innerException) { }
    public    BadBracketingException(string message) : base("Improper bracketing of Begin/Add/EndPolygon: " + message) { }
    protected BadBracketingException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
  }

  bool m_isAddingPolygon = false;

  public void BeginPolygon(int pMaterial=-1, int pTexture=-1, int pGroup=-1, bool pLegacy=true) {
    if (m_isAddingPolygon) { throw new BadBracketingException("BeginPolygon while already building a polygon"); }
    BeginPolygonUnchecked(pMaterial, pTexture, pGroup, pLegacy);
    m_isAddingPolygon = true;
  } 
  public void AddPolygon(int pIndex, int pTextureUVIndex = -1) {
    if (!m_isAddingPolygon) { throw new BadBracketingException("AddPolygon without matching BeginPolygon"); }
    if (pIndex < 0) { throw new System.ArgumentOutOfRangeException("pIndex"); }
    AddPolygonUnchecked(pIndex, pTextureUVIndex);
  } 
  public void EndPolygon() {
    if (!m_isAddingPolygon) { throw new BadBracketingException("EndPolygon without matching BeginPolygon"); }
    m_isAddingPolygon = false;
    EndPolygonUnchecked();
  } 
}

}

