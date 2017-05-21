namespace ClientServerCommon
{
    using System;

    public class _NpcType : TypeNameContainer<_NpcType>
    {
        public const int Boss = 2;
        public const int Normal = 1;
        public const int Unknow = 0;

        public static bool Initialize()
        {
            bool flag = false;
            flag &= TypeNameContainer<_NpcType>.RegisterType("Normal", 1);
            return (flag & TypeNameContainer<_NpcType>.RegisterType("Boss", 2));
        }
    }
}

