namespace ClientServerCommon
{
    using System;

    public class _AvatarAbilityType : TypeNameContainer<_AvatarAbilityType>
    {
        public const int ImmuneBuff = 1;
        public const int Unknown = 0;

        public static bool Initialize()
        {
            bool flag = false;
            return (flag & TypeNameContainer<_AvatarAbilityType>.RegisterType("ImmuneBuff", 1));
        }
    }
}

