package com.dos.vibratorlibrary;

import android.app.Activity;
import android.content.Context;
import android.os.Vibrator;
import android.os.VibrationEffect;
import android.media.AudioAttributes;
import android.os.Build.VERSION;

public class MyVibrator
{
	/* Fields */
	private static Vibrator vibrator;
	private static VibrationEffect vibrationEffect;


	/* Methods */
	public MyVibrator(Vibrator vibrator) { this.vibrator= vibrator; }

	public static void Cancel() { vibrator.cancel(); }
	public static boolean HasAmplitudeControl()
	{
		if(VERSION.SDK_INT<26)
			return false;
		else
			return vibrator.hasAmplitudeControl();
	}
	public static boolean HasVibrator()
	{
		if(VERSION.SDK_INT<11)
			return false;
		else
			return vibrator.hasVibrator();
	}
	public static void Vibrate(long milliseconds)
	{
		if(VERSION.SDK_INT<26)
			vibrator.vibrate(milliseconds);
		else if((vibrationEffect= MyVibrationEffect.CreateOneShot(milliseconds, MyVibrationEffect.DEFAULT_AMPLITUDE))!=null)
			vibrator.vibrate(vibrationEffect);
	}
	public static void Vibrate(VibrationEffect vibe)
	{
		if(VERSION.SDK_INT>=26 && vibe!=null)
			vibrator.vibrate(vibe);
	}
	public static void Vibrate(long[] pattern, int repeat)
	{
		if(VERSION.SDK_INT<26)
			vibrator.vibrate(pattern, repeat);
		else if((vibrationEffect= MyVibrationEffect.CreateWaveform(pattern, repeat))!=null)
			vibrator.vibrate(vibrationEffect);
	}
	public static void Vibrate(long[] pattern, int repeat, AudioAttributes attributes)
	{
		if(21<=VERSION.SDK_INT && VERSION.SDK_INT<26)
			vibrator.vibrate(pattern, repeat, attributes);
		else if(VERSION.SDK_INT>=26 && (vibrationEffect= MyVibrationEffect.CreateWaveform(pattern, repeat))!=null)
		{
			if(attributes!=null)
				vibrator.vibrate(vibrationEffect, attributes);
			else
				vibrator.vibrate(vibrationEffect);
		}
	}
	public static void Vibrate(VibrationEffect vibe, AudioAttributes attributes)
	{
		if(VERSION.SDK_INT>=26 && vibe!=null)
		{
			if(attributes!=null)
				vibrator.vibrate(vibe, attributes);
			else
				vibrator.vibrate(vibe);
		}
	}
	public static void Vibrate(long milliseconds, AudioAttributes attributes)
	{
		if(21<=VERSION.SDK_INT && VERSION.SDK_INT<26)
			vibrator.vibrate(milliseconds, attributes);
		else if(VERSION.SDK_INT>=26 && (vibrationEffect= MyVibrationEffect.CreateOneShot(milliseconds, MyVibrationEffect.DEFAULT_AMPLITUDE))!=null)
		{
			if(attributes!=null)
				vibrator.vibrate(vibrationEffect, attributes);
			else
				vibrator.vibrate(vibrationEffect);
		}
	}
}