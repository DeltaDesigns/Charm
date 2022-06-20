
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

public class FbxSkeleton : FbxNodeAttribute {
  internal FbxSkeleton(global::System.IntPtr cPtr, bool ignored) : base(cPtr, ignored) { }

  // override void Dispose() {base.Dispose();}

  public new static FbxSkeleton Create(FbxManager pManager, string pName) {
    global::System.IntPtr cPtr = NativeMethods.FbxSkeleton_Create__SWIG_0(FbxManager.getCPtr(pManager), pName);
    FbxSkeleton ret = (cPtr == global::System.IntPtr.Zero) ? null : new FbxSkeleton(cPtr, false);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
    return ret;
  }

  public new static FbxSkeleton Create(FbxObject pContainer, string pName) {
    global::System.IntPtr cPtr = NativeMethods.FbxSkeleton_Create__SWIG_1(FbxObject.getCPtr(pContainer), pName);
    FbxSkeleton ret = (cPtr == global::System.IntPtr.Zero) ? null : new FbxSkeleton(cPtr, false);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
    return ret;
  }

  public void Reset() {
    NativeMethods.FbxSkeleton_Reset(swigCPtr);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
  }

  public void SetSkeletonType(FbxSkeleton.EType pSkeletonType) {
    NativeMethods.FbxSkeleton_SetSkeletonType(swigCPtr, (int)pSkeletonType);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
  }

  public FbxSkeleton.EType GetSkeletonType() {
    FbxSkeleton.EType ret = (FbxSkeleton.EType)NativeMethods.FbxSkeleton_GetSkeletonType(swigCPtr);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
    return ret;
  }

  public bool GetSkeletonTypeIsSet() {
    bool ret = NativeMethods.FbxSkeleton_GetSkeletonTypeIsSet(swigCPtr);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
    return ret;
  }

  public FbxSkeleton.EType GetSkeletonTypeDefaultValue() {
    FbxSkeleton.EType ret = (FbxSkeleton.EType)NativeMethods.FbxSkeleton_GetSkeletonTypeDefaultValue(swigCPtr);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
    return ret;
  }

  public double GetLimbLengthDefaultValue() {
    double ret = NativeMethods.FbxSkeleton_GetLimbLengthDefaultValue(swigCPtr);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
    return ret;
  }

  public double GetLimbNodeSizeDefaultValue() {
    double ret = NativeMethods.FbxSkeleton_GetLimbNodeSizeDefaultValue(swigCPtr);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
    return ret;
  }

  public bool SetLimbNodeColor(FbxColor pColor) {
    bool ret = NativeMethods.FbxSkeleton_SetLimbNodeColor(swigCPtr, pColor);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
    return ret;
  }

  public FbxColor GetLimbNodeColor() {
    var ret = NativeMethods.FbxSkeleton_GetLimbNodeColor(swigCPtr);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
    return ret;
  }

  public bool GetLimbNodeColorIsSet() {
    bool ret = NativeMethods.FbxSkeleton_GetLimbNodeColorIsSet(swigCPtr);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
    return ret;
  }

  public FbxColor GetLimbNodeColorDefaultValue() {
    var ret = NativeMethods.FbxSkeleton_GetLimbNodeColorDefaultValue(swigCPtr);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
    return ret;
  }

  public bool IsSkeletonRoot() {
    bool ret = NativeMethods.FbxSkeleton_IsSkeletonRoot(swigCPtr);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
    return ret;
  }

  public static string sSize {
    get {
      string ret = NativeMethods.FbxSkeleton_sSize_get();
      return ret;
    } 
  }

  public static string sLimbLength {
    get {
      string ret = NativeMethods.FbxSkeleton_sLimbLength_get();
      return ret;
    } 
  }

  public static double sDefaultSize {
    get {
      double ret = NativeMethods.FbxSkeleton_sDefaultSize_get();
      return ret;
    } 
  }

  public static double sDefaultLimbLength {
    get {
      double ret = NativeMethods.FbxSkeleton_sDefaultLimbLength_get();
      return ret;
    } 
  }

  public FbxPropertyDouble Size {
    get {
      FbxPropertyDouble ret = new FbxPropertyDouble(NativeMethods.FbxSkeleton_Size_get(swigCPtr), false);
      if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
      return ret;
    } 
  }

  public FbxPropertyDouble LimbLength {
    get {
      FbxPropertyDouble ret = new FbxPropertyDouble(NativeMethods.FbxSkeleton_LimbLength_get(swigCPtr), false);
      if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
      return ret;
    } 
  }

  public override int GetHashCode(){
      return swigCPtr.Handle.GetHashCode();
  }

  public bool Equals(FbxSkeleton other) {
    if (object.ReferenceEquals(other, null)) { return false; }
    return this.swigCPtr.Handle.Equals (other.swigCPtr.Handle);
  }

  public override bool Equals(object obj){
    if (object.ReferenceEquals(obj, null)) { return false; }
    /* is obj a subclass of this type; if so use our Equals */
    var typed = obj as FbxSkeleton;
    if (!object.ReferenceEquals(typed, null)) {
      return this.Equals(typed);
    }
    /* are we a subclass of the other type; if so use their Equals */
    if (typeof(FbxSkeleton).IsSubclassOf(obj.GetType())) {
      return obj.Equals(this);
    }
    /* types are unrelated; can't be a match */
    return false;
  }

  public static bool operator == (FbxSkeleton a, FbxSkeleton b) {
    if (object.ReferenceEquals(a, b)) { return true; }
    if (object.ReferenceEquals(a, null) || object.ReferenceEquals(b, null)) { return false; }
    return a.Equals(b);
  }

  public static bool operator != (FbxSkeleton a, FbxSkeleton b) {
    return !(a == b);
  }

  public new enum EType {
    eRoot,
    eLimb,
    eLimbNode,
    eEffector
  }

}

}

