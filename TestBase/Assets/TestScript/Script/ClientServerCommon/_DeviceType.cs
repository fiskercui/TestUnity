namespace ClientServerCommon
{
    using System;

    public class _DeviceType : TypeNameContainer<_DeviceType>
    {
        public const int Android = 2;
        public const int iPhone = 1;
        public const int Unknown = 0;

        public static bool Initialize()
        {
            bool flag = false;
            flag &= TypeNameContainer<_DeviceType>.RegisterType("Unknown", 0);
            flag &= TypeNameContainer<_DeviceType>.RegisterType("iPhone", 1);
            return (flag & TypeNameContainer<_DeviceType>.RegisterType("Android", 2));
        }

        public static int ParseAppGoodChannelType(string stageName, int defValue)
        {
            return TypeNameContainer<_DeviceType>.Parse(stageName, defValue);
        }
    }
}

