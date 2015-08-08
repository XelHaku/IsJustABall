package mono.com.yrkfgo.assxqx4;


public class EulaListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.yrkfgo.assxqx4.EulaListener
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_optinResult:(Z)V:GetOptinResult_ZHandler:Com.Yrkfgo.Assxqx4.IEulaListenerInvoker, BundleSdkLib\n" +
			"n_showingEula:()V:GetShowingEulaHandler:Com.Yrkfgo.Assxqx4.IEulaListenerInvoker, BundleSdkLib\n" +
			"";
		mono.android.Runtime.register ("Com.Yrkfgo.Assxqx4.IEulaListenerImplementor, BundleSdkLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", EulaListenerImplementor.class, __md_methods);
	}


	public EulaListenerImplementor () throws java.lang.Throwable
	{
		super ();
		if (getClass () == EulaListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Yrkfgo.Assxqx4.IEulaListenerImplementor, BundleSdkLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void optinResult (boolean p0)
	{
		n_optinResult (p0);
	}

	private native void n_optinResult (boolean p0);


	public void showingEula ()
	{
		n_showingEula ();
	}

	private native void n_showingEula ();

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
