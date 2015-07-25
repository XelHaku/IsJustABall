package mono.com.yrkfgo.assxqx4;


public class AdListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.yrkfgo.assxqx4.AdListener
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_noAdListener:()V:GetNoAdListenerHandler:Com.Yrkfgo.Assxqx4.IAdListenerInvoker, BundleSdkLib\n" +
			"n_onAdCached:(Lcom/yrkfgo/assxqx4/AdConfig$AdType;)V:GetOnAdCached_Lcom_yrkfgo_assxqx4_AdConfig_AdType_Handler:Com.Yrkfgo.Assxqx4.IAdListenerInvoker, BundleSdkLib\n" +
			"n_onAdClickedListener:()V:GetOnAdClickedListenerHandler:Com.Yrkfgo.Assxqx4.IAdListenerInvoker, BundleSdkLib\n" +
			"n_onAdClosed:()V:GetOnAdClosedHandler:Com.Yrkfgo.Assxqx4.IAdListenerInvoker, BundleSdkLib\n" +
			"n_onAdError:(Ljava/lang/String;)V:GetOnAdError_Ljava_lang_String_Handler:Com.Yrkfgo.Assxqx4.IAdListenerInvoker, BundleSdkLib\n" +
			"n_onAdExpandedListner:()V:GetOnAdExpandedListnerHandler:Com.Yrkfgo.Assxqx4.IAdListenerInvoker, BundleSdkLib\n" +
			"n_onAdLoadedListener:()V:GetOnAdLoadedListenerHandler:Com.Yrkfgo.Assxqx4.IAdListenerInvoker, BundleSdkLib\n" +
			"n_onAdLoadingListener:()V:GetOnAdLoadingListenerHandler:Com.Yrkfgo.Assxqx4.IAdListenerInvoker, BundleSdkLib\n" +
			"n_onAdShowing:()V:GetOnAdShowingHandler:Com.Yrkfgo.Assxqx4.IAdListenerInvoker, BundleSdkLib\n" +
			"n_onCloseListener:()V:GetOnCloseListenerHandler:Com.Yrkfgo.Assxqx4.IAdListenerInvoker, BundleSdkLib\n" +
			"n_onIntegrationError:(Ljava/lang/String;)V:GetOnIntegrationError_Ljava_lang_String_Handler:Com.Yrkfgo.Assxqx4.IAdListenerInvoker, BundleSdkLib\n" +
			"";
		mono.android.Runtime.register ("Com.Yrkfgo.Assxqx4.IAdListenerImplementor, BundleSdkLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", AdListenerImplementor.class, __md_methods);
	}


	public AdListenerImplementor () throws java.lang.Throwable
	{
		super ();
		if (getClass () == AdListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Yrkfgo.Assxqx4.IAdListenerImplementor, BundleSdkLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void noAdListener ()
	{
		n_noAdListener ();
	}

	private native void n_noAdListener ();


	public void onAdCached (com.yrkfgo.assxqx4.AdConfig.AdType p0)
	{
		n_onAdCached (p0);
	}

	private native void n_onAdCached (com.yrkfgo.assxqx4.AdConfig.AdType p0);


	public void onAdClickedListener ()
	{
		n_onAdClickedListener ();
	}

	private native void n_onAdClickedListener ();


	public void onAdClosed ()
	{
		n_onAdClosed ();
	}

	private native void n_onAdClosed ();


	public void onAdError (java.lang.String p0)
	{
		n_onAdError (p0);
	}

	private native void n_onAdError (java.lang.String p0);


	public void onAdExpandedListner ()
	{
		n_onAdExpandedListner ();
	}

	private native void n_onAdExpandedListner ();


	public void onAdLoadedListener ()
	{
		n_onAdLoadedListener ();
	}

	private native void n_onAdLoadedListener ();


	public void onAdLoadingListener ()
	{
		n_onAdLoadingListener ();
	}

	private native void n_onAdLoadingListener ();


	public void onAdShowing ()
	{
		n_onAdShowing ();
	}

	private native void n_onAdShowing ();


	public void onCloseListener ()
	{
		n_onCloseListener ();
	}

	private native void n_onCloseListener ();


	public void onIntegrationError (java.lang.String p0)
	{
		n_onIntegrationError (p0);
	}

	private native void n_onIntegrationError (java.lang.String p0);

	java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
