namespace ClientServerCommon
{
    using System;

    public class _PVEGridType : TypeNameContainer<_PVEGridType>
    {
        public const int AttributeTrap = 5;
        public const int Battle = 1;
        public const int Empty = 0;
        public const int EndPos = 7;
        public const int Guess = 3;
        public const int NoAccess = 8;
        public const int Reward = 2;
        public const int StartPos = 6;
        public const int StepTrap = 4;

        public static bool Initialize()
        {
            bool flag = false;
            flag &= TypeNameContainer<_PVEGridType>.RegisterType("Empty", 0);
            flag &= TypeNameContainer<_PVEGridType>.RegisterType("Battle", 1);
            flag &= TypeNameContainer<_PVEGridType>.RegisterType("Reward", 2);
            flag &= TypeNameContainer<_PVEGridType>.RegisterType("Guess", 3);
            flag &= TypeNameContainer<_PVEGridType>.RegisterType("StepTrap", 4);
            flag &= TypeNameContainer<_PVEGridType>.RegisterType("AttributeTrap", 5);
            flag &= TypeNameContainer<_PVEGridType>.RegisterType("StartPos", 6);
            flag &= TypeNameContainer<_PVEGridType>.RegisterType("EndPos", 7);
            return (flag & TypeNameContainer<_PVEGridType>.RegisterType("NoAccess", 8));
        }
    }
}

