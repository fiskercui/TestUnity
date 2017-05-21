namespace ClientServerCommon
{
    using System;

    public class _Goods : TypeNameContainer<_Goods>
    {
        public const int ArenaGoods = 1;
        public const int MelaleucaGoods = 3;
        public const int NormalGoods = 0;
        public const int RenownGoods = 2;
        public const int WolfSmokeGoods = 4;

        public static bool Initialize()
        {
            bool flag = false;
            flag &= TypeNameContainer<_Goods>.RegisterType("NormalGoods", 0);
            flag &= TypeNameContainer<_Goods>.RegisterType("ArenaGoods", 1);
            flag &= TypeNameContainer<_Goods>.RegisterType("RenownGoods", 2);
            flag &= TypeNameContainer<_Goods>.RegisterType("MelaleucaGoods", 3);
            return (flag & TypeNameContainer<_Goods>.RegisterType("WolfSmokeGoods", 4));
        }
    }
}

