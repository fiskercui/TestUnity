namespace ClientServerCommon
{
    using System;

    public class _DungeonDifficulity : TypeNameContainer<_DungeonDifficulity>
    {
        public const int Common = 1;
        public const int Hard = 2;
        public const int Nightmare = 3;
        public const int Unknow = 0;

        public static bool Initialize()
        {
            TypeNameContainer<_DungeonDifficulity>.SetTextSectionName("CampaignDifficulity");
            bool flag = false;
            flag &= TypeNameContainer<_DungeonDifficulity>.RegisterType("Common", 1);
            flag &= TypeNameContainer<_DungeonDifficulity>.RegisterType("Hard", 2);
            return (flag & TypeNameContainer<_DungeonDifficulity>.RegisterType("Nightmare", 3));
        }
    }
}

