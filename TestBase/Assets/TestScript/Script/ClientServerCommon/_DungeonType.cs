namespace ClientServerCommon
{
    using System;

    public class _DungeonType : TypeNameContainer<_DungeonType>
    {
        public const int Activity = 2;
        public const int Common = 1;
        public const int Unkonw = 0;

        public static bool Initialize()
        {
            bool flag = false;
            flag &= TypeNameContainer<_DungeonType>.RegisterType("Unkonw", 0);
            flag &= TypeNameContainer<_DungeonType>.RegisterType("Common", 1);
            return (flag & TypeNameContainer<_DungeonType>.RegisterType("Activity", 2));
        }
    }
}

