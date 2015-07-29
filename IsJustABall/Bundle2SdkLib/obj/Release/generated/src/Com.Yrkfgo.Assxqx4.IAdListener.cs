using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Yrkfgo.Assxqx4 {

	// Metadata.xml XPath interface reference: path="/api/package[@name='com.yrkfgo.assxqx4']/interface[@name='AdListener']"
	[Register ("com/yrkfgo/assxqx4/AdListener", "", "Com.Yrkfgo.Assxqx4.IAdListenerInvoker")]
	public partial interface IAdListener : IJavaObject {

		// Metadata.xml XPath method reference: path="/api/package[@name='com.yrkfgo.assxqx4']/interface[@name='AdListener']/method[@name='noAdListener' and count(parameter)=0]"
		[Register ("noAdListener", "()V", "GetNoAdListenerHandler:Com.Yrkfgo.Assxqx4.IAdListenerInvoker, BundleSdkLib")]
		void NoAdListener ();

		// Metadata.xml XPath method reference: path="/api/package[@name='com.yrkfgo.assxqx4']/interface[@name='AdListener']/method[@name='onAdCached' and count(parameter)=1 and parameter[1][@type='com.yrkfgo.assxqx4.AdConfig.AdType']]"
		[Register ("onAdCached", "(Lcom/yrkfgo/assxqx4/AdConfig$AdType;)V", "GetOnAdCached_Lcom_yrkfgo_assxqx4_AdConfig_AdType_Handler:Com.Yrkfgo.Assxqx4.IAdListenerInvoker, BundleSdkLib")]
		void OnAdCached (global::Com.Yrkfgo.Assxqx4.AdConfig.AdType p0);

		// Metadata.xml XPath method reference: path="/api/package[@name='com.yrkfgo.assxqx4']/interface[@name='AdListener']/method[@name='onAdClickedListener' and count(parameter)=0]"
		[Register ("onAdClickedListener", "()V", "GetOnAdClickedListenerHandler:Com.Yrkfgo.Assxqx4.IAdListenerInvoker, BundleSdkLib")]
		void OnAdClickedListener ();

		// Metadata.xml XPath method reference: path="/api/package[@name='com.yrkfgo.assxqx4']/interface[@name='AdListener']/method[@name='onAdClosed' and count(parameter)=0]"
		[Register ("onAdClosed", "()V", "GetOnAdClosedHandler:Com.Yrkfgo.Assxqx4.IAdListenerInvoker, BundleSdkLib")]
		void OnAdClosed ();

		// Metadata.xml XPath method reference: path="/api/package[@name='com.yrkfgo.assxqx4']/interface[@name='AdListener']/method[@name='onAdError' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("onAdError", "(Ljava/lang/String;)V", "GetOnAdError_Ljava_lang_String_Handler:Com.Yrkfgo.Assxqx4.IAdListenerInvoker, BundleSdkLib")]
		void OnAdError (string p0);

		// Metadata.xml XPath method reference: path="/api/package[@name='com.yrkfgo.assxqx4']/interface[@name='AdListener']/method[@name='onAdExpandedListner' and count(parameter)=0]"
		[Register ("onAdExpandedListner", "()V", "GetOnAdExpandedListnerHandler:Com.Yrkfgo.Assxqx4.IAdListenerInvoker, BundleSdkLib")]
		void OnAdExpandedListner ();

		// Metadata.xml XPath method reference: path="/api/package[@name='com.yrkfgo.assxqx4']/interface[@name='AdListener']/method[@name='onAdLoadedListener' and count(parameter)=0]"
		[Register ("onAdLoadedListener", "()V", "GetOnAdLoadedListenerHandler:Com.Yrkfgo.Assxqx4.IAdListenerInvoker, BundleSdkLib")]
		void OnAdLoadedListener ();

		// Metadata.xml XPath method reference: path="/api/package[@name='com.yrkfgo.assxqx4']/interface[@name='AdListener']/method[@name='onAdLoadingListener' and count(parameter)=0]"
		[Register ("onAdLoadingListener", "()V", "GetOnAdLoadingListenerHandler:Com.Yrkfgo.Assxqx4.IAdListenerInvoker, BundleSdkLib")]
		void OnAdLoadingListener ();

		// Metadata.xml XPath method reference: path="/api/package[@name='com.yrkfgo.assxqx4']/interface[@name='AdListener']/method[@name='onAdShowing' and count(parameter)=0]"
		[Register ("onAdShowing", "()V", "GetOnAdShowingHandler:Com.Yrkfgo.Assxqx4.IAdListenerInvoker, BundleSdkLib")]
		void OnAdShowing ();

		// Metadata.xml XPath method reference: path="/api/package[@name='com.yrkfgo.assxqx4']/interface[@name='AdListener']/method[@name='onCloseListener' and count(parameter)=0]"
		[Register ("onCloseListener", "()V", "GetOnCloseListenerHandler:Com.Yrkfgo.Assxqx4.IAdListenerInvoker, BundleSdkLib")]
		void OnCloseListener ();

		// Metadata.xml XPath method reference: path="/api/package[@name='com.yrkfgo.assxqx4']/interface[@name='AdListener']/method[@name='onIntegrationError' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("onIntegrationError", "(Ljava/lang/String;)V", "GetOnIntegrationError_Ljava_lang_String_Handler:Com.Yrkfgo.Assxqx4.IAdListenerInvoker, BundleSdkLib")]
		void OnIntegrationError (string p0);

	}

	[global::Android.Runtime.Register ("com/yrkfgo/assxqx4/AdListener", DoNotGenerateAcw=true)]
	internal class IAdListenerInvoker : global::Java.Lang.Object, IAdListener {

		static IntPtr java_class_ref = JNIEnv.FindClass ("com/yrkfgo/assxqx4/AdListener");
		IntPtr class_ref;

		public static IAdListener GetObject (IntPtr handle, JniHandleOwnership transfer)
		{
			return global::Java.Lang.Object.GetObject<IAdListener> (handle, transfer);
		}

		static IntPtr Validate (IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf (handle, java_class_ref))
				throw new InvalidCastException (string.Format ("Unable to convert instance of type '{0}' to type '{1}'.",
							JNIEnv.GetClassNameFromInstance (handle), "com.yrkfgo.assxqx4.AdListener"));
			return handle;
		}

		protected override void Dispose (bool disposing)
		{
			if (this.class_ref != IntPtr.Zero)
				JNIEnv.DeleteGlobalRef (this.class_ref);
			this.class_ref = IntPtr.Zero;
			base.Dispose (disposing);
		}

		public IAdListenerInvoker (IntPtr handle, JniHandleOwnership transfer) : base (Validate (handle), transfer)
		{
			IntPtr local_ref = JNIEnv.GetObjectClass (Handle);
			this.class_ref = JNIEnv.NewGlobalRef (local_ref);
			JNIEnv.DeleteLocalRef (local_ref);
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (IAdListenerInvoker); }
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
			global::Com.Yrkfgo.Assxqx4.IAdListener __this = global::Java.Lang.Object.GetObject<global::Com.Yrkfgo.Assxqx4.IAdListener> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.NoAdListener ();
		}
#pragma warning restore 0169

		IntPtr id_noAdListener;
		public unsafe void NoAdListener ()
		{
			if (id_noAdListener == IntPtr.Zero)
				id_noAdListener = JNIEnv.GetMethodID (class_ref, "noAdListener", "()V");
			JNIEnv.CallVoidMethod (Handle, id_noAdListener);
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
			global::Com.Yrkfgo.Assxqx4.IAdListener __this = global::Java.Lang.Object.GetObject<global::Com.Yrkfgo.Assxqx4.IAdListener> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Com.Yrkfgo.Assxqx4.AdConfig.AdType p0 = global::Java.Lang.Object.GetObject<global::Com.Yrkfgo.Assxqx4.AdConfig.AdType> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.OnAdCached (p0);
		}
#pragma warning restore 0169

		IntPtr id_onAdCached_Lcom_yrkfgo_assxqx4_AdConfig_AdType_;
		public unsafe void OnAdCached (global::Com.Yrkfgo.Assxqx4.AdConfig.AdType p0)
		{
			if (id_onAdCached_Lcom_yrkfgo_assxqx4_AdConfig_AdType_ == IntPtr.Zero)
				id_onAdCached_Lcom_yrkfgo_assxqx4_AdConfig_AdType_ = JNIEnv.GetMethodID (class_ref, "onAdCached", "(Lcom/yrkfgo/assxqx4/AdConfig$AdType;)V");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue (p0);
			JNIEnv.CallVoidMethod (Handle, id_onAdCached_Lcom_yrkfgo_assxqx4_AdConfig_AdType_, __args);
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
			global::Com.Yrkfgo.Assxqx4.IAdListener __this = global::Java.Lang.Object.GetObject<global::Com.Yrkfgo.Assxqx4.IAdListener> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.OnAdClickedListener ();
		}
#pragma warning restore 0169

		IntPtr id_onAdClickedListener;
		public unsafe void OnAdClickedListener ()
		{
			if (id_onAdClickedListener == IntPtr.Zero)
				id_onAdClickedListener = JNIEnv.GetMethodID (class_ref, "onAdClickedListener", "()V");
			JNIEnv.CallVoidMethod (Handle, id_onAdClickedListener);
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
			global::Com.Yrkfgo.Assxqx4.IAdListener __this = global::Java.Lang.Object.GetObject<global::Com.Yrkfgo.Assxqx4.IAdListener> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.OnAdClosed ();
		}
#pragma warning restore 0169

		IntPtr id_onAdClosed;
		public unsafe void OnAdClosed ()
		{
			if (id_onAdClosed == IntPtr.Zero)
				id_onAdClosed = JNIEnv.GetMethodID (class_ref, "onAdClosed", "()V");
			JNIEnv.CallVoidMethod (Handle, id_onAdClosed);
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
			global::Com.Yrkfgo.Assxqx4.IAdListener __this = global::Java.Lang.Object.GetObject<global::Com.Yrkfgo.Assxqx4.IAdListener> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.OnAdError (p0);
		}
#pragma warning restore 0169

		IntPtr id_onAdError_Ljava_lang_String_;
		public unsafe void OnAdError (string p0)
		{
			if (id_onAdError_Ljava_lang_String_ == IntPtr.Zero)
				id_onAdError_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "onAdError", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue (native_p0);
			JNIEnv.CallVoidMethod (Handle, id_onAdError_Ljava_lang_String_, __args);
			JNIEnv.DeleteLocalRef (native_p0);
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
			global::Com.Yrkfgo.Assxqx4.IAdListener __this = global::Java.Lang.Object.GetObject<global::Com.Yrkfgo.Assxqx4.IAdListener> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.OnAdExpandedListner ();
		}
#pragma warning restore 0169

		IntPtr id_onAdExpandedListner;
		public unsafe void OnAdExpandedListner ()
		{
			if (id_onAdExpandedListner == IntPtr.Zero)
				id_onAdExpandedListner = JNIEnv.GetMethodID (class_ref, "onAdExpandedListner", "()V");
			JNIEnv.CallVoidMethod (Handle, id_onAdExpandedListner);
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
			global::Com.Yrkfgo.Assxqx4.IAdListener __this = global::Java.Lang.Object.GetObject<global::Com.Yrkfgo.Assxqx4.IAdListener> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.OnAdLoadedListener ();
		}
#pragma warning restore 0169

		IntPtr id_onAdLoadedListener;
		public unsafe void OnAdLoadedListener ()
		{
			if (id_onAdLoadedListener == IntPtr.Zero)
				id_onAdLoadedListener = JNIEnv.GetMethodID (class_ref, "onAdLoadedListener", "()V");
			JNIEnv.CallVoidMethod (Handle, id_onAdLoadedListener);
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
			global::Com.Yrkfgo.Assxqx4.IAdListener __this = global::Java.Lang.Object.GetObject<global::Com.Yrkfgo.Assxqx4.IAdListener> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.OnAdLoadingListener ();
		}
#pragma warning restore 0169

		IntPtr id_onAdLoadingListener;
		public unsafe void OnAdLoadingListener ()
		{
			if (id_onAdLoadingListener == IntPtr.Zero)
				id_onAdLoadingListener = JNIEnv.GetMethodID (class_ref, "onAdLoadingListener", "()V");
			JNIEnv.CallVoidMethod (Handle, id_onAdLoadingListener);
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
			global::Com.Yrkfgo.Assxqx4.IAdListener __this = global::Java.Lang.Object.GetObject<global::Com.Yrkfgo.Assxqx4.IAdListener> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.OnAdShowing ();
		}
#pragma warning restore 0169

		IntPtr id_onAdShowing;
		public unsafe void OnAdShowing ()
		{
			if (id_onAdShowing == IntPtr.Zero)
				id_onAdShowing = JNIEnv.GetMethodID (class_ref, "onAdShowing", "()V");
			JNIEnv.CallVoidMethod (Handle, id_onAdShowing);
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
			global::Com.Yrkfgo.Assxqx4.IAdListener __this = global::Java.Lang.Object.GetObject<global::Com.Yrkfgo.Assxqx4.IAdListener> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.OnCloseListener ();
		}
#pragma warning restore 0169

		IntPtr id_onCloseListener;
		public unsafe void OnCloseListener ()
		{
			if (id_onCloseListener == IntPtr.Zero)
				id_onCloseListener = JNIEnv.GetMethodID (class_ref, "onCloseListener", "()V");
			JNIEnv.CallVoidMethod (Handle, id_onCloseListener);
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
			global::Com.Yrkfgo.Assxqx4.IAdListener __this = global::Java.Lang.Object.GetObject<global::Com.Yrkfgo.Assxqx4.IAdListener> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p0 = JNIEnv.GetString (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.OnIntegrationError (p0);
		}
#pragma warning restore 0169

		IntPtr id_onIntegrationError_Ljava_lang_String_;
		public unsafe void OnIntegrationError (string p0)
		{
			if (id_onIntegrationError_Ljava_lang_String_ == IntPtr.Zero)
				id_onIntegrationError_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "onIntegrationError", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue (native_p0);
			JNIEnv.CallVoidMethod (Handle, id_onIntegrationError_Ljava_lang_String_, __args);
			JNIEnv.DeleteLocalRef (native_p0);
		}

	}

	public partial class AdCachedEventArgs : global::System.EventArgs {

		public AdCachedEventArgs (global::Com.Yrkfgo.Assxqx4.AdConfig.AdType p0)
		{
			this.p0 = p0;
		}

		global::Com.Yrkfgo.Assxqx4.AdConfig.AdType p0;
		public global::Com.Yrkfgo.Assxqx4.AdConfig.AdType P0 {
			get { return p0; }
		}
	}

	public partial class AdErrorEventArgs : global::System.EventArgs {

		public AdErrorEventArgs (string p0)
		{
			this.p0 = p0;
		}

		string p0;
		public string P0 {
			get { return p0; }
		}
	}

	public partial class IntegrationErrorEventArgs : global::System.EventArgs {

		public IntegrationErrorEventArgs (string p0)
		{
			this.p0 = p0;
		}

		string p0;
		public string P0 {
			get { return p0; }
		}
	}

	[global::Android.Runtime.Register ("mono/com/yrkfgo/assxqx4/AdListenerImplementor")]
	internal sealed partial class IAdListenerImplementor : global::Java.Lang.Object, IAdListener {

		object sender;

		public IAdListenerImplementor (object sender)
			: base (
				global::Android.Runtime.JNIEnv.StartCreateInstance ("mono/com/yrkfgo/assxqx4/AdListenerImplementor", "()V"),
				JniHandleOwnership.TransferLocalRef)
		{
			global::Android.Runtime.JNIEnv.FinishCreateInstance (Handle, "()V");
			this.sender = sender;
		}

#pragma warning disable 0649
		public EventHandler NoAdListenerHandler;
#pragma warning restore 0649

		public void NoAdListener ()
		{
			var __h = NoAdListenerHandler;
			if (__h != null)
				__h (sender, new EventArgs ());
		}
#pragma warning disable 0649
		public EventHandler<AdCachedEventArgs> OnAdCachedHandler;
#pragma warning restore 0649

		public void OnAdCached (global::Com.Yrkfgo.Assxqx4.AdConfig.AdType p0)
		{
			var __h = OnAdCachedHandler;
			if (__h != null)
				__h (sender, new AdCachedEventArgs (p0));
		}
#pragma warning disable 0649
		public EventHandler OnAdClickedListenerHandler;
#pragma warning restore 0649

		public void OnAdClickedListener ()
		{
			var __h = OnAdClickedListenerHandler;
			if (__h != null)
				__h (sender, new EventArgs ());
		}
#pragma warning disable 0649
		public EventHandler OnAdClosedHandler;
#pragma warning restore 0649

		public void OnAdClosed ()
		{
			var __h = OnAdClosedHandler;
			if (__h != null)
				__h (sender, new EventArgs ());
		}
#pragma warning disable 0649
		public EventHandler<AdErrorEventArgs> OnAdErrorHandler;
#pragma warning restore 0649

		public void OnAdError (string p0)
		{
			var __h = OnAdErrorHandler;
			if (__h != null)
				__h (sender, new AdErrorEventArgs (p0));
		}
#pragma warning disable 0649
		public EventHandler OnAdExpandedListnerHandler;
#pragma warning restore 0649

		public void OnAdExpandedListner ()
		{
			var __h = OnAdExpandedListnerHandler;
			if (__h != null)
				__h (sender, new EventArgs ());
		}
#pragma warning disable 0649
		public EventHandler OnAdLoadedListenerHandler;
#pragma warning restore 0649

		public void OnAdLoadedListener ()
		{
			var __h = OnAdLoadedListenerHandler;
			if (__h != null)
				__h (sender, new EventArgs ());
		}
#pragma warning disable 0649
		public EventHandler OnAdLoadingListenerHandler;
#pragma warning restore 0649

		public void OnAdLoadingListener ()
		{
			var __h = OnAdLoadingListenerHandler;
			if (__h != null)
				__h (sender, new EventArgs ());
		}
#pragma warning disable 0649
		public EventHandler OnAdShowingHandler;
#pragma warning restore 0649

		public void OnAdShowing ()
		{
			var __h = OnAdShowingHandler;
			if (__h != null)
				__h (sender, new EventArgs ());
		}
#pragma warning disable 0649
		public EventHandler OnCloseListenerHandler;
#pragma warning restore 0649

		public void OnCloseListener ()
		{
			var __h = OnCloseListenerHandler;
			if (__h != null)
				__h (sender, new EventArgs ());
		}
#pragma warning disable 0649
		public EventHandler<IntegrationErrorEventArgs> OnIntegrationErrorHandler;
#pragma warning restore 0649

		public void OnIntegrationError (string p0)
		{
			var __h = OnIntegrationErrorHandler;
			if (__h != null)
				__h (sender, new IntegrationErrorEventArgs (p0));
		}

		internal static bool __IsEmpty (IAdListenerImplementor value)
		{
			return value.NoAdListenerHandler == null && value.OnAdCachedHandler == null && value.OnAdClickedListenerHandler == null && value.OnAdClosedHandler == null && value.OnAdErrorHandler == null && value.OnAdExpandedListnerHandler == null && value.OnAdLoadedListenerHandler == null && value.OnAdLoadingListenerHandler == null && value.OnAdShowingHandler == null && value.OnCloseListenerHandler == null && value.OnIntegrationErrorHandler == null;
		}
	}

}
