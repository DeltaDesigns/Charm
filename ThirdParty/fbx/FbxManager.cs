
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

public class FbxManager : System.IDisposable, System.IEquatable<FbxManager> {
  protected global::System.Runtime.InteropServices.HandleRef swigCPtr { get ; private set; }

  internal FbxManager(global::System.IntPtr cPtr, bool ignored) {
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }
  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(FbxManager obj) {
    return ((object)obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  public virtual void Dispose() {
    Dispose(true);
    global::System.GC.SuppressFinalize(this);
  }
  ~FbxManager() {
    Dispose(false);
  }
  protected void Dispose(bool disposing) {
    if (swigCPtr.Handle != global::System.IntPtr.Zero) {
      if (disposing) {
        Destroy();
      }
      lock(this) {
        NativeMethods.ReleaseWeakPointerHandle(swigCPtr);
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
    }
  }

  public static FbxManager Create() {
    global::System.IntPtr cPtr = NativeMethods.FbxManager_Create();
    FbxManager ret = (cPtr == global::System.IntPtr.Zero) ? null : new FbxManager(cPtr, false);
    return ret;
  }

  public virtual void Destroy() {
    NativeMethods.FbxManager_Destroy(swigCPtr);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
  }

  public static string GetVersion(bool pFull) {
    string ret = NativeMethods.FbxManager_GetVersion__SWIG_0(pFull);
    return ret;
  }

  public static string GetVersion() {
    string ret = NativeMethods.FbxManager_GetVersion__SWIG_1();
    return ret;
  }

  public static void GetFileFormatVersion(out int pMajor, out int pMinor, out int pRevision) {
    NativeMethods.FbxManager_GetFileFormatVersion(out pMajor, out pMinor, out pRevision);
  }

  public virtual FbxIOSettings GetIOSettings() {
    global::System.IntPtr cPtr = NativeMethods.FbxManager_GetIOSettings(swigCPtr);
    FbxIOSettings ret = (cPtr == global::System.IntPtr.Zero) ? null : new FbxIOSettings(cPtr, false);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual void SetIOSettings(FbxIOSettings pIOSettings) {
    NativeMethods.FbxManager_SetIOSettings(swigCPtr, FbxIOSettings.getCPtr(pIOSettings));
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
  }

  public FbxIOPluginRegistry GetIOPluginRegistry() {
    global::System.IntPtr cPtr = NativeMethods.FbxManager_GetIOPluginRegistry(swigCPtr);
    FbxIOPluginRegistry ret = (cPtr == global::System.IntPtr.Zero) ? null : new FbxIOPluginRegistry(cPtr, false);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
    return ret;
  }

  public override int GetHashCode(){
      return swigCPtr.Handle.GetHashCode();
  }

  public bool Equals(FbxManager other) {
    if (object.ReferenceEquals(other, null)) { return false; }
    return this.swigCPtr.Handle.Equals (other.swigCPtr.Handle);
  }

  public override bool Equals(object obj){
    if (object.ReferenceEquals(obj, null)) { return false; }
    /* is obj a subclass of this type; if so use our Equals */
    var typed = obj as FbxManager;
    if (!object.ReferenceEquals(typed, null)) {
      return this.Equals(typed);
    }
    /* are we a subclass of the other type; if so use their Equals */
    if (typeof(FbxManager).IsSubclassOf(obj.GetType())) {
      return obj.Equals(this);
    }
    /* types are unrelated; can't be a match */
    return false;
  }

  public static bool operator == (FbxManager a, FbxManager b) {
    if (object.ReferenceEquals(a, b)) { return true; }
    if (object.ReferenceEquals(a, null) || object.ReferenceEquals(b, null)) { return false; }
    return a.Equals(b);
  }

  public static bool operator != (FbxManager a, FbxManager b) {
    return !(a == b);
  }

}

}

