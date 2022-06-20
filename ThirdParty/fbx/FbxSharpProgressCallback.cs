
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

internal abstract class FbxSharpProgressCallback : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal FbxSharpProgressCallback(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(FbxSharpProgressCallback obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~FbxSharpProgressCallback() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          NativeMethods.delete_FbxSharpProgressCallback(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
    }
  }

  public FbxSharpProgressCallback() : this(NativeMethods.new_FbxSharpProgressCallback(), true) {
    SwigDirectorConnect();
  }

  public virtual bool Progress(float percentage, string status) {
    bool ret = NativeMethods.FbxSharpProgressCallback_Progress(swigCPtr, percentage, status);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
    return ret;
  }

  internal class Wrapper : FbxSharpProgressCallback {
    Globals.FbxProgressCallback m_callback;
    internal Wrapper (Globals.FbxProgressCallback callback) {
      m_callback = callback;
    }
    public override bool Progress(float percentage, string status) {
      return m_callback(percentage, status);
    }
  }

  private void SwigDirectorConnect() {
    if (SwigDerivedClassHasMethod("Progress", swigMethodTypes0))
      swigDelegate0 = new SwigDelegateFbxSharpProgressCallback_0(SwigDirectorProgress);
    NativeMethods.FbxSharpProgressCallback_director_connect(swigCPtr, swigDelegate0);
  }

  private bool SwigDerivedClassHasMethod(string methodName, global::System.Type[] methodTypes) {
    global::System.Reflection.MethodInfo methodInfo = this.GetType().GetMethod(methodName, global::System.Reflection.BindingFlags.Public | global::System.Reflection.BindingFlags.NonPublic | global::System.Reflection.BindingFlags.Instance, null, methodTypes, null);
    bool hasDerivedMethod = methodInfo.DeclaringType.IsSubclassOf(typeof(FbxSharpProgressCallback));
    return hasDerivedMethod;
  }

  private bool SwigDirectorProgress(float percentage, string status) {
    return Progress(percentage, status);
  }

  public delegate bool SwigDelegateFbxSharpProgressCallback_0(float percentage, string status);

  private SwigDelegateFbxSharpProgressCallback_0 swigDelegate0;

  private static global::System.Type[] swigMethodTypes0 = new global::System.Type[] { typeof(float), typeof(string) };
}

}

