namespace ClientServerCommon
{
    using System;

    public class _AnimationType : TypeNameContainer<_AnimationType>
    {
        public const int AvatarAssetId = 3;
        public const int AvatarAssetType = 2;
        public const int Default = 1;

        public static bool Initialize()
        {
            bool flag = false;
            flag &= TypeNameContainer<_AnimationType>.RegisterType("Default", 1);
            flag &= TypeNameContainer<_AnimationType>.RegisterType("AvatarAssetType", 2);
            return (flag & TypeNameContainer<_AnimationType>.RegisterType("AvatarAssetId", 3));
        }
    }
}

