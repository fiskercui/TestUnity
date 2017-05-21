namespace ClientServerCommon
{
    using System;

    public class _ClientDynamicValueType : TypeNameContainer<_ClientDynamicValueType>
    {
        public const int AvatarLevel = 4;
        public const int AvatarQuality = 5;
        public const int CampaignSkipUnLockZoneID = 1;
        public const int GotoUIType = 7;
        public const int LineupAvatarResourceID = 3;
        public const int PressControl = 6;
        public const int Recruit5QualityByRealMoney = 2;
        public const int Unknown = 0;

        public static bool Initialize()
        {
            bool flag = false;
            flag &= TypeNameContainer<_ClientDynamicValueType>.RegisterType("CampaignSkipUnLockZoneID", 1);
            flag &= TypeNameContainer<_ClientDynamicValueType>.RegisterType("Recruit5QualityByRealMoney", 2);
            flag &= TypeNameContainer<_ClientDynamicValueType>.RegisterType("LineupAvatarResourceID", 3);
            flag &= TypeNameContainer<_ClientDynamicValueType>.RegisterType("AvatarLevel", 4);
            flag &= TypeNameContainer<_ClientDynamicValueType>.RegisterType("AvatarQuality", 5);
            flag &= TypeNameContainer<_ClientDynamicValueType>.RegisterType("PressControl", 6);
            return (flag & TypeNameContainer<_ClientDynamicValueType>.RegisterType("GotoUIType", 7));
        }
    }
}

