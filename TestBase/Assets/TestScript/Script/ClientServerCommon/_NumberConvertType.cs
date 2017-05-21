namespace ClientServerCommon
{
    using System;

    public class _NumberConvertType : TypeNameContainer<_NumberConvertType>
    {
        public const int ExchangeCodeConvert = 2;
        public const int GoldConVert = 1;
        public const int UnKnow = 0;

        public static bool Initialize()
        {
            bool flag = false;
            flag &= TypeNameContainer<_NumberConvertType>.RegisterType("UnKnow", 0);
            flag &= TypeNameContainer<_NumberConvertType>.RegisterType("GoldConVert", 1);
            return (flag & TypeNameContainer<_NumberConvertType>.RegisterType("ExchangeCodeConvert", 2));
        }
    }
}

