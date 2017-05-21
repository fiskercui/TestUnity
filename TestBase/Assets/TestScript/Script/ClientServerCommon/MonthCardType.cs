namespace ClientServerCommon
{
    using System;

    public class MonthCardType : TypeNameContainer<MonthCardType>
    {
        public const int MONTH_CARD_TYPE_1 = 1;
        public const int MONTH_CARD_TYPE_10 = 10;
        public const int MONTH_CARD_TYPE_2 = 2;
        public const int MONTH_CARD_TYPE_3 = 3;
        public const int MONTH_CARD_TYPE_4 = 4;
        public const int MONTH_CARD_TYPE_5 = 5;
        public const int MONTH_CARD_TYPE_6 = 6;
        public const int MONTH_CARD_TYPE_7 = 7;
        public const int MONTH_CARD_TYPE_8 = 8;
        public const int MONTH_CARD_TYPE_9 = 9;
        public const int Unknown = 0;

        public static bool Initialize()
        {
            bool flag = false;
            flag &= TypeNameContainer<MonthCardType>.RegisterType("MONTH_CARD_TYPE_1", 1);
            flag &= TypeNameContainer<MonthCardType>.RegisterType("MONTH_CARD_TYPE_2", 2);
            flag &= TypeNameContainer<MonthCardType>.RegisterType("MONTH_CARD_TYPE_3", 3);
            flag &= TypeNameContainer<MonthCardType>.RegisterType("MONTH_CARD_TYPE_4", 4);
            flag &= TypeNameContainer<MonthCardType>.RegisterType("MONTH_CARD_TYPE_5", 5);
            flag &= TypeNameContainer<MonthCardType>.RegisterType("MONTH_CARD_TYPE_6", 6);
            flag &= TypeNameContainer<MonthCardType>.RegisterType("MONTH_CARD_TYPE_7", 7);
            flag &= TypeNameContainer<MonthCardType>.RegisterType("MONTH_CARD_TYPE_8", 8);
            flag &= TypeNameContainer<MonthCardType>.RegisterType("MONTH_CARD_TYPE_9", 9);
            return (flag & TypeNameContainer<MonthCardType>.RegisterType("MONTH_CARD_TYPE_10", 10));
        }
    }
}

