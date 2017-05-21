namespace ClientServerCommon
{
    using System;

    public class _RequirementType : TypeNameContainer<_RequirementType>
    {
        public const int Coin = 2;
        public const int Gold = 1;
        public const int Item = 3;
        public const int Unknown = 0;

        public static bool Initialize()
        {
            bool flag = false;
            TypeNameContainer<_RequirementType>.SetTextSectionName("Breakthrough_Requirement");
            flag &= TypeNameContainer<_RequirementType>.RegisterType("Gold", 1, "Gold");
            flag &= TypeNameContainer<_RequirementType>.RegisterType("Coin", 2, "Coin");
            return (flag & TypeNameContainer<_RequirementType>.RegisterType("Item", 3, "Item"));
        }
    }
}

