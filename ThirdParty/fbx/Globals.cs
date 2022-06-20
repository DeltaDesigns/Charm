
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

public class Globals {
  public static void SetControlPoints(FbxGeometryBase mesh, System.IntPtr f) {
    NativeMethods.SetControlPoints(FbxGeometryBase.getCPtr(mesh), f);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
  }

  public static void GetControlPoints(FbxGeometryBase mesh, System.IntPtr f) {
    NativeMethods.GetControlPoints(FbxGeometryBase.getCPtr(mesh), f);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
  }

  public static void CopyVector3ToFbxVector4(FbxLayerElementArrayTemplateFbxVector4 layerElement, System.IntPtr f) {
    NativeMethods.CopyVector3ToFbxVector4(FbxLayerElementArrayTemplateFbxVector4.getCPtr(layerElement), f);
  }

  public static void CopyColorToFbxColor(FbxLayerElementArrayTemplateFbxColor layerElement, System.IntPtr f) {
    NativeMethods.CopyColorToFbxColor(FbxLayerElementArrayTemplateFbxColor.getCPtr(layerElement), f);
  }

  public static void CopyVector4ToFbxVector4(FbxLayerElementArrayTemplateFbxVector4 layerElement, System.IntPtr f) {
    NativeMethods.CopyVector4ToFbxVector4(FbxLayerElementArrayTemplateFbxVector4.getCPtr(layerElement), f);
  }

  public static void CopyVector2ToFbxVector2(FbxLayerElementArrayTemplateFbxVector2 layerElement, System.IntPtr f) {
    NativeMethods.CopyVector2ToFbxVector2(FbxLayerElementArrayTemplateFbxVector2.getCPtr(layerElement), f);
  }

  public static void CopyFbxVector2ToVector2(FbxLayerElementArrayTemplateFbxVector2 layerElement, System.IntPtr f) {
    NativeMethods.CopyFbxVector2ToVector2(FbxLayerElementArrayTemplateFbxVector2.getCPtr(layerElement), f);
  }

  public static void CopyFbxVector4ToVector3(FbxLayerElementArrayTemplateFbxVector4 layerElement, System.IntPtr f) {
    NativeMethods.CopyFbxVector4ToVector3(FbxLayerElementArrayTemplateFbxVector4.getCPtr(layerElement), f);
  }

  public static FbxDataType FbxUndefinedDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxUndefinedDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxBoolDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxBoolDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxCharDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxCharDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxUCharDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxUCharDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxShortDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxShortDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxUShortDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxUShortDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxIntDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxIntDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxUIntDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxUIntDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxLongLongDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxLongLongDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxULongLongDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxULongLongDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxFloatDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxFloatDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxHalfFloatDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxHalfFloatDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxDoubleDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxDoubleDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxDouble2DT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxDouble2DT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxDouble3DT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxDouble3DT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxDouble4DT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxDouble4DT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxDouble4x4DT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxDouble4x4DT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxEnumDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxEnumDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxStringDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxStringDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxTimeDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxTimeDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxReferenceDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxReferenceDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxBlobDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxBlobDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxDistanceDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxDistanceDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxDateTimeDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxDateTimeDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxColor3DT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxColor3DT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxColor4DT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxColor4DT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxCompoundDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxCompoundDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxReferenceObjectDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxReferenceObjectDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxReferencePropertyDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxReferencePropertyDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxVisibilityDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxVisibilityDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxVisibilityInheritanceDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxVisibilityInheritanceDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxUrlDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxUrlDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxXRefUrlDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxXRefUrlDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxTranslationDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxTranslationDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxRotationDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxRotationDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxScalingDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxScalingDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxQuaternionDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxQuaternionDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxLocalTranslationDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxLocalTranslationDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxLocalRotationDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxLocalRotationDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxLocalScalingDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxLocalScalingDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxLocalQuaternionDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxLocalQuaternionDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxTransformMatrixDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxTransformMatrixDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxTranslationMatrixDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxTranslationMatrixDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxRotationMatrixDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxRotationMatrixDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxScalingMatrixDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxScalingMatrixDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxMaterialEmissiveDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxMaterialEmissiveDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxMaterialEmissiveFactorDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxMaterialEmissiveFactorDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxMaterialAmbientDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxMaterialAmbientDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxMaterialAmbientFactorDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxMaterialAmbientFactorDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxMaterialDiffuseDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxMaterialDiffuseDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxMaterialDiffuseFactorDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxMaterialDiffuseFactorDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxMaterialBumpDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxMaterialBumpDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxMaterialNormalMapDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxMaterialNormalMapDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxMaterialTransparentColorDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxMaterialTransparentColorDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxMaterialTransparencyFactorDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxMaterialTransparencyFactorDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxMaterialSpecularDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxMaterialSpecularDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxMaterialSpecularFactorDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxMaterialSpecularFactorDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxMaterialShininessDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxMaterialShininessDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxMaterialReflectionDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxMaterialReflectionDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxMaterialReflectionFactorDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxMaterialReflectionFactorDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxMaterialDisplacementDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxMaterialDisplacementDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxMaterialVectorDisplacementDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxMaterialVectorDisplacementDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxMaterialCommonFactorDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxMaterialCommonFactorDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxMaterialCommonTextureDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxMaterialCommonTextureDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxLayerElementUndefinedDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxLayerElementUndefinedDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxLayerElementNormalDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxLayerElementNormalDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxLayerElementBinormalDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxLayerElementBinormalDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxLayerElementTangentDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxLayerElementTangentDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxLayerElementMaterialDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxLayerElementMaterialDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxLayerElementTextureDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxLayerElementTextureDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxLayerElementPolygonGroupDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxLayerElementPolygonGroupDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxLayerElementUVDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxLayerElementUVDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxLayerElementVertexColorDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxLayerElementVertexColorDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxLayerElementSmoothingDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxLayerElementSmoothingDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxLayerElementCreaseDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxLayerElementCreaseDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxLayerElementHoleDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxLayerElementHoleDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxLayerElementUserDataDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxLayerElementUserDataDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxLayerElementVisibilityDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxLayerElementVisibilityDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxAliasDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxAliasDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxPresetsDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxPresetsDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxStatisticsDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxStatisticsDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxTextLineDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxTextLineDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxUnitsDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxUnitsDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxWarningDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxWarningDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxWebDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxWebDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxActionDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxActionDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxCameraIndexDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxCameraIndexDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxCharPtrDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxCharPtrDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxConeAngleDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxConeAngleDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxEventDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxEventDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxFieldOfViewDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxFieldOfViewDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxFieldOfViewXDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxFieldOfViewXDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxFieldOfViewYDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxFieldOfViewYDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxFogDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxFogDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxHSBDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxHSBDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxIKReachTranslationDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxIKReachTranslationDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxIKReachRotationDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxIKReachRotationDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxIntensityDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxIntensityDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxLookAtDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxLookAtDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxOcclusionDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxOcclusionDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxOpticalCenterXDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxOpticalCenterXDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxOpticalCenterYDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxOpticalCenterYDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxOrientationDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxOrientationDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxRealDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxRealDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxRollDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxRollDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxScalingUVDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxScalingUVDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxShapeDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxShapeDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxStringListDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxStringListDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxTextureRotationDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxTextureRotationDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxTimeCodeDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxTimeCodeDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxTimeWarpDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxTimeWarpDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxTranslationUVDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxTranslationUVDT_get(), false);
      return ret;
    } 
  }

  public static FbxDataType FbxWeightDT {
    get {
      FbxDataType ret = new FbxDataType(NativeMethods.FbxWeightDT_get(), false);
      return ret;
    } 
  }

  internal static bool IsValidColor(FbxColor c) {
    bool ret = NativeMethods.IsValidColor(c);
    return ret;
  }


  public delegate bool FbxProgressCallback(float percentage, string status);

  public static readonly int FBXSDK_PROPERTY_ID_NULL = NativeMethods.FBXSDK_PROPERTY_ID_NULL_get();
  public static readonly int FBXSDK_PROPERTY_ID_ROOT = NativeMethods.FBXSDK_PROPERTY_ID_ROOT_get();
  public static readonly string IOSROOT = NativeMethods.IOSROOT_get();
  public static readonly string IMP_FBX_GLOBAL_SETTINGS = NativeMethods.IMP_FBX_GLOBAL_SETTINGS_get();
  public static readonly string IMP_FBX_MATERIAL = NativeMethods.IMP_FBX_MATERIAL_get();
  public static readonly string IMP_FBX_TEXTURE = NativeMethods.IMP_FBX_TEXTURE_get();
  public static readonly string IMP_FBX_ANIMATION = NativeMethods.IMP_FBX_ANIMATION_get();
  public static readonly string IMP_FBX_EXTRACT_EMBEDDED_DATA = NativeMethods.IMP_FBX_EXTRACT_EMBEDDED_DATA_get();
  public static readonly string EXP_FBX_GLOBAL_SETTINGS = NativeMethods.EXP_FBX_GLOBAL_SETTINGS_get();
  public static readonly string EXP_FBX_MATERIAL = NativeMethods.EXP_FBX_MATERIAL_get();
  public static readonly string EXP_FBX_TEXTURE = NativeMethods.EXP_FBX_TEXTURE_get();
  public static readonly string EXP_FBX_ANIMATION = NativeMethods.EXP_FBX_ANIMATION_get();
  public static readonly string EXP_FBX_EMBEDDED = NativeMethods.EXP_FBX_EMBEDDED_get();
  public static readonly string FBXSDK_SHADING_LANGUAGE_HLSL = NativeMethods.FBXSDK_SHADING_LANGUAGE_HLSL_get();
  public static readonly string FBXSDK_SHADING_LANGUAGE_GLSL = NativeMethods.FBXSDK_SHADING_LANGUAGE_GLSL_get();
  public static readonly string FBXSDK_SHADING_LANGUAGE_CGFX = NativeMethods.FBXSDK_SHADING_LANGUAGE_CGFX_get();
  public static readonly string FBXSDK_SHADING_LANGUAGE_SFX = NativeMethods.FBXSDK_SHADING_LANGUAGE_SFX_get();
  public static readonly string FBXSDK_SHADING_LANGUAGE_MRSL = NativeMethods.FBXSDK_SHADING_LANGUAGE_MRSL_get();
  public static readonly string FBXSDK_RENDERING_API_DIRECTX = NativeMethods.FBXSDK_RENDERING_API_DIRECTX_get();
  public static readonly string FBXSDK_RENDERING_API_OPENGL = NativeMethods.FBXSDK_RENDERING_API_OPENGL_get();
  public static readonly string FBXSDK_RENDERING_API_MENTALRAY = NativeMethods.FBXSDK_RENDERING_API_MENTALRAY_get();
  public static readonly string FBXSDK_RENDERING_API_PREVIEW = NativeMethods.FBXSDK_RENDERING_API_PREVIEW_get();
  public static readonly string FBXSDK_CURVENODE_TRANSFORM = NativeMethods.FBXSDK_CURVENODE_TRANSFORM_get();
  public static readonly string FBXSDK_CURVENODE_TRANSLATION = NativeMethods.FBXSDK_CURVENODE_TRANSLATION_get();
  public static readonly string FBXSDK_CURVENODE_ROTATION = NativeMethods.FBXSDK_CURVENODE_ROTATION_get();
  public static readonly string FBXSDK_CURVENODE_SCALING = NativeMethods.FBXSDK_CURVENODE_SCALING_get();
  public static readonly string FBXSDK_CURVENODE_COMPONENT_X = NativeMethods.FBXSDK_CURVENODE_COMPONENT_X_get();
  public static readonly string FBXSDK_CURVENODE_COMPONENT_Y = NativeMethods.FBXSDK_CURVENODE_COMPONENT_Y_get();
  public static readonly string FBXSDK_CURVENODE_COMPONENT_Z = NativeMethods.FBXSDK_CURVENODE_COMPONENT_Z_get();
  public static readonly string FBXSDK_CURVENODE_COLOR = NativeMethods.FBXSDK_CURVENODE_COLOR_get();
  public static readonly string FBXSDK_CURVENODE_COLOR_RED = NativeMethods.FBXSDK_CURVENODE_COLOR_RED_get();
  public static readonly string FBXSDK_CURVENODE_COLOR_GREEN = NativeMethods.FBXSDK_CURVENODE_COLOR_GREEN_get();
  public static readonly string FBXSDK_CURVENODE_COLOR_BLUE = NativeMethods.FBXSDK_CURVENODE_COLOR_BLUE_get();
  public static readonly string FBXSDK_CAMERA_PERSPECTIVE = NativeMethods.FBXSDK_CAMERA_PERSPECTIVE_get();
  public static readonly int FBX_NO_SECTION = NativeMethods.FBX_NO_SECTION_get();
  public static readonly int FBX_MAIN_SECTION = NativeMethods.FBX_MAIN_SECTION_get();
  public static readonly int FBX_EXTENSION_SECTION_0 = NativeMethods.FBX_EXTENSION_SECTION_0_get();

}

}

