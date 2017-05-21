namespace ClientServerCommon
{
    using System;

    public class _CombatStateType : TypeNameContainer<_CombatStateType>
    {
        public const int Dead = 10;
        public const int Default = 0;
        public const int Dodging = 2;
        public const int Frozen = 4;
        public const int Stunned = 3;
        public const int Weak = 5;

        public static bool Initialize()
        {
            bool flag = false;
            flag &= TypeNameContainer<_CombatStateType>.RegisterType("Default", 0);
            flag &= TypeNameContainer<_CombatStateType>.RegisterType("Dodging", 2);
            flag &= TypeNameContainer<_CombatStateType>.RegisterType("Stunned", 3);
            flag &= TypeNameContainer<_CombatStateType>.RegisterType("Frozen", 4);
            flag &= TypeNameContainer<_CombatStateType>.RegisterType("Weak", 5);
            return (flag & TypeNameContainer<_CombatStateType>.RegisterType("Dead", 10));
        }
    }
}

