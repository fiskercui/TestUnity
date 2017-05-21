namespace ClientServerCommon
{
    using System;

    public class _ConditionValueCompareType : TypeNameContainer<_ConditionValueCompareType>
    {
        public const int Equal = 3;
        public const int Greater = 5;
        public const int GreaterEqual = 4;
        public const int Less = 1;
        public const int LessEqual = 2;
        public const int NotEqual = 6;
        public const int Unknown = 0;

        public static bool Initialize()
        {
            bool flag = false;
            flag &= TypeNameContainer<_ConditionValueCompareType>.RegisterType("Less", 1, "Condition_Less");
            flag &= TypeNameContainer<_ConditionValueCompareType>.RegisterType("LessEqual", 2, "Condition_LessEqual");
            flag &= TypeNameContainer<_ConditionValueCompareType>.RegisterType("Equal", 3, "Condition_Equal");
            flag &= TypeNameContainer<_ConditionValueCompareType>.RegisterType("GreaterEqual", 4, "Condition_GreaterEqual");
            flag &= TypeNameContainer<_ConditionValueCompareType>.RegisterType("Greater", 5, "Condition_Greater");
            return (flag & TypeNameContainer<_ConditionValueCompareType>.RegisterType("NotEqual", 6, "Condition_NotEqual"));
        }
    }
}

