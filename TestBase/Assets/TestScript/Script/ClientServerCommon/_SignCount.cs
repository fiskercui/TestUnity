namespace ClientServerCommon
{
    using System;

    public class _SignCount : TypeNameContainer<_SignCount>
    {
        public const int WholeMonth = -1;

        public static bool Initialize()
        {
            bool flag = false;
            return (flag & TypeNameContainer<_SignCount>.RegisterType("WholeMonth", -1));
        }
    }
}

