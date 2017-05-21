namespace ClientServerCommon
{
    using System;

    public class _MelaleucaLimitType : TypeNameContainer<_MelaleucaLimitType>
    {
        public const int DayLayer = 2;
        public const int DayPoint = 1;
        public const int LastWeekPoint = 5;
        public const int LastWeekrank = 4;
        public const int UnKnow = 0;
        public const int WeekPoint = 3;

        public static bool Initialize()
        {
            bool flag = false;
            flag &= TypeNameContainer<_MelaleucaLimitType>.RegisterType("DayPoint", 1);
            flag &= TypeNameContainer<_MelaleucaLimitType>.RegisterType("DayLayer", 2);
            flag &= TypeNameContainer<_MelaleucaLimitType>.RegisterType("WeekPoint", 3);
            flag &= TypeNameContainer<_MelaleucaLimitType>.RegisterType("LastWeekrank", 4);
            return (flag & TypeNameContainer<_MelaleucaLimitType>.RegisterType("LastWeekPoint", 5));
        }
    }
}

