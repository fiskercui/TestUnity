namespace ClientServerCommon
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Text;

    public static class StrParser
    {
        private static CultureInfo provider = CultureInfo.InvariantCulture;
        public static readonly string[,] spcChars = new string[,] { { "#quot#", "\"" }, { "#lt#", "<" }, { "#gt#", ">" }, { "#amp#", "&" }, { "#apos#", "'" }, { @"\n", "\n" } };
        public static readonly char[] splitter = new char[] { ',' };

        public static long DateTimeToInt64(DateTime dateTime)
        {
            DateTime time = new DateTime(0x7b2, 1, 1, 0, 0, 0, 0, new GregorianCalendar(), DateTimeKind.Utc);
            return ((dateTime.Ticks - time.Ticks) / 0x2710L);
        }

        public static string GetTextWithoutBOM(byte[] bytes)
        {
            MemoryStream stream = new MemoryStream(bytes);
            StreamReader reader = new StreamReader(stream, true);
            string str = reader.ReadToEnd();
            reader.Close();
            stream.Close();
            return str;
        }

        public static string Null2Empty(string str)
        {
            if (str != null)
            {
                return str;
            }
            return "";
        }

        public static bool ParseBool(string str, bool defVal)
        {
            if (!string.IsNullOrEmpty(str))
            {
                bool flag;
                if (bool.TryParse(str, out flag))
                {
                    return flag;
                }
                Logger.Error(string.Format("Invalid parameter when parsing Bool value : {0}", str), new object[0]);
            }
            return defVal;
        }

        public static long ParseDateTime(string str)
        {
            DateTime time;
            long num = DateTime.MinValue.Ticks / 0x2710L;
            if (str == null)
            {
                return num;
            }
            if (!DateTime.TryParse(str, provider, DateTimeStyles.AdjustToUniversal, out time))
            {
                return num;
            }
            return (time.Ticks / 0x2710L);
        }

        public static long ParseDateTimeOfDay(string str, long defVal)
        {
            DateTime time;
            if (string.IsNullOrEmpty(str))
            {
                return defVal;
            }
            if (!DateTime.TryParse(str, provider, DateTimeStyles.AdjustToUniversal, out time))
            {
                Logger.Error(string.Format("Invalid parameter when parsing DateTime value : {0}", str), new object[0]);
                return defVal;
            }
            return (long) time.AddYears(1).ToUniversalTime().TimeOfDay.TotalMilliseconds;
        }

        public static int ParseDecInt(string str, int defVal)
        {
            bool flag;
            return ParseDecInt(str, defVal, out flag);
        }

        public static int ParseDecInt(string str, int defVal, out bool tf)
        {
            return (int) Math.Round((double) ParseFloat(str, (float) defVal, out tf));
        }

        public static int ParseDecIntEx(string str, int defVal)
        {
            bool flag;
            return ParseDecIntEx(str, defVal, out flag);
        }

        public static int ParseDecIntEx(string str, int defVal, out bool tf)
        {
            tf = false;
            if (!string.IsNullOrEmpty(str))
            {
                int num;
                if (tf = int.TryParse(str, NumberStyles.Integer, provider, out num))
                {
                    return num;
                }
                Logger.Error(string.Format("Invalid parameter when parsing DecInt value : {0}", str), new object[0]);
            }
            return defVal;
        }

        public static List<int> ParseDecIntList(string str, int defVal)
        {
            List<int> list = new List<int>();
            if (str != null)
            {
                string[] strArray = str.Split(splitter);
                for (int i = 0; i < strArray.Length; i++)
                {
                    list.Add(ParseDecInt(strArray[i], defVal));
                }
            }
            return list;
        }

        public static long ParseDecLong(string str, long defVal)
        {
            if (!string.IsNullOrEmpty(str))
            {
                long num;
                if (long.TryParse(str, NumberStyles.Integer, provider, out num))
                {
                    return num;
                }
                Logger.Error(string.Format("Invalid parameter when parsing DecLong value : {0}", str), new object[0]);
            }
            return defVal;
        }

        public static uint ParseDecUInt(string str, uint defVal)
        {
            if (!string.IsNullOrEmpty(str))
            {
                uint num;
                if (uint.TryParse(str, NumberStyles.Integer, provider, out num))
                {
                    return num;
                }
                Logger.Error(string.Format("Invalid parameter when parsing DecUInt value : {0}", str), new object[0]);
            }
            return defVal;
        }

        public static ulong ParseDecULong(string str, ulong defVal)
        {
            if (!string.IsNullOrEmpty(str))
            {
                ulong num;
                if (ulong.TryParse(str, NumberStyles.Integer, provider, out num))
                {
                    return num;
                }
                Logger.Error(string.Format("Invalid parameter when parsing DecULong value : {0}", str), new object[0]);
            }
            return defVal;
        }

        public static double ParseDouble(string str, double defVal)
        {
            if (!string.IsNullOrEmpty(str))
            {
                double result = 0.0;
                if (double.TryParse(str, out result))
                {
                    return result;
                }
                Logger.Error(string.Format("Invalid parameter when parsing Double value : {0}", str), new object[0]);
            }
            return defVal;
        }

        public static T ParseEnum<T>(string val, T defVal) where T: struct
        {
            Type type = typeof(T);
            try
            {
                if (!type.IsEnum)
                {
                    Logger.Error(string.Format("'{0}' is not enum type.", type), new object[0]);
                    return defVal;
                }
                return (T) Enum.Parse(type, val, true);
            }
            catch
            {
                if (val != "")
                {
                    Logger.Error(string.Format("'{0}' is not value of {1}.", val, type), new object[0]);
                }
                return defVal;
            }
        }

        public static int ParseEnum(string str, int defVal, string[] enumVals)
        {
            if ((enumVals != null) && (str != null))
            {
                for (int i = 0; i < enumVals.Length; i++)
                {
                    if (str == enumVals[i])
                    {
                        return i;
                    }
                }
            }
            return defVal;
        }

        public static string ParseEnumFullStr(int val, string[] enumVals, string enumName)
        {
            return (enumName + "." + ParseEnumStr(val, enumVals));
        }

        public static List<T> ParseEnumList<T>(string str, T defVal) where T: struct
        {
            List<T> list = new List<T>();
            if (str != null)
            {
                string[] strArray = str.Split(splitter);
                for (int i = 0; i < strArray.Length; i++)
                {
                    list.Add(ParseEnum<T>(strArray[i], defVal));
                }
            }
            return list;
        }

        public static List<int> ParseEnumList(string str, int defVal, string[] enumVals)
        {
            List<int> list = new List<int>();
            if (str != null)
            {
                string[] strArray = str.Split(splitter);
                for (int i = 0; i < strArray.Length; i++)
                {
                    list.Add(ParseEnum(strArray[i], defVal, enumVals));
                }
            }
            return list;
        }

        public static string ParseEnumStr(int val, string[] enumVals)
        {
            if (((enumVals != null) && (val >= 0)) && (val < enumVals.Length))
            {
                return enumVals[val];
            }
            return "";
        }

        public static float ParseFloat(string str, float defVal)
        {
            bool flag;
            return ParseFloat(str, defVal, out flag);
        }

        public static float ParseFloat(string str, float defVal, out bool tf)
        {
            tf = false;
            if (!string.IsNullOrEmpty(str))
            {
                float result = 0f;
                if (tf = float.TryParse(str, out result))
                {
                    return result;
                }
                Logger.Error(string.Format("Invalid parameter when parsing Float value : {0}", str), new object[0]);
            }
            return defVal;
        }

        public static List<float> ParseFloatList(string str, float defVal)
        {
            List<float> list = new List<float>();
            if (str != null)
            {
                string[] strArray = str.Split(splitter);
                for (int i = 0; i < strArray.Length; i++)
                {
                    list.Add(ParseFloat(strArray[i], defVal));
                }
            }
            return list;
        }

        public static int ParseHexInt(string str, int defVal)
        {
            if (!string.IsNullOrEmpty(str))
            {
                int num;
                if (int.TryParse(str, NumberStyles.HexNumber, provider, out num))
                {
                    return num;
                }
                Logger.Error(string.Format("Invalid parameter when parsing HexInt value : {0}", str), new object[0]);
            }
            return defVal;
        }

        public static List<int> ParseHexIntList(string str, int defVal)
        {
            List<int> list = new List<int>();
            if (str != null)
            {
                string[] strArray = str.Split(splitter);
                for (int i = 0; i < strArray.Length; i++)
                {
                    list.Add(ParseHexInt(strArray[i], defVal));
                }
            }
            return list;
        }

        public static long ParseHexLong(string str, long defVal)
        {
            if (!string.IsNullOrEmpty(str))
            {
                long num;
                if (long.TryParse(str, NumberStyles.HexNumber, provider, out num))
                {
                    return num;
                }
                Logger.Error(string.Format("Invalid parameter when parsing HexLong value : {0}", str), new object[0]);
            }
            return defVal;
        }

        public static string ParseStr(string str, string defValue)
        {
            if (str != null)
            {
                return str;
            }
            return defValue;
        }

        public static string ParseStr(string str, string defValue, bool prcSpcChar)
        {
            if (str == null)
            {
                return defValue;
            }
            if (!prcSpcChar)
            {
                return str;
            }
            StringBuilder builder = new StringBuilder(str);
            for (int i = 0; i < spcChars.GetLength(0); i++)
            {
                builder.Replace(spcChars[i, 0], spcChars[i, 1]);
            }
            return builder.ToString();
        }

        public static DateTime ToLocalDataTime(long time)
        {
            DateTime time2 = new DateTime(0x7b2, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return time2.AddMilliseconds((double) time).ToLocalTime();
        }

        public static DateTime ToUTCDateTime(long time)
        {
            DateTime time2 = new DateTime(0x7b2, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return time2.AddMilliseconds((double) time);
        }
    }
}

