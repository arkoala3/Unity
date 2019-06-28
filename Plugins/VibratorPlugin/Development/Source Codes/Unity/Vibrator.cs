using System;
using UnityEngine;

public static class Vibrator
{
	/* Fields */
	#if UNITY_ANDROID
		private static AndroidJavaClass unityPlayer= new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		private static AndroidJavaObject currentActivity= unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
		private static AndroidJavaObject vibrator= new AndroidJavaObject("com.dos.vibratorlibrary.MyVibrator", currentActivity.Call<AndroidJavaObject>("getSystemService", "vibrator"));
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

	public static void Cancel()
	{
		if(IsAndroid())
			vibrator.CallStatic("Cancel");
	}

	public static bool HasAmplitudeControl()
	{
		if(IsAndroid())
			return vibrator.CallStatic<bool>("HasAmplitudeControl");
		else
			return false;
	}

	public static bool HasVibrator()
	{
		if(IsAndroid())
			return vibrator.CallStatic<bool>("HasVibrator");
		else
			return false;
	}

	public static void Vibrate(long milliseconds)
	{
		if(IsAndroid())
			vibrator.CallStatic("Vibrate", new object[] { milliseconds });
		else
			Handheld.Vibrate();
	}

	//void Vibrate(VibrationEffect vibe)
	public static void Vibrate(AndroidJavaObject vibe)
	{
		if(IsAndroid())
			vibrator.CallStatic("Vibrate", new object[] { vibe });
		else
			Handheld.Vibrate();
	}

	public static void Vibrate(long[] pattern, int repeat)
	{
		if(IsAndroid())
			vibrator.CallStatic("Vibrate", new object[] { pattern, repeat });
		else
			Handheld.Vibrate();
	}

	//void Vibrate(VibrationEffect vibe, AudioAttributes attributes)
	public static void Vibrate(AndroidJavaObject vibe, AndroidJavaObject attributes)
	{
		if(IsAndroid())
			vibrator.CallStatic("Vibrate", new object[] { vibe, attributes });
		else
			Handheld.Vibrate();
	}

	//void Vibrate(long milliseconds, AudioAttributes attributes)
	public static void Vibrate(long milliseconds, AndroidJavaObject attributes)
	{
		if(IsAndroid())
			vibrator.CallStatic("Vibrate", new object[] { milliseconds, attributes });
		else
			Handheld.Vibrate();
	}
}
