using UnityEngine;
using System;
using System.Text;
using System.Collections.Generic;
using ClientServerCommon;

public static class GameUtility
{
	public static WeihuaGames.ClientClass.DeviceInfo GetDeviceInfo()
	{
        WeihuaGames.ClientClass.DeviceInfo deviceInfo = new WeihuaGames.ClientClass.DeviceInfo();
#if UNITY_IPHONE		
		if (Application.platform == RuntimePlatform.IPhonePlayer)
			deviceInfo.DeviceType = _DeviceType.iPhone;
#elif UNITY_ANDROID
		//if (Application.platform == RuntimePlatform.Android)
		//	deviceInfo.DeviceType = _DeviceType.Android;
#endif
		deviceInfo.OsType = WeihuaGames.ExternalCall.DevicePlugin.GetSystemName();
		deviceInfo.OsVersion = WeihuaGames.ExternalCall.DevicePlugin.GetSystemVersion();
        deviceInfo.Udid = "DefaultUDID"; //Platform.Instance.GetUDID();
		deviceInfo.DeviceName = WeihuaGames.ExternalCall.DevicePlugin.GetDeviceName();
		return deviceInfo;
	}

	#region 字符串处理
	public static string AppendString(string old, string pending, bool newLine)
	{
		if (string.IsNullOrEmpty(pending))
			return old;

		if (string.IsNullOrEmpty(old))
		{
			old = pending;
		}
		else
		{
			if (newLine)
				old += "\n";
			old += pending;
		}

		return old;
	}

	public static string FormatStringOnlyWithParams(string strToFormat, object[] canToStringObjs)
	{
		if (string.IsNullOrEmpty(strToFormat) || canToStringObjs == null || canToStringObjs.Length == 0)
			return strToFormat;

		string strUsedToReplace = "{0}";
		for (int paramIndex = 0; paramIndex < canToStringObjs.Length; paramIndex++)
		{
			strUsedToReplace = strUsedToReplace.Replace(strUsedToReplace.Substring(1, strUsedToReplace.Length - 2), paramIndex.ToString());

			if (strToFormat.Contains(strUsedToReplace))
				strToFormat = strToFormat.Replace(strUsedToReplace, canToStringObjs[paramIndex].ToString());
			else break;
		}
		return strToFormat;
	}

#if UNITY_EDITOR || UNITY_IPHONE
	public static UnityEngine.iOS.CalendarUnit TimeDurationType2CalendarUnit(int timeDurationType)
	{
		switch (timeDurationType)
		{
			case _TimeDurationType.Era: return UnityEngine.iOS.CalendarUnit.Era;
			case _TimeDurationType.Year: return UnityEngine.iOS.CalendarUnit.Year;
			case _TimeDurationType.Month: return UnityEngine.iOS.CalendarUnit.Month;
			case _TimeDurationType.Day: return UnityEngine.iOS.CalendarUnit.Day;
			case _TimeDurationType.Hour: return UnityEngine.iOS.CalendarUnit.Hour;
			case _TimeDurationType.Minute: return UnityEngine.iOS.CalendarUnit.Minute;
			case _TimeDurationType.Second: return UnityEngine.iOS.CalendarUnit.Second;
			case _TimeDurationType.Week: return UnityEngine.iOS.CalendarUnit.Week;
			default: return UnityEngine.iOS.CalendarUnit.Day;
		}
	}
#endif

	public static string Time2String(long time)
	{
		long second = time / 1000 % 60;
		long minute = time / 1000 / 60 % 60;
		long hour = time / 1000 / 60 / 60 % 24;
		long day = time / 1000 / 60 / 60 / 24;

		if (day != 0)
			return FormatUIString("UITimeFormat_Day", day, hour);
		else
			return FormatUIString("UITimeFormat_Hour", hour, minute, second);
	}

	public static bool IsTime2DownZero(long time)
	{
		long second = time / 1000 % 60;
		long minute = time / 1000 / 60 % 60;
		long hour = time / 1000 / 60 / 60 % 24;
		long day = time / 1000 / 60 / 60 / 24;
		if (day == 0 && hour == 0 && minute == 0 && second == 0)
			return true;
		return false;
	}

	public static bool EqualsFormatTimeString(string compareTo, long time)
	{
		long second = time / 1000 % 60;
		long minute = time / 1000 / 60 % 60;
		long hour = time / 1000 / 60 / 60 % 24;
		long day = time / 1000 / 60 / 60 / 24;

		if (day != 0)
			return EqualsFormatString(compareTo, GetUIString("UITimeFormat_Day"), day, hour);
		else
			return EqualsFormatString(compareTo, GetUIString("UITimeFormat_Hour"), hour, minute, second);
	}

	public static string Time2StringWithoutSecond(long time)
	{
		long minute = time / 1000 / 60 % 60;
		long hour = time / 1000 / 60 / 60;

		return string.Format("{0:D2}{2}{1:D2}{3}", hour, minute,
			ConfigDatabase.DefaultCfg.StringsConfig.GetString("UI", "UIPnlSlavePage_Time_Hour"),
			ConfigDatabase.DefaultCfg.StringsConfig.GetString("UI", "UIPnlSlavePage_Time_Minute"));
	}

	public static string TimeOfDay2StringWithoutSecond(long time)
	{
		long minute = time / 1000 / 60 % 60;
		long hour = time / 1000 / 60 / 60 % 24;

		return string.Format("{0:D2}:{1:D2}", hour, minute);
	}

	public static string EqualsFormatTimeStringWithoutThree(long time)
	{
		long hour = time / 1000 / 60 / 60;
		long minute = time / 1000 / 60 % 60;
		long second = time / 1000 % 60;

		return string.Format("{0:D2}:{1:D2}:{2:D2}", hour, minute, second);
	}

	public static string Time2SortString(long time)
	{
		// Set total work time

		if (time >= 1000 * 60 * 60 * 24 * 7)
		{
			// week
			return GameUtility.GetUIString("UITimeLeftLabel_Week");
		}
		if (time >= 1000 * 60 * 60 * 24)
		{
			// Hour
			return ((int)(time / (1000 * 60 * 60 * 24))).ToString() + GameUtility.GetUIString("UITimeLabel_Day");
		}
		if (time >= 1000 * 60 * 60)
		{
			// Hour
			return ((int)(time / (1000 * 60 * 60))).ToString() + GameUtility.GetUIString("UITimeLabel_Hour");
		}
		else if (time >= 1000 * 60)
		{
			// Minutes
			return ((int)(time / (1000 * 60))).ToString() + GameUtility.GetUIString("UITimeLabel_Minute");
		}
		else
		{
			// Second
			return (time / (1000)).ToString() + GameUtility.GetUIString("UITimeLabel_Second");
		}
	}

	public static float FloatToPercentageValue(float value)
	{
		return WeihuaGames.Math.RoundToInt(value * 1000) / 10f;
	}

	public static int FloatToPercentageInteger(float value)
	{
		return WeihuaGames.Math.RoundToInt(value * 100);
	}

	public static string FloatToPercentage(float value)
	{
		return FloatToPercentage(value, true);
	}

	public static string FloatToPercentage(float value, bool forceAddSign)
	{
		float _value = FloatToPercentageValue(value);
		//if (_value >= 0)
		//    return forceAddSign ? string.Format("+{0}%", _value) : string.Format("{0}%", _value);
		//else
		return string.Format("{0}%", _value);
	}

	public static string ToMemorySizeString(int size)
	{
		string sign = size >= 0 ? "" : "-";
		float absSize = Mathf.Abs(size);
		if (absSize < 1024)
			return string.Format("{0}{1:F0}B", sign, absSize);

		absSize /= 1024;
		if (absSize < 1024)
			return string.Format("{0}{1:F0}K", sign, absSize);

		absSize /= 1024;
		if (absSize < 1024)
			return string.Format("{0}{1:F1}M", sign, absSize);

		absSize /= 1024;
		return string.Format("{0}{1:F1}G", sign, absSize);
	}

	public static string GetUIString(string key)
	{
		return ConfigDatabase.DefaultCfg.StringsConfig.GetString(GameDefines.strBlkUI, key);
	}

	public static string FormatUIString(string key, params object[] datas)
	{
		return string.Format(GetUIString(key), datas);
	}

	private static System.Text.StringBuilder sourceSB = new System.Text.StringBuilder();
	private static System.Text.StringBuilder targetSB = new System.Text.StringBuilder();

	public static bool EqualsFormatString(string compareTo, string format, params object[] datas)
	{
		sourceSB.Length = 0;
		sourceSB.AppendFormat(format, datas);
		targetSB.Length = 0;
		targetSB.Append(compareTo);

		var sourceLength = sourceSB.Length;
		var targetLength = targetSB.Length;
		if (sourceLength != targetLength)
			return false;

		for (int i = 0; i < sourceLength; ++i)
			if (sourceSB[i] != targetSB[i])
				return false;

		return true;
	}
	#endregion


}