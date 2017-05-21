namespace ClientServerCommon
{
    using System;

    public class _StateDialogueType : TypeNameContainer<_StateDialogueType>
    {
        public const int AfterStageLost = 4;
        public const int AfterStageWin = 3;
        public const int BeforeBattle = 1;
        public const int BeforeStage = 2;
        public const int Unkonw = 0;

        public static bool Initialize()
        {
            bool flag = false;
            flag &= TypeNameContainer<_StateDialogueType>.RegisterType("Unkonw", 0);
            flag &= TypeNameContainer<_StateDialogueType>.RegisterType("BeforeBattle", 1);
            flag &= TypeNameContainer<_StateDialogueType>.RegisterType("BeforeStage", 2);
            flag &= TypeNameContainer<_StateDialogueType>.RegisterType("AfterStageWin", 3);
            return (flag & TypeNameContainer<_StateDialogueType>.RegisterType("AfterStageLost", 4));
        }
    }
}

