namespace ClientServerCommon
{
    using System;

    public class _TimeType : TypeNameContainer<_TimeType>
    {
        public const int Abslute = 1;
        public const int Relative = 2;

        public static bool Initialize()
        {
            bool flag = false;
            flag &= TypeNameContainer<_TimeType>.RegisterType("Abslute", 1);
            return (flag & TypeNameContainer<_TimeType>.RegisterType("Relative", 2));
        }
    }
}

