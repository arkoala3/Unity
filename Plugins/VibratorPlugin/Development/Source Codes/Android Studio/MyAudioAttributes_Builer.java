package com.dos.vibratorlibrary;

import android.media.AudioAttributes;
import android.os.Build.VERSION;

public class MyAudioAttributes_Builder
{
	/* Fields */
	private static AudioAttributes.Builder builder;


	/* Methods */
	public MyAudioAttributes_Builder(AudioAttributes.Builder aab)
	{
		if(VERSION.SDK_INT<21)
			builder= null;
		else
			builder= aab;
	}
	public static AudioAttributes Build()
	{
		if(VERSION.SDK_INT<21 || builder==null)
			return null;
		else
			return builder.build();
	}
	public static MyAudioAttributes_Builder SetAllowedCapturePolicy(int capturePolicy)
	{
		if(VERSION.SDK_INT>=29 && builder!=null)
			builder= builder.setAllowedCapturePolicy(capturePolicy);

		return new MyAudioAttributes_Builder(builder);
	}
	public static MyAudioAttributes_Builder SetContentType(int contentType)
	{
		if(VERSION.SDK_INT>=21 && builder!=null)
			builder= builder.setContentType(contentType);

		return new MyAudioAttributes_Builder(builder);
	}
	public static MyAudioAttributes_Builder SetFlags(int flags)
	{
		if(VERSION.SDK_INT>=21 && builder!=null)
			builder= builder.setFlags(flags);

		return new MyAudioAttributes_Builder(builder);
	}
	public static MyAudioAttributes_Builder SetHapticChannelsMuted(boolean muted)
	{
		if(VERSION.SDK_INT>=29 && builder!=null)
			builder= builder.setHapticChannelsMuted(muted);

		return new MyAudioAttributes_Builder(builder);
	}
	public static MyAudioAttributes_Builder SetLegacyStreamType(int streamType)
	{
		if(VERSION.SDK_INT>=21 && builder!=null)
			builder= builder.setLegacyStreamType(streamType);

		return new MyAudioAttributes_Builder(builder);
	}
	public static MyAudioAttributes_Builder SetUsage(int usage)
	{
		if(VERSION.SDK_INT>=21 && builder!=null)
			builder= builder.setUsage(usage);

		return new MyAudioAttributes_Builder(builder);
	}
}