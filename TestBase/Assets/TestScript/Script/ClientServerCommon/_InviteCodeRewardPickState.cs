namespace ClientServerCommon
{
    using System;

    public class _InviteCodeRewardPickState : TypeNameContainer<_InviteCodeRewardPickState>
    {
        public const int HasPicked = 2;
        public const int Pickable = 0;
        public const int UnPickable = 1;

        public static bool Initialize()
        {
            bool flag = false;
            flag &= TypeNameContainer<_InviteCodeRewardPickState>.RegisterType("UnPickable", 1);
            flag &= TypeNameContainer<_InviteCodeRewardPickState>.RegisterType("Pickable", 0);
            return (flag & TypeNameContainer<_InviteCodeRewardPickState>.RegisterType("HasPicked", 2));
        }
    }
}

