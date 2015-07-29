using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Com.Yrkfgo.Assxqx4 {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.yrkfgo.assxqx4']/class[@name='AdConfig']"
	[global::Android.Runtime.Register ("com/yrkfgo/assxqx4/AdConfig", DoNotGenerateAcw=true)]
	public sealed partial class AdConfig : global::Java.Lang.Object {

		// Metadata.xml XPath class reference: path="/api/package[@name='com.yrkfgo.assxqx4']/class[@name='AdConfig.AdType']"
		[global::Android.Runtime.Register ("com/yrkfgo/assxqx4/AdConfig$AdType", DoNotGenerateAcw=true)]
		public sealed partial class AdType : global::Java.Lang.Enum {


			static IntPtr appwall_jfieldId;

			// Metadata.xml XPath field reference: path="/api/package[@name='com.yrkfgo.assxqx4']/class[@name='AdConfig.AdType']/field[@name='appwall']"
			[Register ("appwall")]
			public static global::Com.Yrkfgo.Assxqx4.AdConfig.AdType Appwall {
				get {
					if (appwall_jfieldId == IntPtr.Zero)
						appwall_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "appwall", "Lcom/yrkfgo/assxqx4/AdConfig$AdType;");
					IntPtr __ret = JNIEnv.GetStaticObjectField (class_ref, appwall_jfieldId);
					return global::Java.Lang.Object.GetObject<global::Com.Yrkfgo.Assxqx4.AdConfig.AdType> (__ret, JniHandleOwnership.TransferLocalRef);
				}
			}

			static IntPtr interstitial_jfieldId;

			// Metadata.xml XPath field reference: path="/api/package[@name='com.yrkfgo.assxqx4']/class[@name='AdConfig.AdType']/field[@name='interstitial']"
			[Register ("interstitial")]
			public static global::Com.Yrkfgo.Assxqx4.AdConfig.AdType Interstitial {
				get {
					if (interstitial_jfieldId == IntPtr.Zero)
						interstitial_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "interstitial", "Lcom/yrkfgo/assxqx4/AdConfig$AdType;");
					IntPtr __ret = JNIEnv.GetStaticObjectField (class_ref, interstitial_jfieldId);
					return global::Java.Lang.Object.GetObject<global::Com.Yrkfgo.Assxqx4.AdConfig.AdType> (__ret, JniHandleOwnership.TransferLocalRef);
				}
			}

			static IntPtr landing_page_jfieldId;

			// Metadata.xml XPath field reference: path="/api/package[@name='com.yrkfgo.assxqx4']/class[@name='AdConfig.AdType']/field[@name='landing_page']"
			[Register ("landing_page")]
			public static global::Com.Yrkfgo.Assxqx4.AdConfig.AdType LandingPage {
				get {
					if (landing_page_jfieldId == IntPtr.Zero)
						landing_page_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "landing_page", "Lcom/yrkfgo/assxqx4/AdConfig$AdType;");
					IntPtr __ret = JNIEnv.GetStaticObjectField (class_ref, landing_page_jfieldId);
					return global::Java.Lang.Object.GetObject<global::Com.Yrkfgo.Assxqx4.AdConfig.AdType> (__ret, JniHandleOwnership.TransferLocalRef);
				}
			}

			static IntPtr overlay_jfieldId;

			// Metadata.xml XPath field reference: path="/api/package[@name='com.yrkfgo.assxqx4']/class[@name='AdConfig.AdType']/field[@name='overlay']"
			[Register ("overlay")]
			public static global::Com.Yrkfgo.Assxqx4.AdConfig.AdType Overlay {
				get {
					if (overlay_jfieldId == IntPtr.Zero)
						overlay_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "overlay", "Lcom/yrkfgo/assxqx4/AdConfig$AdType;");
					IntPtr __ret = JNIEnv.GetStaticObjectField (class_ref, overlay_jfieldId);
					return global::Java.Lang.Object.GetObject<global::Com.Yrkfgo.Assxqx4.AdConfig.AdType> (__ret, JniHandleOwnership.TransferLocalRef);
				}
			}

			static IntPtr smartwall_jfieldId;

			// Metadata.xml XPath field reference: path="/api/package[@name='com.yrkfgo.assxqx4']/class[@name='AdConfig.AdType']/field[@name='smartwall']"
			[Register ("smartwall")]
			public static global::Com.Yrkfgo.Assxqx4.AdConfig.AdType Smartwall {
				get {
					if (smartwall_jfieldId == IntPtr.Zero)
						smartwall_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "smartwall", "Lcom/yrkfgo/assxqx4/AdConfig$AdType;");
					IntPtr __ret = JNIEnv.GetStaticObjectField (class_ref, smartwall_jfieldId);
					return global::Java.Lang.Object.GetObject<global::Com.Yrkfgo.Assxqx4.AdConfig.AdType> (__ret, JniHandleOwnership.TransferLocalRef);
				}
			}

			static IntPtr video_jfieldId;

			// Metadata.xml XPath field reference: path="/api/package[@name='com.yrkfgo.assxqx4']/class[@name='AdConfig.AdType']/field[@name='video']"
			[Register ("video")]
			public static global::Com.Yrkfgo.Assxqx4.AdConfig.AdType Video {
				get {
					if (video_jfieldId == IntPtr.Zero)
						video_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "video", "Lcom/yrkfgo/assxqx4/AdConfig$AdType;");
					IntPtr __ret = JNIEnv.GetStaticObjectField (class_ref, video_jfieldId);
					return global::Java.Lang.Object.GetObject<global::Com.Yrkfgo.Assxqx4.AdConfig.AdType> (__ret, JniHandleOwnership.TransferLocalRef);
				}
			}
			internal static IntPtr java_class_handle;
			internal static IntPtr class_ref {
				get {
					return JNIEnv.FindClass ("com/yrkfgo/assxqx4/AdConfig$AdType", ref java_class_handle);
				}
			}

			protected override IntPtr ThresholdClass {
				get { return class_ref; }
			}

			protected override global::System.Type ThresholdType {
				get { return typeof (AdType); }
			}

			internal AdType (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

			static IntPtr id_valueOf_Ljava_lang_String_;
			// Metadata.xml XPath method reference: path="/api/package[@name='com.yrkfgo.assxqx4']/class[@name='AdConfig.AdType']/method[@name='valueOf' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("valueOf", "(Ljava/lang/String;)Lcom/yrkfgo/assxqx4/AdConfig$AdType;", "")]
			public static unsafe global::Com.Yrkfgo.Assxqx4.AdConfig.AdType ValueOf (string p0)
			{
				if (id_valueOf_Ljava_lang_String_ == IntPtr.Zero)
					id_valueOf_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "valueOf", "(Ljava/lang/String;)Lcom/yrkfgo/assxqx4/AdConfig$AdType;");
				IntPtr native_p0 = JNIEnv.NewString (p0);
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (native_p0);
					global::Com.Yrkfgo.Assxqx4.AdConfig.AdType __ret = global::Java.Lang.Object.GetObject<global::Com.Yrkfgo.Assxqx4.AdConfig.AdType> (JNIEnv.CallStaticObjectMethod  (class_ref, id_valueOf_Ljava_lang_String_, __args), JniHandleOwnership.TransferLocalRef);
					return __ret;
				} finally {
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}

			static IntPtr id_values;
			// Metadata.xml XPath method reference: path="/api/package[@name='com.yrkfgo.assxqx4']/class[@name='AdConfig.AdType']/method[@name='values' and count(parameter)=0]"
			[Register ("values", "()[Lcom/yrkfgo/assxqx4/AdConfig$AdType;", "")]
			public static unsafe global::Com.Yrkfgo.Assxqx4.AdConfig.AdType[] Values ()
			{
				if (id_values == IntPtr.Zero)
					id_values = JNIEnv.GetStaticMethodID (class_ref, "values", "()[Lcom/yrkfgo/assxqx4/AdConfig$AdType;");
				try {
					return (global::Com.Yrkfgo.Assxqx4.AdConfig.AdType[]) JNIEnv.GetArray (JNIEnv.CallStaticObjectMethod  (class_ref, id_values), JniHandleOwnership.TransferLocalRef, typeof (global::Com.Yrkfgo.Assxqx4.AdConfig.AdType));
				} finally {
				}
			}

		}

		// Metadata.xml XPath class reference: path="/api/package[@name='com.yrkfgo.assxqx4']/class[@name='AdConfig.EulaLanguage']"
		[global::Android.Runtime.Register ("com/yrkfgo/assxqx4/AdConfig$EulaLanguage", DoNotGenerateAcw=true)]
		public sealed partial class EulaLanguage : global::Java.Lang.Enum {


			static IntPtr ARABIC_jfieldId;

			// Metadata.xml XPath field reference: path="/api/package[@name='com.yrkfgo.assxqx4']/class[@name='AdConfig.EulaLanguage']/field[@name='ARABIC']"
			[Register ("ARABIC")]
			public static global::Com.Yrkfgo.Assxqx4.AdConfig.EulaLanguage Arabic {
				get {
					if (ARABIC_jfieldId == IntPtr.Zero)
						ARABIC_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "ARABIC", "Lcom/yrkfgo/assxqx4/AdConfig$EulaLanguage;");
					IntPtr __ret = JNIEnv.GetStaticObjectField (class_ref, ARABIC_jfieldId);
					return global::Java.Lang.Object.GetObject<global::Com.Yrkfgo.Assxqx4.AdConfig.EulaLanguage> (__ret, JniHandleOwnership.TransferLocalRef);
				}
			}

			static IntPtr CHINESE_jfieldId;

			// Metadata.xml XPath field reference: path="/api/package[@name='com.yrkfgo.assxqx4']/class[@name='AdConfig.EulaLanguage']/field[@name='CHINESE']"
			[Register ("CHINESE")]
			public static global::Com.Yrkfgo.Assxqx4.AdConfig.EulaLanguage Chinese {
				get {
					if (CHINESE_jfieldId == IntPtr.Zero)
						CHINESE_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "CHINESE", "Lcom/yrkfgo/assxqx4/AdConfig$EulaLanguage;");
					IntPtr __ret = JNIEnv.GetStaticObjectField (class_ref, CHINESE_jfieldId);
					return global::Java.Lang.Object.GetObject<global::Com.Yrkfgo.Assxqx4.AdConfig.EulaLanguage> (__ret, JniHandleOwnership.TransferLocalRef);
				}
			}

			static IntPtr ENGLISH_jfieldId;

			// Metadata.xml XPath field reference: path="/api/package[@name='com.yrkfgo.assxqx4']/class[@name='AdConfig.EulaLanguage']/field[@name='ENGLISH']"
			[Register ("ENGLISH")]
			public static global::Com.Yrkfgo.Assxqx4.AdConfig.EulaLanguage English {
				get {
					if (ENGLISH_jfieldId == IntPtr.Zero)
						ENGLISH_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "ENGLISH", "Lcom/yrkfgo/assxqx4/AdConfig$EulaLanguage;");
					IntPtr __ret = JNIEnv.GetStaticObjectField (class_ref, ENGLISH_jfieldId);
					return global::Java.Lang.Object.GetObject<global::Com.Yrkfgo.Assxqx4.AdConfig.EulaLanguage> (__ret, JniHandleOwnership.TransferLocalRef);
				}
			}

			static IntPtr FRENCH_jfieldId;

			// Metadata.xml XPath field reference: path="/api/package[@name='com.yrkfgo.assxqx4']/class[@name='AdConfig.EulaLanguage']/field[@name='FRENCH']"
			[Register ("FRENCH")]
			public static global::Com.Yrkfgo.Assxqx4.AdConfig.EulaLanguage French {
				get {
					if (FRENCH_jfieldId == IntPtr.Zero)
						FRENCH_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "FRENCH", "Lcom/yrkfgo/assxqx4/AdConfig$EulaLanguage;");
					IntPtr __ret = JNIEnv.GetStaticObjectField (class_ref, FRENCH_jfieldId);
					return global::Java.Lang.Object.GetObject<global::Com.Yrkfgo.Assxqx4.AdConfig.EulaLanguage> (__ret, JniHandleOwnership.TransferLocalRef);
				}
			}

			static IntPtr GERMAN_jfieldId;

			// Metadata.xml XPath field reference: path="/api/package[@name='com.yrkfgo.assxqx4']/class[@name='AdConfig.EulaLanguage']/field[@name='GERMAN']"
			[Register ("GERMAN")]
			public static global::Com.Yrkfgo.Assxqx4.AdConfig.EulaLanguage German {
				get {
					if (GERMAN_jfieldId == IntPtr.Zero)
						GERMAN_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "GERMAN", "Lcom/yrkfgo/assxqx4/AdConfig$EulaLanguage;");
					IntPtr __ret = JNIEnv.GetStaticObjectField (class_ref, GERMAN_jfieldId);
					return global::Java.Lang.Object.GetObject<global::Com.Yrkfgo.Assxqx4.AdConfig.EulaLanguage> (__ret, JniHandleOwnership.TransferLocalRef);
				}
			}

			static IntPtr ITALIAN_jfieldId;

			// Metadata.xml XPath field reference: path="/api/package[@name='com.yrkfgo.assxqx4']/class[@name='AdConfig.EulaLanguage']/field[@name='ITALIAN']"
			[Register ("ITALIAN")]
			public static global::Com.Yrkfgo.Assxqx4.AdConfig.EulaLanguage Italian {
				get {
					if (ITALIAN_jfieldId == IntPtr.Zero)
						ITALIAN_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "ITALIAN", "Lcom/yrkfgo/assxqx4/AdConfig$EulaLanguage;");
					IntPtr __ret = JNIEnv.GetStaticObjectField (class_ref, ITALIAN_jfieldId);
					return global::Java.Lang.Object.GetObject<global::Com.Yrkfgo.Assxqx4.AdConfig.EulaLanguage> (__ret, JniHandleOwnership.TransferLocalRef);
				}
			}

			static IntPtr JAPANESE_jfieldId;

			// Metadata.xml XPath field reference: path="/api/package[@name='com.yrkfgo.assxqx4']/class[@name='AdConfig.EulaLanguage']/field[@name='JAPANESE']"
			[Register ("JAPANESE")]
			public static global::Com.Yrkfgo.Assxqx4.AdConfig.EulaLanguage Japanese {
				get {
					if (JAPANESE_jfieldId == IntPtr.Zero)
						JAPANESE_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "JAPANESE", "Lcom/yrkfgo/assxqx4/AdConfig$EulaLanguage;");
					IntPtr __ret = JNIEnv.GetStaticObjectField (class_ref, JAPANESE_jfieldId);
					return global::Java.Lang.Object.GetObject<global::Com.Yrkfgo.Assxqx4.AdConfig.EulaLanguage> (__ret, JniHandleOwnership.TransferLocalRef);
				}
			}

			static IntPtr KOREAN_jfieldId;

			// Metadata.xml XPath field reference: path="/api/package[@name='com.yrkfgo.assxqx4']/class[@name='AdConfig.EulaLanguage']/field[@name='KOREAN']"
			[Register ("KOREAN")]
			public static global::Com.Yrkfgo.Assxqx4.AdConfig.EulaLanguage Korean {
				get {
					if (KOREAN_jfieldId == IntPtr.Zero)
						KOREAN_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "KOREAN", "Lcom/yrkfgo/assxqx4/AdConfig$EulaLanguage;");
					IntPtr __ret = JNIEnv.GetStaticObjectField (class_ref, KOREAN_jfieldId);
					return global::Java.Lang.Object.GetObject<global::Com.Yrkfgo.Assxqx4.AdConfig.EulaLanguage> (__ret, JniHandleOwnership.TransferLocalRef);
				}
			}

			static IntPtr PORTUGUESE_jfieldId;

			// Metadata.xml XPath field reference: path="/api/package[@name='com.yrkfgo.assxqx4']/class[@name='AdConfig.EulaLanguage']/field[@name='PORTUGUESE']"
			[Register ("PORTUGUESE")]
			public static global::Com.Yrkfgo.Assxqx4.AdConfig.EulaLanguage Portuguese {
				get {
					if (PORTUGUESE_jfieldId == IntPtr.Zero)
						PORTUGUESE_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "PORTUGUESE", "Lcom/yrkfgo/assxqx4/AdConfig$EulaLanguage;");
					IntPtr __ret = JNIEnv.GetStaticObjectField (class_ref, PORTUGUESE_jfieldId);
					return global::Java.Lang.Object.GetObject<global::Com.Yrkfgo.Assxqx4.AdConfig.EulaLanguage> (__ret, JniHandleOwnership.TransferLocalRef);
				}
			}

			static IntPtr RUSSIAN_jfieldId;

			// Metadata.xml XPath field reference: path="/api/package[@name='com.yrkfgo.assxqx4']/class[@name='AdConfig.EulaLanguage']/field[@name='RUSSIAN']"
			[Register ("RUSSIAN")]
			public static global::Com.Yrkfgo.Assxqx4.AdConfig.EulaLanguage Russian {
				get {
					if (RUSSIAN_jfieldId == IntPtr.Zero)
						RUSSIAN_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "RUSSIAN", "Lcom/yrkfgo/assxqx4/AdConfig$EulaLanguage;");
					IntPtr __ret = JNIEnv.GetStaticObjectField (class_ref, RUSSIAN_jfieldId);
					return global::Java.Lang.Object.GetObject<global::Com.Yrkfgo.Assxqx4.AdConfig.EulaLanguage> (__ret, JniHandleOwnership.TransferLocalRef);
				}
			}

			static IntPtr SPANISH_jfieldId;

			// Metadata.xml XPath field reference: path="/api/package[@name='com.yrkfgo.assxqx4']/class[@name='AdConfig.EulaLanguage']/field[@name='SPANISH']"
			[Register ("SPANISH")]
			public static global::Com.Yrkfgo.Assxqx4.AdConfig.EulaLanguage Spanish {
				get {
					if (SPANISH_jfieldId == IntPtr.Zero)
						SPANISH_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "SPANISH", "Lcom/yrkfgo/assxqx4/AdConfig$EulaLanguage;");
					IntPtr __ret = JNIEnv.GetStaticObjectField (class_ref, SPANISH_jfieldId);
					return global::Java.Lang.Object.GetObject<global::Com.Yrkfgo.Assxqx4.AdConfig.EulaLanguage> (__ret, JniHandleOwnership.TransferLocalRef);
				}
			}

			static IntPtr TURKISH_jfieldId;

			// Metadata.xml XPath field reference: path="/api/package[@name='com.yrkfgo.assxqx4']/class[@name='AdConfig.EulaLanguage']/field[@name='TURKISH']"
			[Register ("TURKISH")]
			public static global::Com.Yrkfgo.Assxqx4.AdConfig.EulaLanguage Turkish {
				get {
					if (TURKISH_jfieldId == IntPtr.Zero)
						TURKISH_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "TURKISH", "Lcom/yrkfgo/assxqx4/AdConfig$EulaLanguage;");
					IntPtr __ret = JNIEnv.GetStaticObjectField (class_ref, TURKISH_jfieldId);
					return global::Java.Lang.Object.GetObject<global::Com.Yrkfgo.Assxqx4.AdConfig.EulaLanguage> (__ret, JniHandleOwnership.TransferLocalRef);
				}
			}
			internal static IntPtr java_class_handle;
			internal static IntPtr class_ref {
				get {
					return JNIEnv.FindClass ("com/yrkfgo/assxqx4/AdConfig$EulaLanguage", ref java_class_handle);
				}
			}

			protected override IntPtr ThresholdClass {
				get { return class_ref; }
			}

			protected override global::System.Type ThresholdType {
				get { return typeof (EulaLanguage); }
			}

			internal EulaLanguage (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

			static IntPtr id_valueOf_Ljava_lang_String_;
			// Metadata.xml XPath method reference: path="/api/package[@name='com.yrkfgo.assxqx4']/class[@name='AdConfig.EulaLanguage']/method[@name='valueOf' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
			[Register ("valueOf", "(Ljava/lang/String;)Lcom/yrkfgo/assxqx4/AdConfig$EulaLanguage;", "")]
			public static unsafe global::Com.Yrkfgo.Assxqx4.AdConfig.EulaLanguage ValueOf (string p0)
			{
				if (id_valueOf_Ljava_lang_String_ == IntPtr.Zero)
					id_valueOf_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "valueOf", "(Ljava/lang/String;)Lcom/yrkfgo/assxqx4/AdConfig$EulaLanguage;");
				IntPtr native_p0 = JNIEnv.NewString (p0);
				try {
					JValue* __args = stackalloc JValue [1];
					__args [0] = new JValue (native_p0);
					global::Com.Yrkfgo.Assxqx4.AdConfig.EulaLanguage __ret = global::Java.Lang.Object.GetObject<global::Com.Yrkfgo.Assxqx4.AdConfig.EulaLanguage> (JNIEnv.CallStaticObjectMethod  (class_ref, id_valueOf_Ljava_lang_String_, __args), JniHandleOwnership.TransferLocalRef);
					return __ret;
				} finally {
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}

			static IntPtr id_values;
			// Metadata.xml XPath method reference: path="/api/package[@name='com.yrkfgo.assxqx4']/class[@name='AdConfig.EulaLanguage']/method[@name='values' and count(parameter)=0]"
			[Register ("values", "()[Lcom/yrkfgo/assxqx4/AdConfig$EulaLanguage;", "")]
			public static unsafe global::Com.Yrkfgo.Assxqx4.AdConfig.EulaLanguage[] Values ()
			{
				if (id_values == IntPtr.Zero)
					id_values = JNIEnv.GetStaticMethodID (class_ref, "values", "()[Lcom/yrkfgo/assxqx4/AdConfig$EulaLanguage;");
				try {
					return (global::Com.Yrkfgo.Assxqx4.AdConfig.EulaLanguage[]) JNIEnv.GetArray (JNIEnv.CallStaticObjectMethod  (class_ref, id_values), JniHandleOwnership.TransferLocalRef, typeof (global::Com.Yrkfgo.Assxqx4.AdConfig.EulaLanguage));
				} finally {
				}
			}

		}

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("com/yrkfgo/assxqx4/AdConfig", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (AdConfig); }
		}

		internal AdConfig (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_ctor;
		// Metadata.xml XPath constructor reference: path="/api/package[@name='com.yrkfgo.assxqx4']/class[@name='AdConfig']/constructor[@name='AdConfig' and count(parameter)=0]"
		[Register (".ctor", "()V", "")]
		public unsafe AdConfig ()
			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (Handle != IntPtr.Zero)
				return;

			try {
				if (GetType () != typeof (AdConfig)) {
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

		static IntPtr id_getAdListener;
		protected static unsafe global::Com.Yrkfgo.Assxqx4.IAdListener AdListener {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.yrkfgo.assxqx4']/class[@name='AdConfig']/method[@name='getAdListener' and count(parameter)=0]"
			[Register ("getAdListener", "()Lcom/yrkfgo/assxqx4/AdListener;", "GetGetAdListenerHandler")]
			get {
				if (id_getAdListener == IntPtr.Zero)
					id_getAdListener = JNIEnv.GetStaticMethodID (class_ref, "getAdListener", "()Lcom/yrkfgo/assxqx4/AdListener;");
				try {
					return global::Java.Lang.Object.GetObject<global::Com.Yrkfgo.Assxqx4.IAdListener> (JNIEnv.CallStaticObjectMethod  (class_ref, id_getAdListener), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static IntPtr id_getApiKey;
		protected static unsafe string ApiKey {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.yrkfgo.assxqx4']/class[@name='AdConfig']/method[@name='getApiKey' and count(parameter)=0]"
			[Register ("getApiKey", "()Ljava/lang/String;", "GetGetApiKeyHandler")]
			get {
				if (id_getApiKey == IntPtr.Zero)
					id_getApiKey = JNIEnv.GetStaticMethodID (class_ref, "getApiKey", "()Ljava/lang/String;");
				try {
					return JNIEnv.GetString (JNIEnv.CallStaticObjectMethod  (class_ref, id_getApiKey), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static IntPtr id_getAppId;
		protected static unsafe int AppId {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.yrkfgo.assxqx4']/class[@name='AdConfig']/method[@name='getAppId' and count(parameter)=0]"
			[Register ("getAppId", "()I", "GetGetAppIdHandler")]
			get {
				if (id_getAppId == IntPtr.Zero)
					id_getAppId = JNIEnv.GetStaticMethodID (class_ref, "getAppId", "()I");
				try {
					return JNIEnv.CallStaticIntMethod  (class_ref, id_getAppId);
				} finally {
				}
			}
		}

		static IntPtr id_getEulaListener;
		protected static unsafe global::Com.Yrkfgo.Assxqx4.IEulaListener EulaListener {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.yrkfgo.assxqx4']/class[@name='AdConfig']/method[@name='getEulaListener' and count(parameter)=0]"
			[Register ("getEulaListener", "()Lcom/yrkfgo/assxqx4/EulaListener;", "GetGetEulaListenerHandler")]
			get {
				if (id_getEulaListener == IntPtr.Zero)
					id_getEulaListener = JNIEnv.GetStaticMethodID (class_ref, "getEulaListener", "()Lcom/yrkfgo/assxqx4/EulaListener;");
				try {
					return global::Java.Lang.Object.GetObject<global::Com.Yrkfgo.Assxqx4.IEulaListener> (JNIEnv.CallStaticObjectMethod  (class_ref, id_getEulaListener), JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

		static IntPtr id_isCachingEnabled;
		protected static unsafe bool IsCachingEnabled {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.yrkfgo.assxqx4']/class[@name='AdConfig']/method[@name='isCachingEnabled' and count(parameter)=0]"
			[Register ("isCachingEnabled", "()Z", "GetIsCachingEnabledHandler")]
			get {
				if (id_isCachingEnabled == IntPtr.Zero)
					id_isCachingEnabled = JNIEnv.GetStaticMethodID (class_ref, "isCachingEnabled", "()Z");
				try {
					return JNIEnv.CallStaticBooleanMethod  (class_ref, id_isCachingEnabled);
				} finally {
				}
			}
		}

		static IntPtr id_isShowErrorDialog;
		protected static unsafe bool IsShowErrorDialog {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.yrkfgo.assxqx4']/class[@name='AdConfig']/method[@name='isShowErrorDialog' and count(parameter)=0]"
			[Register ("isShowErrorDialog", "()Z", "GetIsShowErrorDialogHandler")]
			get {
				if (id_isShowErrorDialog == IntPtr.Zero)
					id_isShowErrorDialog = JNIEnv.GetStaticMethodID (class_ref, "isShowErrorDialog", "()Z");
				try {
					return JNIEnv.CallStaticBooleanMethod  (class_ref, id_isShowErrorDialog);
				} finally {
				}
			}
		}

		static IntPtr id_isTestMode;
		protected static unsafe bool IsTestMode {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.yrkfgo.assxqx4']/class[@name='AdConfig']/method[@name='isTestMode' and count(parameter)=0]"
			[Register ("isTestMode", "()Z", "GetIsTestModeHandler")]
			get {
				if (id_isTestMode == IntPtr.Zero)
					id_isTestMode = JNIEnv.GetStaticMethodID (class_ref, "isTestMode", "()Z");
				try {
					return JNIEnv.CallStaticBooleanMethod  (class_ref, id_isTestMode);
				} finally {
				}
			}
		}

		static IntPtr id_getPlacementId;
		protected static unsafe int PlacementId {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.yrkfgo.assxqx4']/class[@name='AdConfig']/method[@name='getPlacementId' and count(parameter)=0]"
			[Register ("getPlacementId", "()I", "GetGetPlacementIdHandler")]
			get {
				if (id_getPlacementId == IntPtr.Zero)
					id_getPlacementId = JNIEnv.GetStaticMethodID (class_ref, "getPlacementId", "()I");
				try {
					return JNIEnv.CallStaticIntMethod  (class_ref, id_getPlacementId);
				} finally {
				}
			}
		}

		static IntPtr id_getEulaLanguage;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.yrkfgo.assxqx4']/class[@name='AdConfig']/method[@name='getEulaLanguage' and count(parameter)=0]"
		[Register ("getEulaLanguage", "()Lcom/yrkfgo/assxqx4/AdConfig$EulaLanguage;", "")]
		protected static unsafe global::Com.Yrkfgo.Assxqx4.AdConfig.EulaLanguage GetEulaLanguage ()
		{
			if (id_getEulaLanguage == IntPtr.Zero)
				id_getEulaLanguage = JNIEnv.GetStaticMethodID (class_ref, "getEulaLanguage", "()Lcom/yrkfgo/assxqx4/AdConfig$EulaLanguage;");
			try {
				return global::Java.Lang.Object.GetObject<global::Com.Yrkfgo.Assxqx4.AdConfig.EulaLanguage> (JNIEnv.CallStaticObjectMethod  (class_ref, id_getEulaLanguage), JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		static IntPtr id_setAdListener_Lcom_yrkfgo_assxqx4_AdListener_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.yrkfgo.assxqx4']/class[@name='AdConfig']/method[@name='setAdListener' and count(parameter)=1 and parameter[1][@type='com.yrkfgo.assxqx4.AdListener']]"
		[Register ("setAdListener", "(Lcom/yrkfgo/assxqx4/AdListener;)V", "")]
		public static unsafe void SetAdListener (global::Com.Yrkfgo.Assxqx4.IAdListener p0)
		{
			if (id_setAdListener_Lcom_yrkfgo_assxqx4_AdListener_ == IntPtr.Zero)
				id_setAdListener_Lcom_yrkfgo_assxqx4_AdListener_ = JNIEnv.GetStaticMethodID (class_ref, "setAdListener", "(Lcom/yrkfgo/assxqx4/AdListener;)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_setAdListener_Lcom_yrkfgo_assxqx4_AdListener_, __args);
			} finally {
			}
		}

		static IntPtr id_setApiKey_Ljava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.yrkfgo.assxqx4']/class[@name='AdConfig']/method[@name='setApiKey' and count(parameter)=1 and parameter[1][@type='java.lang.String']]"
		[Register ("setApiKey", "(Ljava/lang/String;)V", "")]
		public static unsafe void SetApiKey (string p0)
		{
			if (id_setApiKey_Ljava_lang_String_ == IntPtr.Zero)
				id_setApiKey_Ljava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "setApiKey", "(Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_setApiKey_Ljava_lang_String_, __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
			}
		}

		static IntPtr id_setAppId_I;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.yrkfgo.assxqx4']/class[@name='AdConfig']/method[@name='setAppId' and count(parameter)=1 and parameter[1][@type='int']]"
		[Register ("setAppId", "(I)V", "")]
		public static unsafe void SetAppId (int p0)
		{
			if (id_setAppId_I == IntPtr.Zero)
				id_setAppId_I = JNIEnv.GetStaticMethodID (class_ref, "setAppId", "(I)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_setAppId_I, __args);
			} finally {
			}
		}

		static IntPtr id_setCachingEnabled_Z;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.yrkfgo.assxqx4']/class[@name='AdConfig']/method[@name='setCachingEnabled' and count(parameter)=1 and parameter[1][@type='boolean']]"
		[Register ("setCachingEnabled", "(Z)V", "")]
		public static unsafe void SetCachingEnabled (bool p0)
		{
			if (id_setCachingEnabled_Z == IntPtr.Zero)
				id_setCachingEnabled_Z = JNIEnv.GetStaticMethodID (class_ref, "setCachingEnabled", "(Z)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_setCachingEnabled_Z, __args);
			} finally {
			}
		}

		static IntPtr id_setEulaLanguage_Lcom_yrkfgo_assxqx4_AdConfig_EulaLanguage_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.yrkfgo.assxqx4']/class[@name='AdConfig']/method[@name='setEulaLanguage' and count(parameter)=1 and parameter[1][@type='com.yrkfgo.assxqx4.AdConfig.EulaLanguage']]"
		[Register ("setEulaLanguage", "(Lcom/yrkfgo/assxqx4/AdConfig$EulaLanguage;)V", "")]
		public static unsafe void SetEulaLanguage (global::Com.Yrkfgo.Assxqx4.AdConfig.EulaLanguage p0)
		{
			if (id_setEulaLanguage_Lcom_yrkfgo_assxqx4_AdConfig_EulaLanguage_ == IntPtr.Zero)
				id_setEulaLanguage_Lcom_yrkfgo_assxqx4_AdConfig_EulaLanguage_ = JNIEnv.GetStaticMethodID (class_ref, "setEulaLanguage", "(Lcom/yrkfgo/assxqx4/AdConfig$EulaLanguage;)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_setEulaLanguage_Lcom_yrkfgo_assxqx4_AdConfig_EulaLanguage_, __args);
			} finally {
			}
		}

		static IntPtr id_setEulaListener_Lcom_yrkfgo_assxqx4_EulaListener_;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.yrkfgo.assxqx4']/class[@name='AdConfig']/method[@name='setEulaListener' and count(parameter)=1 and parameter[1][@type='com.yrkfgo.assxqx4.EulaListener']]"
		[Register ("setEulaListener", "(Lcom/yrkfgo/assxqx4/EulaListener;)V", "")]
		public static unsafe void SetEulaListener (global::Com.Yrkfgo.Assxqx4.IEulaListener p0)
		{
			if (id_setEulaListener_Lcom_yrkfgo_assxqx4_EulaListener_ == IntPtr.Zero)
				id_setEulaListener_Lcom_yrkfgo_assxqx4_EulaListener_ = JNIEnv.GetStaticMethodID (class_ref, "setEulaListener", "(Lcom/yrkfgo/assxqx4/EulaListener;)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_setEulaListener_Lcom_yrkfgo_assxqx4_EulaListener_, __args);
			} finally {
			}
		}

		static IntPtr id_setPlacementId_I;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.yrkfgo.assxqx4']/class[@name='AdConfig']/method[@name='setPlacementId' and count(parameter)=1 and parameter[1][@type='int']]"
		[Register ("setPlacementId", "(I)V", "")]
		public static unsafe void SetPlacementId (int p0)
		{
			if (id_setPlacementId_I == IntPtr.Zero)
				id_setPlacementId_I = JNIEnv.GetStaticMethodID (class_ref, "setPlacementId", "(I)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_setPlacementId_I, __args);
			} finally {
			}
		}

		static IntPtr id_setShowErrorDialog_Z;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.yrkfgo.assxqx4']/class[@name='AdConfig']/method[@name='setShowErrorDialog' and count(parameter)=1 and parameter[1][@type='boolean']]"
		[Register ("setShowErrorDialog", "(Z)V", "")]
		public static unsafe void SetShowErrorDialog (bool p0)
		{
			if (id_setShowErrorDialog_Z == IntPtr.Zero)
				id_setShowErrorDialog_Z = JNIEnv.GetStaticMethodID (class_ref, "setShowErrorDialog", "(Z)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_setShowErrorDialog_Z, __args);
			} finally {
			}
		}

		static IntPtr id_setTestMode_Z;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.yrkfgo.assxqx4']/class[@name='AdConfig']/method[@name='setTestMode' and count(parameter)=1 and parameter[1][@type='boolean']]"
		[Register ("setTestMode", "(Z)V", "")]
		public static unsafe void SetTestMode (bool p0)
		{
			if (id_setTestMode_Z == IntPtr.Zero)
				id_setTestMode_Z = JNIEnv.GetStaticMethodID (class_ref, "setTestMode", "(Z)V");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_setTestMode_Z, __args);
			} finally {
			}
		}

#region "Event implementation for Com.Yrkfgo.Assxqx4.IAdListener"
		public event EventHandler NoAdListener {
			add {
				global::Java.Interop.EventHelper.AddEventHandler<global::Com.Yrkfgo.Assxqx4.IAdListener, global::Com.Yrkfgo.Assxqx4.IAdListenerImplementor>(
						ref weak_implementor_SetAdListener,
						__CreateIAdListenerImplementor,
						SetAdListener,
						__h => __h.NoAdListenerHandler += value);
			}
			remove {
				global::Java.Interop.EventHelper.RemoveEventHandler<global::Com.Yrkfgo.Assxqx4.IAdListener, global::Com.Yrkfgo.Assxqx4.IAdListenerImplementor>(
						ref weak_implementor_SetAdListener,
						global::Com.Yrkfgo.Assxqx4.IAdListenerImplementor.__IsEmpty,
						__v => SetAdListener (null),
						__h => __h.NoAdListenerHandler -= value);
			}
		}

		public event EventHandler<global::Com.Yrkfgo.Assxqx4.AdCachedEventArgs> AdCached {
			add {
				global::Java.Interop.EventHelper.AddEventHandler<global::Com.Yrkfgo.Assxqx4.IAdListener, global::Com.Yrkfgo.Assxqx4.IAdListenerImplementor>(
						ref weak_implementor_SetAdListener,
						__CreateIAdListenerImplementor,
						SetAdListener,
						__h => __h.OnAdCachedHandler += value);
			}
			remove {
				global::Java.Interop.EventHelper.RemoveEventHandler<global::Com.Yrkfgo.Assxqx4.IAdListener, global::Com.Yrkfgo.Assxqx4.IAdListenerImplementor>(
						ref weak_implementor_SetAdListener,
						global::Com.Yrkfgo.Assxqx4.IAdListenerImplementor.__IsEmpty,
						__v => SetAdListener (null),
						__h => __h.OnAdCachedHandler -= value);
			}
		}

		public event EventHandler AdClickedListener {
			add {
				global::Java.Interop.EventHelper.AddEventHandler<global::Com.Yrkfgo.Assxqx4.IAdListener, global::Com.Yrkfgo.Assxqx4.IAdListenerImplementor>(
						ref weak_implementor_SetAdListener,
						__CreateIAdListenerImplementor,
						SetAdListener,
						__h => __h.OnAdClickedListenerHandler += value);
			}
			remove {
				global::Java.Interop.EventHelper.RemoveEventHandler<global::Com.Yrkfgo.Assxqx4.IAdListener, global::Com.Yrkfgo.Assxqx4.IAdListenerImplementor>(
						ref weak_implementor_SetAdListener,
						global::Com.Yrkfgo.Assxqx4.IAdListenerImplementor.__IsEmpty,
						__v => SetAdListener (null),
						__h => __h.OnAdClickedListenerHandler -= value);
			}
		}

		public event EventHandler AdClosed {
			add {
				global::Java.Interop.EventHelper.AddEventHandler<global::Com.Yrkfgo.Assxqx4.IAdListener, global::Com.Yrkfgo.Assxqx4.IAdListenerImplementor>(
						ref weak_implementor_SetAdListener,
						__CreateIAdListenerImplementor,
						SetAdListener,
						__h => __h.OnAdClosedHandler += value);
			}
			remove {
				global::Java.Interop.EventHelper.RemoveEventHandler<global::Com.Yrkfgo.Assxqx4.IAdListener, global::Com.Yrkfgo.Assxqx4.IAdListenerImplementor>(
						ref weak_implementor_SetAdListener,
						global::Com.Yrkfgo.Assxqx4.IAdListenerImplementor.__IsEmpty,
						__v => SetAdListener (null),
						__h => __h.OnAdClosedHandler -= value);
			}
		}

		public event EventHandler<global::Com.Yrkfgo.Assxqx4.AdErrorEventArgs> AdError {
			add {
				global::Java.Interop.EventHelper.AddEventHandler<global::Com.Yrkfgo.Assxqx4.IAdListener, global::Com.Yrkfgo.Assxqx4.IAdListenerImplementor>(
						ref weak_implementor_SetAdListener,
						__CreateIAdListenerImplementor,
						SetAdListener,
						__h => __h.OnAdErrorHandler += value);
			}
			remove {
				global::Java.Interop.EventHelper.RemoveEventHandler<global::Com.Yrkfgo.Assxqx4.IAdListener, global::Com.Yrkfgo.Assxqx4.IAdListenerImplementor>(
						ref weak_implementor_SetAdListener,
						global::Com.Yrkfgo.Assxqx4.IAdListenerImplementor.__IsEmpty,
						__v => SetAdListener (null),
						__h => __h.OnAdErrorHandler -= value);
			}
		}

		public event EventHandler AdExpandedListner {
			add {
				global::Java.Interop.EventHelper.AddEventHandler<global::Com.Yrkfgo.Assxqx4.IAdListener, global::Com.Yrkfgo.Assxqx4.IAdListenerImplementor>(
						ref weak_implementor_SetAdListener,
						__CreateIAdListenerImplementor,
						SetAdListener,
						__h => __h.OnAdExpandedListnerHandler += value);
			}
			remove {
				global::Java.Interop.EventHelper.RemoveEventHandler<global::Com.Yrkfgo.Assxqx4.IAdListener, global::Com.Yrkfgo.Assxqx4.IAdListenerImplementor>(
						ref weak_implementor_SetAdListener,
						global::Com.Yrkfgo.Assxqx4.IAdListenerImplementor.__IsEmpty,
						__v => SetAdListener (null),
						__h => __h.OnAdExpandedListnerHandler -= value);
			}
		}

		public event EventHandler AdLoadedListener {
			add {
				global::Java.Interop.EventHelper.AddEventHandler<global::Com.Yrkfgo.Assxqx4.IAdListener, global::Com.Yrkfgo.Assxqx4.IAdListenerImplementor>(
						ref weak_implementor_SetAdListener,
						__CreateIAdListenerImplementor,
						SetAdListener,
						__h => __h.OnAdLoadedListenerHandler += value);
			}
			remove {
				global::Java.Interop.EventHelper.RemoveEventHandler<global::Com.Yrkfgo.Assxqx4.IAdListener, global::Com.Yrkfgo.Assxqx4.IAdListenerImplementor>(
						ref weak_implementor_SetAdListener,
						global::Com.Yrkfgo.Assxqx4.IAdListenerImplementor.__IsEmpty,
						__v => SetAdListener (null),
						__h => __h.OnAdLoadedListenerHandler -= value);
			}
		}

		public event EventHandler AdLoadingListener {
			add {
				global::Java.Interop.EventHelper.AddEventHandler<global::Com.Yrkfgo.Assxqx4.IAdListener, global::Com.Yrkfgo.Assxqx4.IAdListenerImplementor>(
						ref weak_implementor_SetAdListener,
						__CreateIAdListenerImplementor,
						SetAdListener,
						__h => __h.OnAdLoadingListenerHandler += value);
			}
			remove {
				global::Java.Interop.EventHelper.RemoveEventHandler<global::Com.Yrkfgo.Assxqx4.IAdListener, global::Com.Yrkfgo.Assxqx4.IAdListenerImplementor>(
						ref weak_implementor_SetAdListener,
						global::Com.Yrkfgo.Assxqx4.IAdListenerImplementor.__IsEmpty,
						__v => SetAdListener (null),
						__h => __h.OnAdLoadingListenerHandler -= value);
			}
		}

		public event EventHandler AdShowing {
			add {
				global::Java.Interop.EventHelper.AddEventHandler<global::Com.Yrkfgo.Assxqx4.IAdListener, global::Com.Yrkfgo.Assxqx4.IAdListenerImplementor>(
						ref weak_implementor_SetAdListener,
						__CreateIAdListenerImplementor,
						SetAdListener,
						__h => __h.OnAdShowingHandler += value);
			}
			remove {
				global::Java.Interop.EventHelper.RemoveEventHandler<global::Com.Yrkfgo.Assxqx4.IAdListener, global::Com.Yrkfgo.Assxqx4.IAdListenerImplementor>(
						ref weak_implementor_SetAdListener,
						global::Com.Yrkfgo.Assxqx4.IAdListenerImplementor.__IsEmpty,
						__v => SetAdListener (null),
						__h => __h.OnAdShowingHandler -= value);
			}
		}

		public event EventHandler CloseListener {
			add {
				global::Java.Interop.EventHelper.AddEventHandler<global::Com.Yrkfgo.Assxqx4.IAdListener, global::Com.Yrkfgo.Assxqx4.IAdListenerImplementor>(
						ref weak_implementor_SetAdListener,
						__CreateIAdListenerImplementor,
						SetAdListener,
						__h => __h.OnCloseListenerHandler += value);
			}
			remove {
				global::Java.Interop.EventHelper.RemoveEventHandler<global::Com.Yrkfgo.Assxqx4.IAdListener, global::Com.Yrkfgo.Assxqx4.IAdListenerImplementor>(
						ref weak_implementor_SetAdListener,
						global::Com.Yrkfgo.Assxqx4.IAdListenerImplementor.__IsEmpty,
						__v => SetAdListener (null),
						__h => __h.OnCloseListenerHandler -= value);
			}
		}

		public event EventHandler<global::Com.Yrkfgo.Assxqx4.IntegrationErrorEventArgs> IntegrationError {
			add {
				global::Java.Interop.EventHelper.AddEventHandler<global::Com.Yrkfgo.Assxqx4.IAdListener, global::Com.Yrkfgo.Assxqx4.IAdListenerImplementor>(
						ref weak_implementor_SetAdListener,
						__CreateIAdListenerImplementor,
						SetAdListener,
						__h => __h.OnIntegrationErrorHandler += value);
			}
			remove {
				global::Java.Interop.EventHelper.RemoveEventHandler<global::Com.Yrkfgo.Assxqx4.IAdListener, global::Com.Yrkfgo.Assxqx4.IAdListenerImplementor>(
						ref weak_implementor_SetAdListener,
						global::Com.Yrkfgo.Assxqx4.IAdListenerImplementor.__IsEmpty,
						__v => SetAdListener (null),
						__h => __h.OnIntegrationErrorHandler -= value);
			}
		}

		WeakReference weak_implementor_SetAdListener;

		global::Com.Yrkfgo.Assxqx4.IAdListenerImplementor __CreateIAdListenerImplementor ()
		{
			return new global::Com.Yrkfgo.Assxqx4.IAdListenerImplementor (this);
		}
#endregion
#region "Event implementation for Com.Yrkfgo.Assxqx4.IEulaListener"
		public event EventHandler<global::Com.Yrkfgo.Assxqx4.OptinResultEventArgs> OptinResult {
			add {
				global::Java.Interop.EventHelper.AddEventHandler<global::Com.Yrkfgo.Assxqx4.IEulaListener, global::Com.Yrkfgo.Assxqx4.IEulaListenerImplementor>(
						ref weak_implementor_SetEulaListener,
						__CreateIEulaListenerImplementor,
						SetEulaListener,
						__h => __h.OptinResultHandler += value);
			}
			remove {
				global::Java.Interop.EventHelper.RemoveEventHandler<global::Com.Yrkfgo.Assxqx4.IEulaListener, global::Com.Yrkfgo.Assxqx4.IEulaListenerImplementor>(
						ref weak_implementor_SetEulaListener,
						global::Com.Yrkfgo.Assxqx4.IEulaListenerImplementor.__IsEmpty,
						__v => SetEulaListener (null),
						__h => __h.OptinResultHandler -= value);
			}
		}

		public event EventHandler ShowingEula {
			add {
				global::Java.Interop.EventHelper.AddEventHandler<global::Com.Yrkfgo.Assxqx4.IEulaListener, global::Com.Yrkfgo.Assxqx4.IEulaListenerImplementor>(
						ref weak_implementor_SetEulaListener,
						__CreateIEulaListenerImplementor,
						SetEulaListener,
						__h => __h.ShowingEulaHandler += value);
			}
			remove {
				global::Java.Interop.EventHelper.RemoveEventHandler<global::Com.Yrkfgo.Assxqx4.IEulaListener, global::Com.Yrkfgo.Assxqx4.IEulaListenerImplementor>(
						ref weak_implementor_SetEulaListener,
						global::Com.Yrkfgo.Assxqx4.IEulaListenerImplementor.__IsEmpty,
						__v => SetEulaListener (null),
						__h => __h.ShowingEulaHandler -= value);
			}
		}

		WeakReference weak_implementor_SetEulaListener;

		global::Com.Yrkfgo.Assxqx4.IEulaListenerImplementor __CreateIEulaListenerImplementor ()
		{
			return new global::Com.Yrkfgo.Assxqx4.IEulaListenerImplementor (this);
		}
#endregion
	}
}
