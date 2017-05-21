namespace ClientServerCommon
{
    using System;

    public class _TrainType : TypeNameContainer<_TrainType>
    {
        public const int CommonTrain = 0;
        public const int MoneyTrain = 1;
        public const int TenCommonTrain = 2;
        public const int TenMoneyTrain = 3;

        public static bool Initialize()
        {
            bool flag = false;
            flag &= TypeNameContainer<_TrainType>.RegisterType("CommonTrain", 0);
            flag &= TypeNameContainer<_TrainType>.RegisterType("MoneyTrain", 1);
            flag &= TypeNameContainer<_TrainType>.RegisterType("TenCommonTrain", 2);
            return (flag & TypeNameContainer<_TrainType>.RegisterType("TenMoneyTrain", 3));
        }
    }
}

