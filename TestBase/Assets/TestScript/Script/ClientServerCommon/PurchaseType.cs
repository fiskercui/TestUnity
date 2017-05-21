namespace ClientServerCommon
{
    using System;

    public class PurchaseType : TypeNameContainer<PurchaseType>
    {
        public const int MonthCard = 1;
        public const int Normal = 0;
        public const int Unknown = -1;

        public static bool Initialize()
        {
            bool flag = false;
            flag &= TypeNameContainer<PurchaseType>.RegisterType("Normal", 0);
            return (flag & TypeNameContainer<PurchaseType>.RegisterType("MonthCard", 1));
        }
    }
}

