
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

public class FbxDataType : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal FbxDataType(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(FbxDataType obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~FbxDataType() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          NativeMethods.delete_FbxDataType(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
    }
  }

  public FbxDataType() : this(NativeMethods.new_FbxDataType__SWIG_0(), true) {
  }

  public FbxDataType(FbxDataType pDataType) : this(NativeMethods.new_FbxDataType__SWIG_1(FbxDataType.getCPtr(pDataType)), true) {
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
  }

  private bool _equals(FbxDataType pDataType) {
    bool ret = NativeMethods.FbxDataType__equals(swigCPtr, FbxDataType.getCPtr(pDataType));
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
    return ret;
  }

  public bool Valid() {
    bool ret = NativeMethods.FbxDataType_Valid(swigCPtr);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
    return ret;
  }

  public bool Is(FbxDataType pDataType) {
    bool ret = NativeMethods.FbxDataType_Is(swigCPtr, FbxDataType.getCPtr(pDataType));
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
    return ret;
  }

  public EFbxType ToEnum() {
    EFbxType ret = (EFbxType)NativeMethods.FbxDataType_ToEnum(swigCPtr);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
    return ret;
  }

  public string GetName() {
    string ret = NativeMethods.FbxDataType_GetName(swigCPtr);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
    return ret;
  }

  public FbxDataType(string pName, EFbxType pType) : this(NativeMethods.new_FbxDataType__SWIG_2(pName, (int)pType), true) {
  }

  public FbxDataType(string pName, FbxDataType pDataType) : this(NativeMethods.new_FbxDataType__SWIG_3(pName, FbxDataType.getCPtr(pDataType)), true) {
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
  }

  public FbxDataType(EFbxType pType) : this(NativeMethods.new_FbxDataType__SWIG_4((int)pType), true) {
  }

  public bool Equals(FbxDataType other) {
    if (object.ReferenceEquals(other, null)) { return false; }
    return _equals(other);
  }

  public override bool Equals(object obj){
    if (object.ReferenceEquals(obj, null)) { return false; }
    /* is obj a subclass of this type; if so use our Equals */
    var typed = obj as FbxDataType;
    if (!object.ReferenceEquals(typed, null)) {
      return this.Equals(typed);
    }
    /* are we a subclass of the other type; if so use their Equals */
    if (typeof(FbxDataType).IsSubclassOf(obj.GetType())) {
      return obj.Equals(this);
    }
    /* types are unrelated; can't be a match */
    return false;
  }

  public static bool operator == (FbxDataType a, FbxDataType b) {
    if (object.ReferenceEquals(a, b)) { return true; }
    if (object.ReferenceEquals(a, null) || object.ReferenceEquals(b, null)) { return false; }
    return a.Equals(b);
  }

  public static bool operator != (FbxDataType a, FbxDataType b) {
    return !(a == b);
  }

  public override int GetHashCode() { return GetName().GetHashCode(); }

  public string GetNameForIO() {
    string ret = NativeMethods.FbxDataType_GetNameForIO(swigCPtr);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
    return ret;
  }

  public override string ToString() {
    return GetName();
  } 
}

}

