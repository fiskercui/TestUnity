namespace ClientServerCommon
{
    using System;

    public class _AvatarBattlePositionType : TypeNameContainer<_AvatarBattlePositionType>
    {
        public const int AvatarAll = 1;
        public const int AvatarBack = 3;
        public const int AvatarFront = 2;
        public const int Unknown = 0;

        public static bool Initialize()
        {
            bool flag = false;
            flag &= TypeNameContainer<_AvatarBattlePositionType>.RegisterType("AvatarAll", 1, "AvatarAll");
            flag &= TypeNameContainer<_AvatarBattlePositionType>.RegisterType("AvatarFront", 2, "AvatarFront");
            return (flag & TypeNameContainer<_AvatarBattlePositionType>.RegisterType("AvatarBack", 3, "AvatarBack"));
        }
    }
}

