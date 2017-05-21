namespace ClientServerCommon
{
    using System;

    public class _TavernRecruitStage : TypeNameContainer<_TavernRecruitStage>
    {
        public const int Sale = 1;
        public const int Unknow = 0;
        public const int UnSale = 2;

        public static bool Initialize()
        {
            bool flag = false;
            flag &= TypeNameContainer<_TavernRecruitStage>.RegisterType("Unknow", 0);
            flag &= TypeNameContainer<_TavernRecruitStage>.RegisterType("Sale", 1);
            return (flag & TypeNameContainer<_TavernRecruitStage>.RegisterType("UnSale", 2));
        }

        public static int ParseStage(string stageName, int defValue)
        {
            return TypeNameContainer<_TavernRecruitStage>.Parse(stageName, defValue);
        }
    }
}

