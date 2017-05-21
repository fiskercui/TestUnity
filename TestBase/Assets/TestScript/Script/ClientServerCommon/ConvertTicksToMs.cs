namespace ClientServerCommon
{
    using System;
    using System.Globalization;

    public class ConvertTicksToMs
    {
        public static long DateTimeToInt64(DateTime dateTime)
        {
            DateTime time = new DateTime(0x7b2, 1, 1, 0, 0, 0, 0, new GregorianCalendar(), DateTimeKind.Utc);
            return ((dateTime.Ticks - time.Ticks) / 0x2710L);
        }
    }
}

