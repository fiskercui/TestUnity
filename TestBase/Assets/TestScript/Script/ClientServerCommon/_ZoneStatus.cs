namespace ClientServerCommon
{
    using System;

    public class _ZoneStatus : TypeNameContainer<_ZoneStatus>
    {
        public const int PlotDialogue = 1;
        public const int UnlockAnimation = 0;
        public const int ZoneComplete = 3;
        public const int ZoneProceed = 2;

        public static bool Initialize()
        {
            bool flag = false;
            flag &= TypeNameContainer<_ZoneStatus>.RegisterType("UnlockAnimation", 0);
            flag &= TypeNameContainer<_ZoneStatus>.RegisterType("PlotDialogue", 1);
            flag &= TypeNameContainer<_ZoneStatus>.RegisterType("ZoneProceed", 2);
            return (flag & TypeNameContainer<_ZoneStatus>.RegisterType("ZoneComplete", 3));
        }
    }
}

