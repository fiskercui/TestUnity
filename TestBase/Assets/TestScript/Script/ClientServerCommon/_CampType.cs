namespace ClientServerCommon
{
    using System;

    public class _CampType : TypeNameContainer<ClientServerCommon._CampType>
    {
        public const int Attacker = 1;
        public const int Defender = 2;
        public const int Unkonw = 0;

        public static bool Initialize()
        {
            bool flag = false;
            flag &= TypeNameContainer<ClientServerCommon._CampType>.RegisterType("Unkonw", 0);
            flag &= TypeNameContainer<ClientServerCommon._CampType>.RegisterType("Attacker", 1);
            return (flag & TypeNameContainer<ClientServerCommon._CampType>.RegisterType("Defender", 2));
        }
    }
}

