namespace ClientServerCommon
{
    using System;

    public class _DungeonStatus : TypeNameContainer<_DungeonStatus>
    {
        public const int LockState = 0;
        public const int UnLockState = 1;

        public static bool Initialize()
        {
            bool flag = false;
            flag &= TypeNameContainer<_DungeonStatus>.RegisterType("LockState", 0);
            return (flag & TypeNameContainer<_DungeonStatus>.RegisterType("UnLockState", 1));
        }
    }
}

