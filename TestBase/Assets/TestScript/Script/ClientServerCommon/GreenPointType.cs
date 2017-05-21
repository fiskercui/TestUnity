namespace ClientServerCommon
{
    using System;

    public class GreenPointType : TypeNameContainer<GreenPointType>
    {
        public const int FixedTimeActivity = -4;
        public const int GuildConstruction = -9;
        public const int InviteCodeReward = -10;
        public const int LevelRewardActivity = -3;
        public const int MonthCardFeedBack = -5;
        public const int MySteryer = -7;
        public const int QinInfo = -2;
        public const int RunActivityAccumulative = -6;
        public const int SEVENELEVENGIFT = -11;
        public const int UnKnow = -1;
        public const int ZentiaServerReward = -8;

        public static bool Initialize()
        {
            bool flag = false;
            flag &= TypeNameContainer<GreenPointType>.RegisterType("UnKnow", -1);
            flag &= TypeNameContainer<GreenPointType>.RegisterType("QinInfo", -2);
            flag &= TypeNameContainer<GreenPointType>.RegisterType("LevelRewardActivity", -3);
            flag &= TypeNameContainer<GreenPointType>.RegisterType("FixedTimeActivity", -4);
            flag &= TypeNameContainer<GreenPointType>.RegisterType("MonthCardFeedBack", -5);
            flag &= TypeNameContainer<GreenPointType>.RegisterType("RunActivityAccumulative", -6);
            flag &= TypeNameContainer<GreenPointType>.RegisterType("MySteryer", -7);
            flag &= TypeNameContainer<GreenPointType>.RegisterType("InviteCodeReward", -10);
            flag &= TypeNameContainer<GreenPointType>.RegisterType("SEVENELEVENGIFT", -11);
            flag &= TypeNameContainer<GreenPointType>.RegisterType("ZentiaServerReward", -8);
            return (flag & TypeNameContainer<GreenPointType>.RegisterType("GuildConstruction", -9));
        }
    }
}

