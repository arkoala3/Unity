package com.dos.vibratorlibrary;

import android.media.AudioAttributes;
import android.os.Build.VERSION;

public class MyAudioAttributes
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


	/* Methods */
	public static MyAudioAttributes_Builder Builder()
	{
		if(VERSION.SDK_INT<21)
			return null;
		else
			return new MyAudioAttributes_Builder(new AudioAttributes.Builder());
	}
	public static MyAudioAttributes_Builder Builder(AudioAttributes aa)
	{
		if(VERSION.SDK_INT<21)
			return null;
		else
			return new MyAudioAttributes_Builder(new AudioAttributes.Builder(aa));
	}
	public static MyAudioAttributes_Builder Builder(AudioAttributes.Builder aab)
	{
		if(VERSION.SDK_INT<21)
			return null;
		else
			return new MyAudioAttributes_Builder(aab);
	}
}