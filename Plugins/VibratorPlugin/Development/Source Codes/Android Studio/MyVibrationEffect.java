package com.dos.vibratorlibrary;

import android.os.VibrationEffect;
import android.os.Build.VERSION;

public class MyVibrationEffect
{
	/* Constants */
	public static int DEFAULT_AMPLITUDE= -1;
	public static int EFFECT_CLICK= 0;
	public static int EFFECT_DOUBLE_CLICK= 1;
	public static int EFFECT_HEAVY_CLICK= 5;
	public static int EFFECT_TICK= 2;


	/* Methods */
	public static VibrationEffect CreateOneShot(long milliseconds, int amplitude)
	{
		if(VERSION.SDK_INT<26)
			return null;
		else
			return VibrationEffect.createOneShot(milliseconds, amplitude);
	}
	public static VibrationEffect CreatePredefined(int effectId)
	{
		if(VERSION.SDK_INT<29)
			return null;
		else
			return VibrationEffect.createPredefined(effectId);
	}
	public static VibrationEffect CreateWaveform(long[] timings, int[] amplitudes, int repeat)
	{
		if(VERSION.SDK_INT<26)
			return null;
		else
			return VibrationEffect.createWaveform(timings, amplitudes, repeat);
	}
	public static VibrationEffect CreateWaveform(long[] timings, int repeat)
	{
		if(VERSION.SDK_INT<26)
			return null;
		else
			return VibrationEffect.createWaveform(timings, repeat);
	}
}