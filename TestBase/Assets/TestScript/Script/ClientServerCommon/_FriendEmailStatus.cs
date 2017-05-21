namespace ClientServerCommon
{
    using System;

    public class _FriendEmailStatus : TypeNameContainer<_FriendEmailStatus>
    {
        public const int AlreadyAgree = 1;
        public const int AlreayRefuse = 2;
        public const int UnDo = 0;

        public static bool Initialize()
        {
            bool flag = false;
            flag &= TypeNameContainer<_FriendEmailStatus>.RegisterType("UnDo", 0);
            flag &= TypeNameContainer<_FriendEmailStatus>.RegisterType("AlreadyAgree", 1);
            return (flag & TypeNameContainer<_FriendEmailStatus>.RegisterType("AlreayRefuse", 2));
        }
    }
}

