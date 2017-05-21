namespace ClientServerCommon
{
    using System;

    public class _CombatRoundType : TypeNameContainer<_CombatRoundType>
    {
        public const int ActiveSkillCombat = 4;
        public const int BattleStart = 7;
        public const int CameraEnterBattle = 8;
        public const int CameraTrace = 6;
        public const int CompositeSkillCombat = 20;
        public const int Custom_CameraAnimRound = 9;
        public const int Custom_PrepareEnterScene = 5;
        public const int Custom_RoleTween = 11;
        public const int EnterBattleGround = 1;
        public const int EnterBattleSkill = 2;
        public const int NormalCombat = 3;
        public const int PlotBattleInterludeEffect = 12;
        public const int SponsorGoToOpponent = 10;
        public const int Unknown = 0;

        public static bool Initialize()
        {
            bool flag = false;
            flag &= TypeNameContainer<_CombatRoundType>.RegisterType("EnterBattleGround", 1, "EnterBattleGround");
            flag &= TypeNameContainer<_CombatRoundType>.RegisterType("EnterBattleSkill", 2, "EnterBattleSkill");
            flag &= TypeNameContainer<_CombatRoundType>.RegisterType("NormalCombat", 3, "NormalCombat");
            flag &= TypeNameContainer<_CombatRoundType>.RegisterType("ActiveSkillCombat", 4, "ActiveSkillCombat");
            flag &= TypeNameContainer<_CombatRoundType>.RegisterType("Custom_PrepareEnterScene", 5);
            flag &= TypeNameContainer<_CombatRoundType>.RegisterType("CameraTrace", 6);
            flag &= TypeNameContainer<_CombatRoundType>.RegisterType("BattleStart", 7);
            flag &= TypeNameContainer<_CombatRoundType>.RegisterType("CameraEnterBattle", 8);
            flag &= TypeNameContainer<_CombatRoundType>.RegisterType("Custom_CameraAnimRound", 9);
            flag &= TypeNameContainer<_CombatRoundType>.RegisterType("SponsorGoToOpponent", 10);
            flag &= TypeNameContainer<_CombatRoundType>.RegisterType("Custom_RoleTween", 11);
            flag &= TypeNameContainer<_CombatRoundType>.RegisterType("PlotBattleInterludeEffect", 12);
            return (flag & TypeNameContainer<_CombatRoundType>.RegisterType("CompositeSkillCombat", 20));
        }
    }
}

