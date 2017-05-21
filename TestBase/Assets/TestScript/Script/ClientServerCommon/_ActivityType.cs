namespace ClientServerCommon
{
    using System;

    public class _ActivityType : TypeNameContainer<ClientServerCommon._ActivityType>
    {
        public const int ACCUMULATEACTIVITY = 5;
        public const int ALCHEMY = 8;
        public const int DECOMPOSE = 9;
        public const int FIRSTTHREEDAY = 13;
        public const int GETFIXTEDTIMEACTIVITY = 1;
        public const int GUILDSHOP = 10;
        public const int GUILDSTAGE = 11;
        public const int LEVLEREWARDACTIVITY = 3;
        public const int MYSTERYER = 6;
        public const int NORMALTAVERNACTIVITY = 15;
        public const int QININFOACTIVITY = 4;
        public const int SECRETACTIVIYT = 2;
        public const int SEVENELEVENGIFT = 12;
        public const int TENTAVERNACTIVITY = 14;
        public const int Unknown = 0;
        public const int ZENTIA = 7;

        public static bool Initialize()
        {
            bool flag = false;
            flag &= TypeNameContainer<ClientServerCommon._ActivityType>.RegisterType("GETFIXTEDTIMEACTIVITY", 1);
            flag &= TypeNameContainer<ClientServerCommon._ActivityType>.RegisterType("SECRETACTIVIYT", 2);
            flag &= TypeNameContainer<ClientServerCommon._ActivityType>.RegisterType("LEVLEREWARDACTIVITY", 3);
            flag &= TypeNameContainer<ClientServerCommon._ActivityType>.RegisterType("ACCUMULATEACTIVITY", 5);
            flag &= TypeNameContainer<ClientServerCommon._ActivityType>.RegisterType("MYSTERYER", 6);
            flag &= TypeNameContainer<ClientServerCommon._ActivityType>.RegisterType("SEVENELEVENGIFT", 12);
            flag &= TypeNameContainer<ClientServerCommon._ActivityType>.RegisterType("FIRSTTHREEDAY", 13);
            flag &= TypeNameContainer<ClientServerCommon._ActivityType>.RegisterType("TENTAVERNACTIVITY", 14);
            flag &= TypeNameContainer<ClientServerCommon._ActivityType>.RegisterType("NORMALTAVERNACTIVITY", 15);
            flag &= TypeNameContainer<ClientServerCommon._ActivityType>.RegisterType("ZENTIA", 7);
            flag &= TypeNameContainer<ClientServerCommon._ActivityType>.RegisterType("ALCHEMY", 8);
            flag &= TypeNameContainer<ClientServerCommon._ActivityType>.RegisterType("DECOMPOSE", 9);
            flag &= TypeNameContainer<ClientServerCommon._ActivityType>.RegisterType("GUILDSHOP", 10);
            return (flag & TypeNameContainer<ClientServerCommon._ActivityType>.RegisterType("GUILDSTAGE", 11));
        }
    }
}

