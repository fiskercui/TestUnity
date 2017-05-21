namespace ClientServerCommon
{
    using System;

    public class SpecialSkillType : TypeNameContainer<SpecialSkillType>
    {
        public const int Died = 2;
        public const int EnterBattle = 1;
        public const int Unknown = 0;

        public static bool Initialize()
        {
            bool flag = false;
            flag &= TypeNameContainer<SpecialSkillType>.RegisterType("EnterBattle", 1);
            return (flag & TypeNameContainer<SpecialSkillType>.RegisterType("Died", 2));
        }
    }
}

