namespace ClientServerCommon
{
    using System;

    public class _DoubleSelectType : TypeNameContainer<_DoubleSelectType>
    {
        public const int No = 2;
        public const int UnKnown = 0;
        public const int Yes = 1;

        public static bool Initialize()
        {
            bool flag = false;
            flag &= TypeNameContainer<_DoubleSelectType>.RegisterType("UnKnown", 0);
            flag &= TypeNameContainer<_DoubleSelectType>.RegisterType("Yes", 1);
            return (flag & TypeNameContainer<_DoubleSelectType>.RegisterType("No", 2));
        }
    }
}

