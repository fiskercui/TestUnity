namespace ClientServerCommon
{
    using System;

    public class _FCRankType : TypeNameContainer<_FCRankType>
    {
        public const int CurrentPeriod = 1;
        public const int LastPeriod = 2;
        public const int Unkonw = 0;

        public static bool Initialize()
        {
            bool flag = false;
            flag &= TypeNameContainer<_FCRankType>.RegisterType("Unkonw", 0);
            flag &= TypeNameContainer<_FCRankType>.RegisterType("CurrentPeriod", 1);
            return (flag & TypeNameContainer<_FCRankType>.RegisterType("LastPeriod", 2));
        }
    }
}

