namespace ClientServerCommon
{
    using System;

    public class _CounterType : TypeNameContainer<_CounterType>
    {
        public const int Buy = 1;
        public const int Refresh = 2;
        public const int Unkonw = 0;

        public static bool Initialize()
        {
            bool flag = false;
            flag &= TypeNameContainer<_CounterType>.RegisterType("Unkonw", 0);
            flag &= TypeNameContainer<_CounterType>.RegisterType("Buy", 1);
            return (flag & TypeNameContainer<_CounterType>.RegisterType("Refresh", 2));
        }
    }
}

