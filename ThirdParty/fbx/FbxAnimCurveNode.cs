
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

public class FbxAnimCurveNode : FbxObject {
  internal FbxAnimCurveNode(global::System.IntPtr cPtr, bool ignored) : base(cPtr, ignored) { }

  // override void Dispose() {base.Dispose();}

  public new static FbxAnimCurveNode Create(FbxManager pManager, string pName) {
    global::System.IntPtr cPtr = NativeMethods.FbxAnimCurveNode_Create__SWIG_0(FbxManager.getCPtr(pManager), pName);
    FbxAnimCurveNode ret = (cPtr == global::System.IntPtr.Zero) ? null : new FbxAnimCurveNode(cPtr, false);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
    return ret;
  }

  public new static FbxAnimCurveNode Create(FbxObject pContainer, string pName) {
    global::System.IntPtr cPtr = NativeMethods.FbxAnimCurveNode_Create__SWIG_1(FbxObject.getCPtr(pContainer), pName);
    FbxAnimCurveNode ret = (cPtr == global::System.IntPtr.Zero) ? null : new FbxAnimCurveNode(cPtr, false);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
    return ret;
  }

  public bool IsAnimated(bool pRecurse) {
    bool ret = NativeMethods.FbxAnimCurveNode_IsAnimated__SWIG_0(swigCPtr, pRecurse);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
    return ret;
  }

  public bool IsAnimated() {
    bool ret = NativeMethods.FbxAnimCurveNode_IsAnimated__SWIG_1(swigCPtr);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
    return ret;
  }

  public bool GetAnimationInterval(FbxTimeSpan pTimeInterval) {
    bool ret = NativeMethods.FbxAnimCurveNode_GetAnimationInterval(swigCPtr, FbxTimeSpan.getCPtr(pTimeInterval));
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
    return ret;
  }

  public bool IsComposite() {
    bool ret = NativeMethods.FbxAnimCurveNode_IsComposite(swigCPtr);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
    return ret;
  }

  public static FbxAnimCurveNode CreateTypedCurveNode(FbxProperty pProperty, FbxScene pScene) {
    global::System.IntPtr cPtr = NativeMethods.FbxAnimCurveNode_CreateTypedCurveNode(FbxProperty.getCPtr(pProperty), FbxScene.getCPtr(pScene));
    FbxAnimCurveNode ret = (cPtr == global::System.IntPtr.Zero) ? null : new FbxAnimCurveNode(cPtr, false);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
    return ret;
  }

  public uint GetChannelsCount() {
    uint ret = NativeMethods.FbxAnimCurveNode_GetChannelsCount(swigCPtr);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
    return ret;
  }

  public int GetChannelIndex(string pChannelName) {
    int ret = NativeMethods.FbxAnimCurveNode_GetChannelIndex(swigCPtr, pChannelName);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
    return ret;
  }

  public string GetChannelName(int pChannelId) {
    string ret = NativeMethods.FbxAnimCurveNode_GetChannelName(swigCPtr, pChannelId);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
    return ret;
  }

  public FbxAnimCurve CreateCurve(string pCurveNodeName, string pChannel) {
    global::System.IntPtr cPtr = NativeMethods.FbxAnimCurveNode_CreateCurve__SWIG_0(swigCPtr, pCurveNodeName, pChannel);
    FbxAnimCurve ret = (cPtr == global::System.IntPtr.Zero) ? null : new FbxAnimCurve(cPtr, false);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
    return ret;
  }

  public FbxAnimCurve CreateCurve(string pCurveNodeName, uint pChannelId) {
    global::System.IntPtr cPtr = NativeMethods.FbxAnimCurveNode_CreateCurve__SWIG_1(swigCPtr, pCurveNodeName, pChannelId);
    FbxAnimCurve ret = (cPtr == global::System.IntPtr.Zero) ? null : new FbxAnimCurve(cPtr, false);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
    return ret;
  }

  public FbxAnimCurve CreateCurve(string pCurveNodeName) {
    global::System.IntPtr cPtr = NativeMethods.FbxAnimCurveNode_CreateCurve__SWIG_2(swigCPtr, pCurveNodeName);
    FbxAnimCurve ret = (cPtr == global::System.IntPtr.Zero) ? null : new FbxAnimCurve(cPtr, false);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
    return ret;
  }

  public int GetCurveCount(uint pChannelId, string pCurveNodeName) {
    int ret = NativeMethods.FbxAnimCurveNode_GetCurveCount__SWIG_0(swigCPtr, pChannelId, pCurveNodeName);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
    return ret;
  }

  public int GetCurveCount(uint pChannelId) {
    int ret = NativeMethods.FbxAnimCurveNode_GetCurveCount__SWIG_1(swigCPtr, pChannelId);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
    return ret;
  }

  public FbxAnimCurve GetCurve(uint pChannelId, uint pId, string pCurveNodeName) {
    global::System.IntPtr cPtr = NativeMethods.FbxAnimCurveNode_GetCurve__SWIG_0(swigCPtr, pChannelId, pId, pCurveNodeName);
    FbxAnimCurve ret = (cPtr == global::System.IntPtr.Zero) ? null : new FbxAnimCurve(cPtr, false);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
    return ret;
  }

  public FbxAnimCurve GetCurve(uint pChannelId, uint pId) {
    global::System.IntPtr cPtr = NativeMethods.FbxAnimCurveNode_GetCurve__SWIG_1(swigCPtr, pChannelId, pId);
    FbxAnimCurve ret = (cPtr == global::System.IntPtr.Zero) ? null : new FbxAnimCurve(cPtr, false);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
    return ret;
  }

  public FbxAnimCurve GetCurve(uint pChannelId) {
    global::System.IntPtr cPtr = NativeMethods.FbxAnimCurveNode_GetCurve__SWIG_2(swigCPtr, pChannelId);
    FbxAnimCurve ret = (cPtr == global::System.IntPtr.Zero) ? null : new FbxAnimCurve(cPtr, false);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
    return ret;
  }

  public override int GetHashCode(){
      return swigCPtr.Handle.GetHashCode();
  }

  public bool Equals(FbxAnimCurveNode other) {
    if (object.ReferenceEquals(other, null)) { return false; }
    return this.swigCPtr.Handle.Equals (other.swigCPtr.Handle);
  }

  public override bool Equals(object obj){
    if (object.ReferenceEquals(obj, null)) { return false; }
    /* is obj a subclass of this type; if so use our Equals */
    var typed = obj as FbxAnimCurveNode;
    if (!object.ReferenceEquals(typed, null)) {
      return this.Equals(typed);
    }
    /* are we a subclass of the other type; if so use their Equals */
    if (typeof(FbxAnimCurveNode).IsSubclassOf(obj.GetType())) {
      return obj.Equals(this);
    }
    /* types are unrelated; can't be a match */
    return false;
  }

  public static bool operator == (FbxAnimCurveNode a, FbxAnimCurveNode b) {
    if (object.ReferenceEquals(a, b)) { return true; }
    if (object.ReferenceEquals(a, null) || object.ReferenceEquals(b, null)) { return false; }
    return a.Equals(b);
  }

  public static bool operator != (FbxAnimCurveNode a, FbxAnimCurveNode b) {
    return !(a == b);
  }

  public bool AddChannel(string pChnlName, float pValue) {
    bool ret = NativeMethods.FbxAnimCurveNode_AddChannel(swigCPtr, pChnlName, pValue);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
    return ret;
  }

  public void SetChannelValue(string pChnlName, float pValue) {
    NativeMethods.FbxAnimCurveNode_SetChannelValue__SWIG_2(swigCPtr, pChnlName, pValue);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
  }

  public void SetChannelValue(uint pChnlId, float pValue) {
    NativeMethods.FbxAnimCurveNode_SetChannelValue__SWIG_3(swigCPtr, pChnlId, pValue);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
  }

  public float GetChannelValue(string pChnlName, float pInitVal) {
    float ret = NativeMethods.FbxAnimCurveNode_GetChannelValue__SWIG_2(swigCPtr, pChnlName, pInitVal);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
    return ret;
  }

  public float GetChannelValue(uint pChnlId, float pInitVal) {
    float ret = NativeMethods.FbxAnimCurveNode_GetChannelValue__SWIG_3(swigCPtr, pChnlId, pInitVal);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
    return ret;
  }

}

}

