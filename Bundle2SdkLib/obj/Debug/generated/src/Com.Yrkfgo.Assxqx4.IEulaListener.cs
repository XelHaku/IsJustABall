using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Yrkfgo.Assxqx4 {

	// Metadata.xml XPath interface reference: path="/api/package[@name='com.yrkfgo.assxqx4']/interface[@name='EulaListener']"
	[Register ("com/yrkfgo/assxqx4/EulaListener", "", "Com.Yrkfgo.Assxqx4.IEulaListenerInvoker")]
	public partial interface IEulaListener : IJavaObject {

		// Metadata.xml XPath method reference: path="/api/package[@name='com.yrkfgo.assxqx4']/interface[@name='EulaListener']/method[@name='optinResult' and count(parameter)=1 and parameter[1][@type='boolean']]"
		[Register ("optinResult", "(Z)V", "GetOptinResult_ZHandler:Com.Yrkfgo.Assxqx4.IEulaListenerInvoker, BundleSdkLib")]
		void OptinResult (bool p0);

		// Metadata.xml XPath method reference: path="/api/package[@name='com.yrkfgo.assxqx4']/interface[@name='EulaListener']/method[@name='showingEula' and count(parameter)=0]"
		[Register ("showingEula", "()V", "GetShowingEulaHandler:Com.Yrkfgo.Assxqx4.IEulaListenerInvoker, BundleSdkLib")]
		void ShowingEula ();

	}

	[global::Android.Runtime.Register ("com/yrkfgo/assxqx4/EulaListener", DoNotGenerateAcw=true)]
	internal class IEulaListenerInvoker : global::Java.Lang.Object, IEulaListener {

		static IntPtr java_class_ref = JNIEnv.FindClass ("com/yrkfgo/assxqx4/EulaListener");
		IntPtr class_ref;

		public static IEulaListener GetObject (IntPtr handle, JniHandleOwnership transfer)
		{
			return global::Java.Lang.Object.GetObject<IEulaListener> (handle, transfer);
		}

		static IntPtr Validate (IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf (handle, java_class_ref))
				throw new InvalidCastException (string.Format ("Unable to convert instance of type '{0}' to type '{1}'.",
							JNIEnv.GetClassNameFromInstance (handle), "com.yrkfgo.assxqx4.EulaListener"));
			return handle;
		}

		protected override void Dispose (bool disposing)
		{
			if (this.class_ref != IntPtr.Zero)
				JNIEnv.DeleteGlobalRef (this.class_ref);
			this.class_ref = IntPtr.Zero;
			base.Dispose (disposing);
		}

		public IEulaListenerInvoker (IntPtr handle, JniHandleOwnership transfer) : base (Validate (handle), transfer)
		{
			IntPtr local_ref = JNIEnv.GetObjectClass (Handle);
			this.class_ref = JNIEnv.NewGlobalRef (local_ref);
			JNIEnv.DeleteLocalRef (local_ref);
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (IEulaListenerInvoker); }
		}

		static Delegate cb_optinResult_Z;
#pragma warning disable 0169
		static Delegate GetOptinResult_ZHandler ()
		{
			if (cb_optinResult_Z == null)
				cb_optinResult_Z = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, bool>) n_OptinResult_Z);
			return cb_optinResult_Z;
		}

		static void n_OptinResult_Z (IntPtr jnienv, IntPtr native__this, bool p0)
		{
			global::Com.Yrkfgo.Assxqx4.IEulaListener __this = global::Java.Lang.Object.GetObject<global::Com.Yrkfgo.Assxqx4.IEulaListener> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.OptinResult (p0);
		}
#pragma warning restore 0169

		IntPtr id_optinResult_Z;
		public unsafe void OptinResult (bool p0)
		{
			if (id_optinResult_Z == IntPtr.Zero)
				id_optinResult_Z = JNIEnv.GetMethodID (class_ref, "optinResult", "(Z)V");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue (p0);
			JNIEnv.CallVoidMethod (Handle, id_optinResult_Z, __args);
		}

		static Delegate cb_showingEula;
#pragma warning disable 0169
		static Delegate GetShowingEulaHandler ()
		{
			if (cb_showingEula == null)
				cb_showingEula = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr>) n_ShowingEula);
			return cb_showingEula;
		}

		static void n_ShowingEula (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Yrkfgo.Assxqx4.IEulaListener __this = global::Java.Lang.Object.GetObject<global::Com.Yrkfgo.Assxqx4.IEulaListener> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.ShowingEula ();
		}
#pragma warning restore 0169

		IntPtr id_showingEula;
		public unsafe void ShowingEula ()
		{
			if (id_showingEula == IntPtr.Zero)
				id_showingEula = JNIEnv.GetMethodID (class_ref, "showingEula", "()V");
			JNIEnv.CallVoidMethod (Handle, id_showingEula);
		}

	}

	public partial class OptinResultEventArgs : global::System.EventArgs {

		public OptinResultEventArgs (bool p0)
		{
			this.p0 = p0;
		}

		bool p0;
		public bool P0 {
			get { return p0; }
		}
	}

	[global::Android.Runtime.Register ("mono/com/yrkfgo/assxqx4/EulaListenerImplementor")]
	internal sealed partial class IEulaListenerImplementor : global::Java.Lang.Object, IEulaListener {

		object sender;

		public IEulaListenerImplementor (object sender)
			: base (
				global::Android.Runtime.JNIEnv.StartCreateInstance ("mono/com/yrkfgo/assxqx4/EulaListenerImplementor", "()V"),
				JniHandleOwnership.TransferLocalRef)
		{
			global::Android.Runtime.JNIEnv.FinishCreateInstance (Handle, "()V");
			this.sender = sender;
		}

#pragma warning disable 0649
		public EventHandler<OptinResultEventArgs> OptinResultHandler;
#pragma warning restore 0649

		public void OptinResult (bool p0)
		{
			var __h = OptinResultHandler;
			if (__h != null)
				__h (sender, new OptinResultEventArgs (p0));
		}
#pragma warning disable 0649
		public EventHandler ShowingEulaHandler;
#pragma warning restore 0649

		public void ShowingEula ()
		{
			var __h = ShowingEulaHandler;
			if (__h != null)
				__h (sender, new EventArgs ());
		}

		internal static bool __IsEmpty (IEulaListenerImplementor value)
		{
			return value.OptinResultHandler == null && value.ShowingEulaHandler == null;
		}
	}

}
