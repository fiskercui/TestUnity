namespace ClientServerCommon
{
    using System;

    public class _MultiSelectType : TypeNameContainer<_MultiSelectType>
    {
        public const int A = 1;
        public const int B = 2;
        public const int C = 3;
        public const int D = 4;
        public const int UnKnown = 0;

        public static bool Initialize()
        {
            bool flag = false;
            flag &= TypeNameContainer<_MultiSelectType>.RegisterType("UnKnown", 0);
            flag &= TypeNameContainer<_MultiSelectType>.RegisterType("A", 1);
            flag &= TypeNameContainer<_MultiSelectType>.RegisterType("B", 2);
            flag &= TypeNameContainer<_MultiSelectType>.RegisterType("C", 3);
            return (flag & TypeNameContainer<_MultiSelectType>.RegisterType("D", 4));
        }
    }
}

