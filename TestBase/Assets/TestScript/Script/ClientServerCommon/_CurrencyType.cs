namespace ClientServerCommon
{
    using System;

    public class _CurrencyType : TypeNameContainer<_CurrencyType>
    {
        public const int Dollar = 2;
        public const int NTB = 3;
        public const int RMB = 1;
        public const int UnKnow = 0;

        public static bool Initialize()
        {
            bool flag = false;
            flag &= TypeNameContainer<_CurrencyType>.RegisterType("UnKnow", 0);
            flag &= TypeNameContainer<_CurrencyType>.RegisterType("RMB", 1);
            flag &= TypeNameContainer<_CurrencyType>.RegisterType("Dollar", 2);
            return (flag & TypeNameContainer<_CurrencyType>.RegisterType("NTB", 3));
        }
    }
}

