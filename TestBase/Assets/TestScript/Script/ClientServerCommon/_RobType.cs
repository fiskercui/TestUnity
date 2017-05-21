namespace ClientServerCommon
{
    using System;

    public class _RobType
    {
        public const int RobType_Equip = 1;
        public const int RobType_Skill = 0;

        public static int getRobType(int robType)
        {
            if (robType == 0)
            {
                return 0;
            }
            return 1;
        }
    }
}

