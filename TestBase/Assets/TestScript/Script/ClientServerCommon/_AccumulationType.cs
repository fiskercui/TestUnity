namespace ClientServerCommon
{
    using System;

    public class _AccumulationType : TypeNameContainer<_AccumulationType>
    {
        public const int Cost = 2;
        public const int Purchase = 1;

        public static bool Initialize()
        {
            bool flag = false;
            flag &= TypeNameContainer<_AccumulationType>.RegisterType("Purchase", 1);
            return (flag & TypeNameContainer<_AccumulationType>.RegisterType("Cost", 2));
        }
    }
}

