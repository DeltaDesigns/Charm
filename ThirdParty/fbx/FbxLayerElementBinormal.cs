
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

public class FbxLayerElementBinormal : FbxLayerElementTemplateFbxVector4 {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;

  internal FbxLayerElementBinormal(global::System.IntPtr cPtr, bool cMemoryOwn) : base(NativeMethods.FbxLayerElementBinormal_SWIGUpcast(cPtr), cMemoryOwn) {
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(FbxLayerElementBinormal obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  public override void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          throw new global::System.MethodAccessException("C++ destructor does not have public access");
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
      base.Dispose();
    }
  }

  public static FbxLayerElementBinormal Create(FbxLayerContainer pOwner, string pName) {
    global::System.IntPtr cPtr = NativeMethods.FbxLayerElementBinormal_Create(FbxLayerContainer.getCPtr(pOwner), pName);
    FbxLayerElementBinormal ret = (cPtr == global::System.IntPtr.Zero) ? null : new FbxLayerElementBinormal(cPtr, false);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
    return ret;
  }

}

}

