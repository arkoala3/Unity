using System;
using UnityEngine;

public static class VibrationEffect
{
	/* Fields */
	#if UNITY_ANDROID
		private static AndroidJavaObject vibrationEffectClass= new AndroidJavaClass("com.dos.vibratorlibrary.MyVibrationEffect");
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

	// VibrationEffect CreateOneShot(long milliseconds, int amplitude)
	public static AndroidJavaObject CreateOneShot(long milliseconds, int amplitude)
	{
		if(IsAndroid())
			return vibrationEffectClass.CallStatic<AndroidJavaObject>("CreateOneShot", new object[] { milliseconds, amplitude });
		else
			return null;
	}

	// VibrationEffect CreatePredefined(int effectId)
	public static AndroidJavaObject CreatePredefined(int effectId)
	{
		if(IsAndroid())
			return vibrationEffectClass.CallStatic<AndroidJavaObject>("CreatePredefined", new object[] { effectId });
		else
			return null;
	}

	// VibrationEffect CreateWaveform(long[] timings, int[] amplitudes, int repeat)
	public static AndroidJavaObject CreateWaveform(long[] timings, int[] amplitudes, int repeat)
	{
		if(IsAndroid())
			return vibrationEffectClass.CallStatic<AndroidJavaObject>("CreateWaveform", new object[] { timings, amplitudes, repeat });
		else
			return null;
	}

	// VibrationEffect CreateWaveform(long[] timings, int repeat)
	public static AndroidJavaObject CreateWaveform(long[] timings, int repeat)
	{
		if(IsAndroid())
			return vibrationEffectClass.CallStatic<AndroidJavaObject>("CreateWaveform", new object[] { timings, repeat });
		else
			return null;
	}
}
