namespace ClientServerCommon
{
    using System;

    public class _WolfSmokeLimitType : TypeNameContainer<_WolfSmokeLimitType>
    {
        public const int HistoryPassStage = 2;
        public const int PassStage = 1;
        public const int UnKnow = 0;

        public static bool Initialize()
        {
            bool flag = false;
            flag &= TypeNameContainer<_WolfSmokeLimitType>.RegisterType("PassStage", 1);
            return (flag & TypeNameContainer<_WolfSmokeLimitType>.RegisterType("HistoryPassStage", 2));
        }
    }
}

