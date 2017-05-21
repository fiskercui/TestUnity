namespace ClientServerCommon
{
    using System;

    public class _CombatFailGuidType : TypeNameContainer<_CombatFailGuidType>
    {
        public const int ChangeAvatar = 4;
        public const int ChangeEquip = 5;
        public const int GoRobSkill = 10;
        public const int GoShop = 9;
        public const int GoShopWine = 8;
        public const int LineUpAvatar = 1;
        public const int LineUpEquip = 2;
        public const int LineUpSkill = 3;
        public const int PowerUpAvatar = 6;
        public const int PowerUpEquip = 7;
        public const int Unknown = 0;

        public static bool Initialize()
        {
            bool flag = false;
            TypeNameContainer<_CombatFailGuidType>.SetTextSectionName("Code_CombatFialType");
            flag &= TypeNameContainer<_CombatFailGuidType>.RegisterType("CombatFailGuid_LineUpAvatar", 1);
            flag &= TypeNameContainer<_CombatFailGuidType>.RegisterType("CombatFailGuid_LineUpEquip", 2);
            flag &= TypeNameContainer<_CombatFailGuidType>.RegisterType("CombatFailGuid_LineUpSkill", 3);
            flag &= TypeNameContainer<_CombatFailGuidType>.RegisterType("CombatFailGuid_ChangeAvatar", 4);
            flag &= TypeNameContainer<_CombatFailGuidType>.RegisterType("CombatFailGuid_ChangeEquip", 5);
            flag &= TypeNameContainer<_CombatFailGuidType>.RegisterType("CombatFailGuid_PowerUpAvatar", 6);
            flag &= TypeNameContainer<_CombatFailGuidType>.RegisterType("CombatFailGuid_PowerUpEquip", 7);
            flag &= TypeNameContainer<_CombatFailGuidType>.RegisterType("CombatFailGuid_GoShopWine", 8);
            flag &= TypeNameContainer<_CombatFailGuidType>.RegisterType("CombatFailGuid_GoShop", 9);
            return (flag & TypeNameContainer<_CombatFailGuidType>.RegisterType("CombatFailGuid_GoRobSkill", 10));
        }
    }
}

