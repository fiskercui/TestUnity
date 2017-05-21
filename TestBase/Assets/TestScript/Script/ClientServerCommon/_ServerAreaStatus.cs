namespace ClientServerCommon
{
    using System;

    public class _ServerAreaStatus : TypeNameContainer<_ServerAreaStatus>
    {
        public const int Busy = 2;
        public const int Hot = 3;
        public const int Maintain = 4;
        public const int New = 1;
        public const int OnlyForWhiteIP = 5;
        public const int Smooth = 6;
        public const int Unknown = 0;

        public static bool Initialize()
        {
            bool flag = false;
            TypeNameContainer<_ServerAreaStatus>.SetTextSectionName("Code_ServerAreaStatus");
            flag &= TypeNameContainer<_ServerAreaStatus>.RegisterType("New", 1);
            flag &= TypeNameContainer<_ServerAreaStatus>.RegisterType("Busy", 2);
            flag &= TypeNameContainer<_ServerAreaStatus>.RegisterType("Hot", 3);
            flag &= TypeNameContainer<_ServerAreaStatus>.RegisterType("Maintain", 4);
            flag &= TypeNameContainer<_ServerAreaStatus>.RegisterType("OnlyForWhiteIP", 5);
            return (flag & TypeNameContainer<_ServerAreaStatus>.RegisterType("Smooth", 6));
        }
    }
}

