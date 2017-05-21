namespace ClientServerCommon
{
    using System;

    public class _NumberPositionType : TypeNameContainer<_NumberPositionType>
    {
        public const int HundredsDigit = 3;
        public const int TensDigit = 2;
        public const int UnitsDigit = 1;
        public const int UnKnow = 0;

        public static bool Initialize()
        {
            bool flag = false;
            flag &= TypeNameContainer<_NumberPositionType>.RegisterType("UnKnow", 0);
            flag &= TypeNameContainer<_NumberPositionType>.RegisterType("UnitsDigit", 1);
            flag &= TypeNameContainer<_NumberPositionType>.RegisterType("TensDigit", 2);
            return (flag & TypeNameContainer<_NumberPositionType>.RegisterType("HundredsDigit", 3));
        }
    }
}

