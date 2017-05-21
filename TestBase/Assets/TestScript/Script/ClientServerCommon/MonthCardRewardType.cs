namespace ClientServerCommon
{
    using System;

    public class MonthCardRewardType : TypeNameContainer<MonthCardRewardType>
    {
        public const int BuyReward = 2;
        public const int DailyReward = 3;
        public const int OneByOne = 4;
        public const int TenTimesReward = 1;
        public const int Unknown = 0;

        public static bool Initialize()
        {
            bool flag = false;
            flag &= TypeNameContainer<MonthCardRewardType>.RegisterType("BuyReward", 2);
            flag &= TypeNameContainer<MonthCardRewardType>.RegisterType("TenTimesReward", 1);
            flag &= TypeNameContainer<MonthCardRewardType>.RegisterType("DailyReward", 3);
            return (flag & TypeNameContainer<MonthCardRewardType>.RegisterType("OneByOne", 4));
        }
    }
}

