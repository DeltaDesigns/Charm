
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

public class FbxPropertyEAreaLightShape : FbxProperty {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;

  internal FbxPropertyEAreaLightShape(global::System.IntPtr cPtr, bool cMemoryOwn) : base(NativeMethods.FbxPropertyEAreaLightShape_SWIGUpcast(cPtr), cMemoryOwn) {
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(FbxPropertyEAreaLightShape obj) {
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

  public FbxPropertyEAreaLightShape Set(FbxLight.EAreaLightShape pValue) {
    FbxPropertyEAreaLightShape ret = new FbxPropertyEAreaLightShape(NativeMethods.FbxPropertyEAreaLightShape_Set(swigCPtr, (int)pValue), false);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
    return ret;
  }

  public FbxLight.EAreaLightShape Get() {
    FbxLight.EAreaLightShape ret = (FbxLight.EAreaLightShape)NativeMethods.FbxPropertyEAreaLightShape_Get(swigCPtr);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
    return ret;
  }

  public FbxLight.EAreaLightShape EvaluateValue(FbxTime pTime, bool pForceEval) {
    FbxLight.EAreaLightShape ret = (FbxLight.EAreaLightShape)NativeMethods.FbxPropertyEAreaLightShape_EvaluateValue__SWIG_0(swigCPtr, FbxTime.getCPtr(pTime), pForceEval);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
    return ret;
  }

  public FbxLight.EAreaLightShape EvaluateValue(FbxTime pTime) {
    FbxLight.EAreaLightShape ret = (FbxLight.EAreaLightShape)NativeMethods.FbxPropertyEAreaLightShape_EvaluateValue__SWIG_1(swigCPtr, FbxTime.getCPtr(pTime));
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
    return ret;
  }

  public FbxLight.EAreaLightShape EvaluateValue() {
    FbxLight.EAreaLightShape ret = (FbxLight.EAreaLightShape)NativeMethods.FbxPropertyEAreaLightShape_EvaluateValue__SWIG_2(swigCPtr);
    if (NativeMethods.SWIGPendingException.Pending) throw NativeMethods.SWIGPendingException.Retrieve();
    return ret;
  }

}

}

