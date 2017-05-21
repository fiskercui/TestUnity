namespace ClientServerCommon
{
    using System;

    public class _Difficulty : TypeNameContainer<_Difficulty>
    {
        public const int Common = 2;
        public const int Difficulty = 3;
        public const int Easy = 1;
        public const int Unknow = 0;

        public static bool Initialize()
        {
            bool flag = false;
            flag &= TypeNameContainer<_Difficulty>.RegisterType("Easy", 1);
            flag &= TypeNameContainer<_Difficulty>.RegisterType("Common", 2);
            return (flag & TypeNameContainer<_Difficulty>.RegisterType("Difficulty", 3));
        }
    }
}

