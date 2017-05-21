namespace ClientServerCommon
{
    using System;

    public class _PlatformType : TypeNameContainer<_PlatformType>
    {
        public const int Android = 3;
        public const int IPhone = 1;
        public const int IPhoneBreak = 2;
        public const int UnKnow = 0;

        public static bool Initialize()
        {
            bool flag = false;
            flag &= TypeNameContainer<_PlatformType>.RegisterType("IPhone", 1);
            flag &= TypeNameContainer<_PlatformType>.RegisterType("IPhoneBreak", 2);
            return (flag & TypeNameContainer<_PlatformType>.RegisterType("Android", 3));
        }
    }
}

