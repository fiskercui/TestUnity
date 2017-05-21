namespace ClientServerCommon
{
    using System;

    public class _CombatType : TypeNameContainer<_CombatType>
    {
        public const int ActivityCampaign = 2;
        public const int Adventure = 11;
        public const int Arena = 4;
        public const int Campaign = 1;
        public const int CombatFriend = 10;
        public const int FriendCampaign = 12;
        public const int GuildBoss = 13;
        public const int GuildMonster = 14;
        public const int Pve = 5;
        public const int Rob = 3;
        public const int Tower = 8;
        public const int Tutorial = 7;
        public const int Unknown = 0;
        public const int WolfSmoke = 9;
        public const int WorldBoss = 6;

        public static bool Initialize()
        {
            bool flag = false;
            flag &= TypeNameContainer<_CombatType>.RegisterType("Campaign", 1);
            flag &= TypeNameContainer<_CombatType>.RegisterType("ActivityCampaign", 2);
            flag &= TypeNameContainer<_CombatType>.RegisterType("Rob", 3);
            flag &= TypeNameContainer<_CombatType>.RegisterType("Arena", 4);
            flag &= TypeNameContainer<_CombatType>.RegisterType("Pve", 5);
            flag &= TypeNameContainer<_CombatType>.RegisterType("WorldBoss", 6);
            flag &= TypeNameContainer<_CombatType>.RegisterType("Tutorial", 7);
            flag &= TypeNameContainer<_CombatType>.RegisterType("Tower", 8);
            flag &= TypeNameContainer<_CombatType>.RegisterType("WolfSmoke", 9);
            flag &= TypeNameContainer<_CombatType>.RegisterType("CombatFriend", 10);
            flag &= TypeNameContainer<_CombatType>.RegisterType("Adventure", 11);
            flag &= TypeNameContainer<_CombatType>.RegisterType("FriendCampaign", 12);
            flag &= TypeNameContainer<_CombatType>.RegisterType("GuildBoss", 13);
            return (flag & TypeNameContainer<_CombatType>.RegisterType("GuildMonster", 14));
        }
    }
}

