namespace ClientServerCommon
{
    using System;

    public class _ActivityTimerStatus : TypeNameContainer<_ActivityTimerStatus>
    {
        public const int End = 2;
        public const int Refresh = 4;
        public const int RewardEnd = 0x2000;
        public const int RewardStart = 0x1000;
        public const int Start = 1;
        public const int Unknown = 0;

        public static bool Initialize()
        {
            bool flag = false;
            flag &= TypeNameContainer<_ActivityTimerStatus>.RegisterType("Start", 1);
            flag &= TypeNameContainer<_ActivityTimerStatus>.RegisterType("End", 2);
            flag &= TypeNameContainer<_ActivityTimerStatus>.RegisterType("Refresh", 4);
            flag &= TypeNameContainer<_ActivityTimerStatus>.RegisterType("RewardStart", 0x1000);
            return (flag & TypeNameContainer<_ActivityTimerStatus>.RegisterType("RewardEnd", 0x2000));
        }
    }
}

