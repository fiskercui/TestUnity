namespace ClientServerCommon
{
    using System;

    public class _Isvalid : TypeNameContainer<_Isvalid>
    {
        public const int Close = 0;
        public const int Open = 1;
        public const int Pause = 2;

        public static bool Initialize()
        {
            bool flag = false;
            flag &= TypeNameContainer<_Isvalid>.RegisterType("Close", 0);
            flag &= TypeNameContainer<_Isvalid>.RegisterType("Open", 1);
            return (flag & TypeNameContainer<_Isvalid>.RegisterType("Pause", 2));
        }
    }
}

