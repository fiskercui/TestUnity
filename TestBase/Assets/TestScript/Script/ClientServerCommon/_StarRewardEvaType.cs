namespace ClientServerCommon
{
    using System;

    public class _StarRewardEvaType : TypeNameContainer<_StarRewardEvaType>
    {
        public const int AvatarCountLeft = 4;
        public const int AvatarHpLeft = 3;
        public const int NpcCountLeft = 5;
        public const int Pass = 1;
        public const int RoundCount = 2;
        public const int Unkonw = 0;

        public static bool Initialize()
        {
            bool flag = false;
            flag &= TypeNameContainer<_StarRewardEvaType>.RegisterType("Pass", 1, "StarReawrd_Pass");
            flag &= TypeNameContainer<_StarRewardEvaType>.RegisterType("RoundCount", 2, "StarReawrd_RoundCount");
            flag &= TypeNameContainer<_StarRewardEvaType>.RegisterType("AvatarHpLeft", 3, "StarReawrd_AvatarHpLeft");
            flag &= TypeNameContainer<_StarRewardEvaType>.RegisterType("AvatarCountLeft", 4, "StarReawrd_AvatarCountLeft");
            return (flag & TypeNameContainer<_StarRewardEvaType>.RegisterType("NpcCountLeft", 5, "StarReawrd_NpcCountLeft"));
        }
    }
}

