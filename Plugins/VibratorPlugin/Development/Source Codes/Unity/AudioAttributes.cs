using System;
using UnityEngine;

public static class AudioAttributes
{
	/* Constants */
	public static int ALLOW_CAPTURE_BY_ALL= 1;
	public static int ALLOW_CAPTURE_BY_NONE= 3;
	public static int ALLOW_CAPTURE_BY_SYSTEM= 2;
	public static int CONTENT_TYPE_MOVIE= 3;
	public static int CONTENT_TYPE_MUSIC= 2;
	public static int CONTENT_TYPE_SONIFICATION= 4;
	public static int CONTENT_TYPE_SPEECH= 1;
	public static int CONTENT_TYPE_UNKNOWN= 0;
	public static int FLAG_AUDIBILITY_ENFORCED= 1;
	public static int FLAG_HW_AV_SYNC= 16;
	public static int FLAG_LOW_LATENCY= 256;
	public static int USAGE_ALARM= 4;
	public static int USAGE_ASSISTANCE_ACCESSIBILITY= 11;
	public static int USAGE_ASSISTANCE_NAVIGATION_GUIDANCE= 12;
	public static int USAGE_ASSISTANCE_SONIFICATION= 13;
	public static int USAGE_ASSISTANT= 16;
	public static int USAGE_GAME= 14;
	public static int USAGE_MEDIA= 1;
	public static int USAGE_NOTIFICATION= 5;
	public static int USAGE_NOTIFICATION_COMMUNICATION_DELAYED= 9;
	public static int USAGE_NOTIFICATION_COMMUNICATION_INSTANT= 8;
	public static int USAGE_NOTIFICATION_COMMUNICATION_REQUEST= 7;
	public static int USAGE_NOTIFICATION_EVENT= 10;
	public static int USAGE_NOTIFICATION_RINGTONE= 6;
	public static int USAGE_UNKNOWN= 0;
	public static int USAGE_VOICE_COMMUNICATION= 2;
	public static int USAGE_VOICE_COMMUNICATION_SIGNALLING= 3;


	/* Fields */
	#if UNITY_ANDROID
		private static AndroidJavaClass audioAttributesClass= new AndroidJavaClass("com.dos.vibratorlibrary.MyAudioAttributes");
	#endif


	/* Methods */
	private static bool IsAndroid()
	{
		#if UNITY_ANDROID
			return true;
		#else
			return false;
		#endif
	}

	public static Builder Builder()
	{
		if(IsAndroid())
			return new Builder(new AndroidJavaClass("com.dos.vibratorlibrary.MyAudioAttributes").CallStatic<AndroidJavaObject>("Builder"));
		else
			return null;
	}

	//Builder Builder(AudioAttributes aa) or Builder Builder(AudioAttributes.Builder aab)
	public static Builder Builder(AndroidJavaObject ajo)
	{
		if(IsAndroid())
			return new Builder(new AndroidJavaClass("com.dos.vibratorlibrary.MyAudioAttributes").CallStatic<AndroidJavaObject>("Builder", new object[] { ajo }));
		else
			return null;
	}
}

public class Builder
{
	/* Fields */
	#if UNITY_ANDROID
		private static AndroidJavaObject builder;
	#endif

	public Builder(AndroidJavaObject _builder) { builder= _builder; }


	/* Methods */
	private static bool IsAndroid()
	{
		#if UNITY_ANDROID
			return true;
		#else
			return false;
		#endif
	}

	// AudioAttributes Build()
	public AndroidJavaObject Build()
	{
		if(IsAndroid() && builder!=null)
			return builder.CallStatic<AndroidJavaObject>("Build");
		else
			return null;
	}

	public Builder SetAllowedCapturePolicy(int capturePolicy)
	{
		if(IsAndroid() && builder!=null)
			builder= builder.CallStatic<AndroidJavaObject>("SetAllowedCapturePolicy", new object[] { capturePolicy });

		return new Builder(builder);
	}

	public Builder SetContentType(int contentType)
	{
		if(IsAndroid() && builder!=null)
			builder= builder.CallStatic<AndroidJavaObject>("SetContentType", new object[] { contentType });

		return new Builder(builder);
	}

	public Builder SetFlags(int flags)
	{
		if(IsAndroid() && builder!=null)
			builder= builder.CallStatic<AndroidJavaObject>("SetFlags", new object[] { flags });

		return new Builder(builder);
	}

	public Builder SetHapticChannelsMuted(bool muted)
	{
		if(IsAndroid() && builder!=null)
			builder= builder.CallStatic<AndroidJavaObject>("SetHapticChannelsMuted", new object[] { muted });

		return new Builder(builder);
	}

	public Builder SetLegacyStreamType(int streamType)
	{
		if(IsAndroid() && builder!=null)
			builder= builder.CallStatic<AndroidJavaObject>("SetLegacyStreamType", new object[] { streamType });

		return new Builder(builder);
	}

	public Builder SetUsage(int usage)
	{
		if(IsAndroid() && builder!=null)
			builder= builder.CallStatic<AndroidJavaObject>("SetUsage", new object[] { usage });

		return new Builder(builder);
	}
}