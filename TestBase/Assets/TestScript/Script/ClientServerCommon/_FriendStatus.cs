namespace ClientServerCommon
{
    using System;

    public class _FriendStatus : TypeNameContainer<_FriendStatus>
    {
        public const int Invited = 2;
        public const int IsFriend = 3;
        public const int NotFriend = 1;
        public const int UnKnow = 0;

        public static bool Initialize()
        {
            bool flag = false;
            flag &= TypeNameContainer<_FriendStatus>.RegisterType("NotFriend", 1);
            flag &= TypeNameContainer<_FriendStatus>.RegisterType("Invited", 2);
            return (flag & TypeNameContainer<_FriendStatus>.RegisterType("IsFriend", 3));
        }
    }
}

