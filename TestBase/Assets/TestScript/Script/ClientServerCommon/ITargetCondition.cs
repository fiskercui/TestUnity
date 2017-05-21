namespace ClientServerCommon
{
    using System;

    public interface ITargetCondition
    {
        TargetCondition GetTargetCondition(int idx);
        int GetTargetConditionCount();
    }
}

