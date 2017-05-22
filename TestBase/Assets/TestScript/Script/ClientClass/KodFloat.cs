namespace WeihuaGames.ClientClass
{
    using System;

    public class KodFloat
    {
        public static long identity = 0x2710L;

        public static long floatToLong(float v)
        {
            return (long) (v * identity);
        }

        public static float longToFloat(long v)
        {
            double num = v;
            return (float) (num / ((double) identity));
        }
    }
}

