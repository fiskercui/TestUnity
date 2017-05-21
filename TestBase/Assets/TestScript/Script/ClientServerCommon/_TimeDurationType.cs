namespace ClientServerCommon
{
    using System;

    public class _TimeDurationType : TypeNameContainer<_TimeDurationType>
    {
        public const int Day = 4;
        public const int Era = 1;
        public const int Hour = 5;
        public const int Minute = 6;
        public const int Month = 3;
        public const int Second = 7;
        public const int Unknown = 0;
        public const int Week = 8;
        public const int Year = 2;

        public static bool Initialize()
        {
            bool flag = false;
            flag &= TypeNameContainer<_TimeDurationType>.RegisterType("Era", 1);
            flag &= TypeNameContainer<_TimeDurationType>.RegisterType("Year", 2);
            flag &= TypeNameContainer<_TimeDurationType>.RegisterType("Month", 3);
            flag &= TypeNameContainer<_TimeDurationType>.RegisterType("Day", 4);
            flag &= TypeNameContainer<_TimeDurationType>.RegisterType("Hour", 5);
            flag &= TypeNameContainer<_TimeDurationType>.RegisterType("Minute", 6);
            flag &= TypeNameContainer<_TimeDurationType>.RegisterType("Second", 7);
            return (flag & TypeNameContainer<_TimeDurationType>.RegisterType("Week", 8));
        }
    }
}

