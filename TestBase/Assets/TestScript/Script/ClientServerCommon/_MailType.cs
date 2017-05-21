namespace ClientServerCommon
{
    using System;

    public class _MailType
    {
        public const int AddFriendRequrst = 0x65;
        public const int AutoCombatConsumableNotEnough = 3;
        public const int CombatArena = 0xca;
        public const int CombatRob = 0xc9;
        public const int ConsignmentDownShelf = 2;
        public const int FriendAdd = 0x67;
        public const int FriendDel = 0x68;
        public const int FriendReceiveRefuse = 0x66;
        public const int Guild = 0x12d;
        public const int GuildBossKilledNoShop = 0x12e;
        public const int GuildBossKilledWithShop = 0x12f;
        public const int System = 1;
        public const int Unknown = 0;
        public const int WorldBossReward = 4;

        public static int GetTabEmailTypeFromDBEmailType(int emailType)
        {
            if ((emailType >= 0) && (emailType <= 0x63))
            {
                return 1;
            }
            if ((emailType >= 100) && (emailType <= 0xc7))
            {
                return 2;
            }
            if ((emailType >= 200) && (emailType <= 0x12b))
            {
                return 3;
            }
            if ((emailType >= 300) && (emailType <= 0x18f))
            {
                return 4;
            }
            return 0;
        }
    }
}

