using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Yrkfgo.Assxqx4 {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.yrkfgo.assxqx4']/class[@name='UbService']"
	[global::Android.Runtime.Register ("com/yrkfgo/assxqx4/UbService", DoNotGenerateAcw=true)]
	public partial class UbService : global::Android.App.Service, global::Com.Yrkfgo.Assxqx4.IAdListener {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/yrkfgo/assxqx4/UbService", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (UbService); }
		}

		protected UbService (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.yrkfgo.assxqx4']/class[@name='UbService']/constructor[@name='UbService' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe UbService ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (UbService)) {
					SetHandle (
							global::Android.Runtime.JNIEnv.StartCreateInstance (GetType (), "()V"),
							JniHandleOwnership.TransferLocalRef);
					global::Android.Runtime.JNIEnv.FinishCreateInstance (Handle, "()V");
					return;
				}

				if (id_ctor == IntPtr.Zero)
					id_ctor = JNIEnv.GetMethodID (class_ref, "<init>", "()V");
				SetHandle (
						global::Android.Runtime.JNIEnv.StartCreateInstance (class_ref, id_ctor),
						JniHandleOwnership.TransferLocalRef);
				JNIEnv.FinishCreateInstance (Handle, class_ref, id_ctor);
			} finally {
			}
		}

		static Delegate cb_noAdListener;
#pragma warning disable 0169
		static Delegate GetNoAdListenerHandler ()
		{
			if (cb_noAdListener == null)
				cb_noAdListener = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr>) n_NoAdListener);
			return cb_noAdListener;
		}

		static void n_NoAdListener (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Yrkfgo.Assxqx4.UbService __this = global::Java.Lang.Object.GetObject<global::Com.Yrkfgo.Assxqx4.UbService> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.NoAdListener ();
		}
#pragma warning restore 0169

		static IntPtr id_noAdListener;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.yrkfgo.assxqx4']/class[@name='UbService']/method[@name='noAdListener' and count(parameter)=0]"
		[Register ("noAdListener", "()V", "GetNoAdListenerHandler")]
		public virtual unsafe void NoAdListener ()
		{
			if (id_noAdListener == IntPtr.Zero)
				id_noAdListener = JNIEnv.GetMethodID (class_ref, "noAdListener", "()V");
			try {

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod  (Handle, id_noAdListener);
				else
					JNIEnv.CallNonvirtualVoidMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "noAdListener", "()V"));
			} finally {
			}
		}

		static Delegate cb_onAdCached_Lcom_yrkfgo_assxqx4_AdConfig_AdType_;
#pragma warning disable 0169
		static Delegate GetOnAdCached_Lcom_yrkfgo_assxqx4_AdConfig_AdType_Handler ()
		{
			if (cb_onAdCached_Lcom_yrkfgo_assxqx4_AdConfig_AdType_ == null)
				cb_onAdCached_Lcom_yrkfgo_assxqx4_AdConfig_AdType_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_OnAdCached_Lcom_yrkfgo_assxqx4_AdConfig_AdType_);
			return cb_onAdCached_Lcom_yrkfgo_assxqx4_AdConfig_AdType_;
		}

		static void n_OnAdCached_Lcom_yrkfgo_assxqx4_AdConfig_AdType_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Yrkfgo.Assxqx4.UbService __this = global::Java.Lang.Object.GetObject<global::Com.Yrkfgo.Assxqx4.UbService> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Com.Yrkfgo.Assxqx4.AdConfig.AdType p0 = global::Java.Lang.Object.GetObject<global::Com.Yrkfgo.Assxqx4.AdConfig.AdType> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.OnAdCached (p0);
		}
#pragma warning restore 0169

		static IntPtr id_onAdCached_Lcom_yrkfgo_assxqx4_AdConfig_AdType_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.yrkfgo.assxqx4']/class[@name='UbService']/method[@name='onAdCached' and count(parameter)=1 and parameter[1][@type='com.yrkfgo.assxqx4.AdConfig.AdType']]"
		[Register ("onAdCached", "(Lcom/yrkfgo/assxqx4/AdConfig$AdType;)V", "GetOnAdCached_Lcom_yrkfgo_assxqx4_AdConfig_AdType_Handler")]
		public virtual unsafe void OnAdCached (global::Com.Yrkfgo.Assxqx4.AdConfig.AdType p0)
		{
			if (id_onAdCached_Lcom_yrkfgo_assxqx4_AdConfig_AdType_ == IntPtr.Zero)
				id_onAdCached_Lcom_yrkfgo_assxqx4_AdConfig_AdType_ = JNIEnv.GetMethodID (class_ref, "onAdCached", "(Lcom/yrkfgo/assxqx4/AdConfig$AdType;)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod  (Handle, id_onAdCached_Lcom_yrkfgo_assxqx4_AdConfig_AdType_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "onAdCached", "(Lcom/yrkfgo/assxqx4/AdConfig$AdType;)V"), __args);
			} finally {
			}
		}

		static Delegate cb_onAdClickedListener;
#pragma warning disable 0169
		static Delegate GetOnAdClickedListenerHandler ()
		{
			if (cb_onAdClickedListener == null)
				cb_onAdClickedListener = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr>) n_OnAdClickedListener);
			return cb_onAdClickedListener;
		}

		static void n_OnAdClickedListener (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Yrkfgo.Assxqx4.UbService __this = global::Java.Lang.Object.GetObject<global::Com.Yrkfgo.Assxqx4.UbService> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.OnAdClickedListener ();
		}
#pragma warning restore 0169

		static IntPtr id_onAdClickedListener;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.yrkfgo.assxqx4']/class[@name='UbService']/method[@name='onAdClickedListener' and count(parameter)=0]"
		[Register ("onAdClickedListener", "()V", "GetOnAdClickedListenerHandler")]
		public virtual unsafe void OnAdClickedListener ()
		{
			if (id_onAdClickedListener == IntPtr.Zero)
				id_onAdClickedListener = JNIEnv.GetMethodID (class_ref, "onAdClickedListener", "()V");
			try {

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod  (Handle, id_onAdClickedListener);
				else
					JNIEnv.CallNonvirtualVoidMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "onAdClickedListener", "()V"));
			} finally {
			}
		}

		static Delegate cb_onAdClosed;
#pragma warning disable 0169
		static Delegate GetOnAdClosedHandler ()
		{
			if (cb_onAdClosed == null)
				cb_onAdClosed = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr>) n_OnAdClosed);
			return cb_onAdClosed;
		}

		static void n_OnAdClosed (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Yrkfgo.Assxqx4.UbService __this = global::Java.Lang.Object.GetObject<global::Com.Yrkfgo.Assxqx4.UbService> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.OnAdClosed ();
		}
#pragma warning restore 0169

		static IntPtr id_onAdClosed;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.yrkfgo.assxqx4']/class[@name='UbService']/method[@name='onAdClosed' and count(parameter)=0]"
		[Register ("onAdClosed", "()V", "GetOnAdClosedHandler")]
		public virtual unsafe void OnAdClosed ()
		{
			if (id_onAdClosed == IntPtr.Zero)
				id_onAdClosed = JNIEnv.GetMethodID (class_ref, "onAdClosed", "()V");
			try {

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod  (Handle, id_onAdClosed);
				else
					JNIEnv.CallNonvirtualVoidMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "onAdClosed", "()V"));
			} finally {
			}
		}

		static Delegate cb_onAdError_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetOnAdError_Ljava_lang_String_Handler ()
		{
			if (cb_onAdError_Ljava_lang_String_ == null)
				cb_onAdError_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_OnAdError_Ljava_lang_String_);
			return cb_onAdError_Ljava_lang_String_;
		}

		static void n_OnAdError_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Yrkfgo.Assxqx4.UbService __this = global::Java.Lang.Object.GetObject<global::Com.Yrkfgo.Assxqx4.UbService> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.OnAdError (p0);
		}
#pragma warning restore 0169

		static IntPtr id_onAdError_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.yrkfgo.assxqx4']/class[@name='UbService']/method[@name='onAdError' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("onAdError", "(Ljava/lang/String;)V", "GetOnAdError_Ljava_lang_String_Handler")]
		public virtual unsafe void OnAdError (string p0)
		{
			if (id_onAdError_Ljava_lang_String_ == IntPtr.Zero)
				id_onAdError_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "onAdError", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod  (Handle, id_onAdError_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "onAdError", "(Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static Delegate cb_onAdExpandedListner;
#pragma warning disable 0169
		static Delegate GetOnAdExpandedListnerHandler ()
		{
			if (cb_onAdExpandedListner == null)
				cb_onAdExpandedListner = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr>) n_OnAdExpandedListner);
			return cb_onAdExpandedListner;
		}

		static void n_OnAdExpandedListner (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Yrkfgo.Assxqx4.UbService __this = global::Java.Lang.Object.GetObject<global::Com.Yrkfgo.Assxqx4.UbService> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.OnAdExpandedListner ();
		}
#pragma warning restore 0169

		static IntPtr id_onAdExpandedListner;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.yrkfgo.assxqx4']/class[@name='UbService']/method[@name='onAdExpandedListner' and count(parameter)=0]"
		[Register ("onAdExpandedListner", "()V", "GetOnAdExpandedListnerHandler")]
		public virtual unsafe void OnAdExpandedListner ()
		{
			if (id_onAdExpandedListner == IntPtr.Zero)
				id_onAdExpandedListner = JNIEnv.GetMethodID (class_ref, "onAdExpandedListner", "()V");
			try {

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod  (Handle, id_onAdExpandedListner);
				else
					JNIEnv.CallNonvirtualVoidMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "onAdExpandedListner", "()V"));
			} finally {
			}
		}

		static Delegate cb_onAdLoadedListener;
#pragma warning disable 0169
		static Delegate GetOnAdLoadedListenerHandler ()
		{
			if (cb_onAdLoadedListener == null)
				cb_onAdLoadedListener = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr>) n_OnAdLoadedListener);
			return cb_onAdLoadedListener;
		}

		static void n_OnAdLoadedListener (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Yrkfgo.Assxqx4.UbService __this = global::Java.Lang.Object.GetObject<global::Com.Yrkfgo.Assxqx4.UbService> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.OnAdLoadedListener ();
		}
#pragma warning restore 0169

		static IntPtr id_onAdLoadedListener;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.yrkfgo.assxqx4']/class[@name='UbService']/method[@name='onAdLoadedListener' and count(parameter)=0]"
		[Register ("onAdLoadedListener", "()V", "GetOnAdLoadedListenerHandler")]
		public virtual unsafe void OnAdLoadedListener ()
		{
			if (id_onAdLoadedListener == IntPtr.Zero)
				id_onAdLoadedListener = JNIEnv.GetMethodID (class_ref, "onAdLoadedListener", "()V");
			try {

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod  (Handle, id_onAdLoadedListener);
				else
					JNIEnv.CallNonvirtualVoidMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "onAdLoadedListener", "()V"));
			} finally {
			}
		}

		static Delegate cb_onAdLoadingListener;
#pragma warning disable 0169
		static Delegate GetOnAdLoadingListenerHandler ()
		{
			if (cb_onAdLoadingListener == null)
				cb_onAdLoadingListener = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr>) n_OnAdLoadingListener);
			return cb_onAdLoadingListener;
		}

		static void n_OnAdLoadingListener (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Yrkfgo.Assxqx4.UbService __this = global::Java.Lang.Object.GetObject<global::Com.Yrkfgo.Assxqx4.UbService> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.OnAdLoadingListener ();
		}
#pragma warning restore 0169

		static IntPtr id_onAdLoadingListener;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.yrkfgo.assxqx4']/class[@name='UbService']/method[@name='onAdLoadingListener' and count(parameter)=0]"
		[Register ("onAdLoadingListener", "()V", "GetOnAdLoadingListenerHandler")]
		public virtual unsafe void OnAdLoadingListener ()
		{
			if (id_onAdLoadingListener == IntPtr.Zero)
				id_onAdLoadingListener = JNIEnv.GetMethodID (class_ref, "onAdLoadingListener", "()V");
			try {

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod  (Handle, id_onAdLoadingListener);
				else
					JNIEnv.CallNonvirtualVoidMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "onAdLoadingListener", "()V"));
			} finally {
			}
		}

		static Delegate cb_onAdShowing;
#pragma warning disable 0169
		static Delegate GetOnAdShowingHandler ()
		{
			if (cb_onAdShowing == null)
				cb_onAdShowing = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr>) n_OnAdShowing);
			return cb_onAdShowing;
		}

		static void n_OnAdShowing (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Yrkfgo.Assxqx4.UbService __this = global::Java.Lang.Object.GetObject<global::Com.Yrkfgo.Assxqx4.UbService> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.OnAdShowing ();
		}
#pragma warning restore 0169

		static IntPtr id_onAdShowing;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.yrkfgo.assxqx4']/class[@name='UbService']/method[@name='onAdShowing' and count(parameter)=0]"
		[Register ("onAdShowing", "()V", "GetOnAdShowingHandler")]
		public virtual unsafe void OnAdShowing ()
		{
			if (id_onAdShowing == IntPtr.Zero)
				id_onAdShowing = JNIEnv.GetMethodID (class_ref, "onAdShowing", "()V");
			try {

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod  (Handle, id_onAdShowing);
				else
					JNIEnv.CallNonvirtualVoidMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "onAdShowing", "()V"));
			} finally {
			}
		}

		static Delegate cb_onBind_Landroid_content_Intent_;
#pragma warning disable 0169
		static Delegate GetOnBind_Landroid_content_Intent_Handler ()
		{
			if (cb_onBind_Landroid_content_Intent_ == null)
				cb_onBind_Landroid_content_Intent_ = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, IntPtr>) n_OnBind_Landroid_content_Intent_);
			return cb_onBind_Landroid_content_Intent_;
		}

		static IntPtr n_OnBind_Landroid_content_Intent_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Yrkfgo.Assxqx4.UbService __this = global::Java.Lang.Object.GetObject<global::Com.Yrkfgo.Assxqx4.UbService> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Android.Content.Intent p0 = global::Java.Lang.Object.GetObject<global::Android.Content.Intent> (native_p0, JniHandleOwnership.DoNotTransfer);
			IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.OnBind (p0));
			return __ret;
		}
#pragma warning restore 0169

		static IntPtr id_onBind_Landroid_content_Intent_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.yrkfgo.assxqx4']/class[@name='UbService']/method[@name='onBind' and count(parameter)=1 and parameter[1][@type='android.content.Intent']]"
		[Register ("onBind", "(Landroid/content/Intent;)Landroid/os/IBinder;", "GetOnBind_Landroid_content_Intent_Handler")]
		public override unsafe global::Android.OS.IBinder OnBind (global::Android.Content.Intent p0)
		{
			if (id_onBind_Landroid_content_Intent_ == IntPtr.Zero)
				id_onBind_Landroid_content_Intent_ = JNIEnv.GetMethodID (class_ref, "onBind", "(Landroid/content/Intent;)Landroid/os/IBinder;");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);

				global::Android.OS.IBinder __ret;
				if (GetType () == ThresholdType)
					__ret = global::Java.Lang.Object.GetObject<global::Android.OS.IBinder> (JNIEnv.CallObjectMethod  (Handle, id_onBind_Landroid_content_Intent_, __args), JniHandleOwnership.TransferLocalRef);
				else
					__ret = global::Java.Lang.Object.GetObject<global::Android.OS.IBinder> (JNIEnv.CallNonvirtualObjectMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "onBind", "(Landroid/content/Intent;)Landroid/os/IBinder;"), __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static Delegate cb_onCloseListener;
#pragma warning disable 0169
		static Delegate GetOnCloseListenerHandler ()
		{
			if (cb_onCloseListener == null)
				cb_onCloseListener = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr>) n_OnCloseListener);
			return cb_onCloseListener;
		}

		static void n_OnCloseListener (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Yrkfgo.Assxqx4.UbService __this = global::Java.Lang.Object.GetObject<global::Com.Yrkfgo.Assxqx4.UbService> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.OnCloseListener ();
		}
#pragma warning restore 0169

		static IntPtr id_onCloseListener;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.yrkfgo.assxqx4']/class[@name='UbService']/method[@name='onCloseListener' and count(parameter)=0]"
		[Register ("onCloseListener", "()V", "GetOnCloseListenerHandler")]
		public virtual unsafe void OnCloseListener ()
		{
			if (id_onCloseListener == IntPtr.Zero)
				id_onCloseListener = JNIEnv.GetMethodID (class_ref, "onCloseListener", "()V");
			try {

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod  (Handle, id_onCloseListener);
				else
					JNIEnv.CallNonvirtualVoidMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "onCloseListener", "()V"));
			} finally {
			}
		}

		static Delegate cb_onIntegrationError_Ljava_lang_String_;
#pragma warning disable 0169
		static Delegate GetOnIntegrationError_Ljava_lang_String_Handler ()
		{
			if (cb_onIntegrationError_Ljava_lang_String_ == null)
				cb_onIntegrationError_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_OnIntegrationError_Ljava_lang_String_);
			return cb_onIntegrationError_Ljava_lang_String_;
		}

		static void n_OnIntegrationError_Ljava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			global::Com.Yrkfgo.Assxqx4.UbService __this = global::Java.Lang.Object.GetObject<global::Com.Yrkfgo.Assxqx4.UbService> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.OnIntegrationError (p0);
		}
#pragma warning restore 0169

		static IntPtr id_onIntegrationError_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.yrkfgo.assxqx4']/class[@name='UbService']/method[@name='onIntegrationError' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("onIntegrationError", "(Ljava/lang/String;)V", "GetOnIntegrationError_Ljava_lang_String_Handler")]
		public virtual unsafe void OnIntegrationError (string p0)
		{
			if (id_onIntegrationError_Ljava_lang_String_ == IntPtr.Zero)
				id_onIntegrationError_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "onIntegrationError", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);

				if (GetType () == ThresholdType)
					JNIEnv.CallVoidMethod  (Handle, id_onIntegrationError_Ljava_lang_String_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "onIntegrationError", "(Ljava/lang/String;)V"), __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

	}
}
