namespace ClientServerCommon
{
    using System;

    public class _GoodsStatusType : TypeNameContainer<_GoodsStatusType>
    {
        public const int Closed = 4;
        public const int Discount = 1;
        public const int Hot = 2;
        public const int New = 3;
        public const int Normal = 0;

        public static bool Initialize()
        {
            bool flag = false;
            TypeNameContainer<_GoodsStatusType>.SetTextSectionName("Code_GoodsStatusType");
            flag &= TypeNameContainer<_GoodsStatusType>.RegisterType("Normal", 0);
            flag &= TypeNameContainer<_GoodsStatusType>.RegisterType("Discount", 1);
            flag &= TypeNameContainer<_GoodsStatusType>.RegisterType("Hot", 2);
            flag &= TypeNameContainer<_GoodsStatusType>.RegisterType("New", 3);
            return (flag & TypeNameContainer<_GoodsStatusType>.RegisterType("Closed", 4));
        }
    }
}

