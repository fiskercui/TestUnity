namespace ClientServerCommon
{
    using System;

    public class _AccumulationStatus : TypeNameContainer<_AccumulationStatus>
    {
        public const int AlreadyGet = 3;
        public const int CanGet = 2;
        public const int NotMatch = 1;

        public static bool Initialize()
        {
            bool flag = false;
            flag &= TypeNameContainer<_AccumulationStatus>.RegisterType("NotMatch", 1);
            flag &= TypeNameContainer<_AccumulationStatus>.RegisterType("CanGet", 2);
            return (flag & TypeNameContainer<_AccumulationStatus>.RegisterType("AlreadyGet", 3));
        }
    }
}

