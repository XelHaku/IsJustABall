using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Airpush.Xamarinlib {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.airpush.xamarinlib']/class[@name='AirpushSdk']"
	[global::Android.Runtime.Register ("com/airpush/xamarinlib/AirpushSdk", DoNotGenerateAcw=true)]
	public partial class AirpushSdk : global::Java.Lang.Object {


		static IntPtr mActivity_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='com.airpush.xamarinlib']/class[@name='AirpushSdk']/field[@name='mActivity']"
		[Register ("mActivity")]
		protected global::Android.App.Activity MActivity {
			get {
				if (mActivity_jfieldId == IntPtr.Zero)
					mActivity_jfieldId = JNIEnv.GetFieldID (class_ref, "mActivity", "Landroid/app/Activity;");
				IntPtr __ret = JNIEnv.GetObjectField (Handle, mActivity_jfieldId);
				return global::Java.Lang.Object.GetObject<global::Android.App.Activity> (__ret, JniHandleOwnership.TransferLocalRef);
			}
			set {
				if (mActivity_jfieldId == IntPtr.Zero)
					mActivity_jfieldId = JNIEnv.GetFieldID (class_ref, "mActivity", "Landroid/app/Activity;");
				IntPtr native_value = JNIEnv.ToLocalJniHandle (value);
				JNIEnv.SetField (Handle, mActivity_jfieldId, native_value);
				JNIEnv.DeleteLocalRef (native_value);
			}
		}
		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/airpush/xamarinlib/AirpushSdk", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (AirpushSdk); }
		}

		protected AirpushSdk (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor_Landroid_app_Activity_;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.airpush.xamarinlib']/class[@name='AirpushSdk']/constructor[@name='AirpushSdk' and count(parameter)=1 and parameter[1][@type='android.app.Activity']]"
		[Register (".ctor", "(Landroid/app/Activity;)V", "")]
		public AirpushSdk (global::Android.App.Activity p0) : base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (Handle != IntPtr.Zero)
				return;

			if (GetType () != typeof (AirpushSdk)) {
				SetHandle (
						global::Android.Runtime.JNIEnv.StartCreateInstance (GetType (), "(Landroid/app/Activity;)V", new JValue (p0)),
						JniHandleOwnership.TransferLocalRef);
				global::Android.Runtime.JNIEnv.FinishCreateInstance (Handle, "(Landroid/app/Activity;)V", new JValue (p0));
				return;
			}

			if (id_ctor_Landroid_app_Activity_ == IntPtr.Zero)
				id_ctor_Landroid_app_Activity_ = JNIEnv.GetMethodID (class_ref, "<init>", "(Landroid/app/Activity;)V");
			SetHandle (
					global::Android.Runtime.JNIEnv.StartCreateInstance (class_ref, id_ctor_Landroid_app_Activity_, new JValue (p0)),
					JniHandleOwnership.TransferLocalRef);
			JNIEnv.FinishCreateInstance (Handle, class_ref, id_ctor_Landroid_app_Activity_, new JValue (p0));
		}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.airpush.xamarinlib']/class[@name='AirpushSdk']/constructor[@name='AirpushSdk' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public AirpushSdk () : base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (Handle != IntPtr.Zero)
				return;

			if (GetType () != typeof (AirpushSdk)) {
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
		}

		static Delegate cb_airBannerBottomAd;
#pragma warning disable 0169
		static Delegate GetAirBannerBottomAdHandler ()
		{
			if (cb_airBannerBottomAd == null)
				cb_airBannerBottomAd = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr>) n_AirBannerBottomAd);
			return cb_airBannerBottomAd;
		}

		static void n_AirBannerBottomAd (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Airpush.Xamarinlib.AirpushSdk __this = global::Java.Lang.Object.GetObject<global::Com.Airpush.Xamarinlib.AirpushSdk> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.AirBannerBottomAd ();
		}
#pragma warning restore 0169

		static IntPtr id_airBannerBottomAd;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.airpush.xamarinlib']/class[@name='AirpushSdk']/method[@name='airBannerBottomAd' and count(parameter)=0]"
		[Register ("airBannerBottomAd", "()V", "GetAirBannerBottomAdHandler")]
		public virtual void AirBannerBottomAd ()
		{
			if (id_airBannerBottomAd == IntPtr.Zero)
				id_airBannerBottomAd = JNIEnv.GetMethodID (class_ref, "airBannerBottomAd", "()V");

			if (GetType () == ThresholdType)
				JNIEnv.CallVoidMethod  (Handle, id_airBannerBottomAd);
			else
				JNIEnv.CallNonvirtualVoidMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "airBannerBottomAd", "()V"));
		}

		static Delegate cb_airBannerTopAd;
#pragma warning disable 0169
		static Delegate GetAirBannerTopAdHandler ()
		{
			if (cb_airBannerTopAd == null)
				cb_airBannerTopAd = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr>) n_AirBannerTopAd);
			return cb_airBannerTopAd;
		}

		static void n_AirBannerTopAd (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Airpush.Xamarinlib.AirpushSdk __this = global::Java.Lang.Object.GetObject<global::Com.Airpush.Xamarinlib.AirpushSdk> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.AirBannerTopAd ();
		}
#pragma warning restore 0169

		static IntPtr id_airBannerTopAd;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.airpush.xamarinlib']/class[@name='AirpushSdk']/method[@name='airBannerTopAd' and count(parameter)=0]"
		[Register ("airBannerTopAd", "()V", "GetAirBannerTopAdHandler")]
		public virtual void AirBannerTopAd ()
		{
			if (id_airBannerTopAd == IntPtr.Zero)
				id_airBannerTopAd = JNIEnv.GetMethodID (class_ref, "airBannerTopAd", "()V");

			if (GetType () == ThresholdType)
				JNIEnv.CallVoidMethod  (Handle, id_airBannerTopAd);
			else
				JNIEnv.CallNonvirtualVoidMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "airBannerTopAd", "()V"));
		}

		static Delegate cb_airConfig_ILjava_lang_String_ZZI;
#pragma warning disable 0169
		static Delegate GetAirConfig_ILjava_lang_String_ZZIHandler ()
		{
			if (cb_airConfig_ILjava_lang_String_ZZI == null)
				cb_airConfig_ILjava_lang_String_ZZI = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, int, IntPtr, bool, bool, int>) n_AirConfig_ILjava_lang_String_ZZI);
			return cb_airConfig_ILjava_lang_String_ZZI;
		}

		static void n_AirConfig_ILjava_lang_String_ZZI (IntPtr jnienv, IntPtr native__this, int p0, IntPtr native_p1, bool p2, bool p3, int p4)
		{
			global::Com.Airpush.Xamarinlib.AirpushSdk __this = global::Java.Lang.Object.GetObject<global::Com.Airpush.Xamarinlib.AirpushSdk> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p1 = JNIEnv.GetString (native_p1, JniHandleOwnership.DoNotTransfer);
			__this.AirConfig (p0, p1, p2, p3, p4);
		}
#pragma warning restore 0169

		static IntPtr id_airConfig_ILjava_lang_String_ZZI;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.airpush.xamarinlib']/class[@name='AirpushSdk']/method[@name='airConfig' and count(parameter)=5 and parameter[1][@type='int'] and parameter[2][@type='java.lang.String'] and parameter[3][@type='boolean'] and parameter[4][@type='boolean'] and parameter[5][@type='int']]"
		[Register ("airConfig", "(ILjava/lang/String;ZZI)V", "GetAirConfig_ILjava_lang_String_ZZIHandler")]
		public virtual void AirConfig (int p0, string p1, bool p2, bool p3, int p4)
		{
			if (id_airConfig_ILjava_lang_String_ZZI == IntPtr.Zero)
				id_airConfig_ILjava_lang_String_ZZI = JNIEnv.GetMethodID (class_ref, "airConfig", "(ILjava/lang/String;ZZI)V");
			IntPtr native_p1 = JNIEnv.NewString (p1);

			if (GetType () == ThresholdType)
				JNIEnv.CallVoidMethod  (Handle, id_airConfig_ILjava_lang_String_ZZI, new JValue (p0), new JValue (native_p1), new JValue (p2), new JValue (p3), new JValue (p4));
			else
				JNIEnv.CallNonvirtualVoidMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "airConfig", "(ILjava/lang/String;ZZI)V"), new JValue (p0), new JValue (native_p1), new JValue (p2), new JValue (p3), new JValue (p4));
			JNIEnv.DeleteLocalRef (native_p1);
		}

		static Delegate cb_airSmartWallAd;
#pragma warning disable 0169
		static Delegate GetAirSmartWallAdHandler ()
		{
			if (cb_airSmartWallAd == null)
				cb_airSmartWallAd = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr>) n_AirSmartWallAd);
			return cb_airSmartWallAd;
		}

		static void n_AirSmartWallAd (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Airpush.Xamarinlib.AirpushSdk __this = global::Java.Lang.Object.GetObject<global::Com.Airpush.Xamarinlib.AirpushSdk> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.AirSmartWallAd ();
		}
#pragma warning restore 0169

		static IntPtr id_airSmartWallAd;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.airpush.xamarinlib']/class[@name='AirpushSdk']/method[@name='airSmartWallAd' and count(parameter)=0]"
		[Register ("airSmartWallAd", "()V", "GetAirSmartWallAdHandler")]
		public virtual void AirSmartWallAd ()
		{
			if (id_airSmartWallAd == IntPtr.Zero)
				id_airSmartWallAd = JNIEnv.GetMethodID (class_ref, "airSmartWallAd", "()V");

			if (GetType () == ThresholdType)
				JNIEnv.CallVoidMethod  (Handle, id_airSmartWallAd);
			else
				JNIEnv.CallNonvirtualVoidMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "airSmartWallAd", "()V"));
		}

		static Delegate cb_banner360;
#pragma warning disable 0169
		static Delegate GetBanner360Handler ()
		{
			if (cb_banner360 == null)
				cb_banner360 = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr>) n_Banner360);
			return cb_banner360;
		}

		static void n_Banner360 (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Airpush.Xamarinlib.AirpushSdk __this = global::Java.Lang.Object.GetObject<global::Com.Airpush.Xamarinlib.AirpushSdk> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.Banner360 ();
		}
#pragma warning restore 0169

		static IntPtr id_banner360;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.airpush.xamarinlib']/class[@name='AirpushSdk']/method[@name='banner360' and count(parameter)=0]"
		[Register ("banner360", "()V", "GetBanner360Handler")]
		public virtual void Banner360 ()
		{
			if (id_banner360 == IntPtr.Zero)
				id_banner360 = JNIEnv.GetMethodID (class_ref, "banner360", "()V");

			if (GetType () == ThresholdType)
				JNIEnv.CallVoidMethod  (Handle, id_banner360);
			else
				JNIEnv.CallNonvirtualVoidMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "banner360", "()V"));
		}

		static Delegate cb_iconAds;
#pragma warning disable 0169
		static Delegate GetIconAdsHandler ()
		{
			if (cb_iconAds == null)
				cb_iconAds = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr>) n_IconAds);
			return cb_iconAds;
		}

		static void n_IconAds (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Airpush.Xamarinlib.AirpushSdk __this = global::Java.Lang.Object.GetObject<global::Com.Airpush.Xamarinlib.AirpushSdk> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.IconAds ();
		}
#pragma warning restore 0169

		static IntPtr id_iconAds;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.airpush.xamarinlib']/class[@name='AirpushSdk']/method[@name='iconAds' and count(parameter)=0]"
		[Register ("iconAds", "()V", "GetIconAdsHandler")]
		public virtual void IconAds ()
		{
			if (id_iconAds == IntPtr.Zero)
				id_iconAds = JNIEnv.GetMethodID (class_ref, "iconAds", "()V");

			if (GetType () == ThresholdType)
				JNIEnv.CallVoidMethod  (Handle, id_iconAds);
			else
				JNIEnv.CallNonvirtualVoidMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "iconAds", "()V"));
		}

		static Delegate cb_pushAds;
#pragma warning disable 0169
		static Delegate GetPushAdsHandler ()
		{
			if (cb_pushAds == null)
				cb_pushAds = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr>) n_PushAds);
			return cb_pushAds;
		}

		static void n_PushAds (IntPtr jnienv, IntPtr native__this)
		{
			global::Com.Airpush.Xamarinlib.AirpushSdk __this = global::Java.Lang.Object.GetObject<global::Com.Airpush.Xamarinlib.AirpushSdk> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.PushAds ();
		}
#pragma warning restore 0169

		static IntPtr id_pushAds;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.airpush.xamarinlib']/class[@name='AirpushSdk']/method[@name='pushAds' and count(parameter)=0]"
		[Register ("pushAds", "()V", "GetPushAdsHandler")]
		public virtual void PushAds ()
		{
			if (id_pushAds == IntPtr.Zero)
				id_pushAds = JNIEnv.GetMethodID (class_ref, "pushAds", "()V");

			if (GetType () == ThresholdType)
				JNIEnv.CallVoidMethod  (Handle, id_pushAds);
			else
				JNIEnv.CallNonvirtualVoidMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "pushAds", "()V"));
		}

	}
}
