namespace ClientServerCommon
{
    using System;

    public class _AvatarType : TypeNameContainer<_AvatarType>
    {
        public const int NpcAvatar = 2;
        public const int PlayerAvatar = 1;
        public const int Unknown = 0;

        public static bool Initialize()
        {
            bool flag = false;
            flag &= TypeNameContainer<_AvatarType>.RegisterType("PlayerAvatar", 1, "PlayerAvatar");
            return (flag & TypeNameContainer<_AvatarType>.RegisterType("NpcAvatar", 2, "NpcAvatar"));
        }
    }
}

