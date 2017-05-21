namespace ClientServerCommon
{
    using System;

    public class _AvatarAttributeType : TypeNameContainer<_AvatarAttributeType>
    {
        public const int AR = 50;
        public const int BSP = 9;
        public const int CR = 0x30;
        public const int CSF = 0x35;
        public const int CSR = 40;
        public const int CTLR = 0x38;
        public const int Dan_AR = 0x55;
        public const int Dan_CmpTRA = 0x53;
        public const int Dan_CntAR = 0x51;
        public const int Dan_CntDR = 0x52;
        public const int Dan_CrtDR = 80;
        public const int Dan_DmgHealByAP = 0x58;
        public const int Dan_DmgHealByDmg = 0x57;
        public const int Dan_DmgHealByMaxHp = 0x59;
        public const int Dan_DR = 0x56;
        public const int Dan_HealRA = 0x54;
        public const int DgR = 0x27;
        public const int DHP = 3;
        public const int DR = 0x33;
        public const int DSP = 0x10;
        public const int FAR = 0x34;
        public const int HP = 2;
        public const int HR = 0x26;
        public const int MAP = 7;
        public const int MAR = 0x23;
        public const int MaxHP = 1;
        public const int MDP = 8;
        public const int MDR = 0x24;
        public const int NUMBER_RATE_SPACE = 0x20;
        public const int PAP = 5;
        public const int PAR = 0x21;
        public const int PDP = 6;
        public const int PDR = 0x22;
        public const int PMDR = 0x25;
        public const int RCR = 0x31;
        public const int RCTL = 0x39;
        public const int RD = 0x37;
        public const int RR = 0x29;
        public const int ShiledActive = 60;
        public const int ShiledComposite = 0x3d;
        public const int ShiledNormal = 0x3b;
        public const int SP = 0x11;
        public const int SPA = 0x12;
        public const int SPD = 0x13;
        public const int SPDR = 0x36;
        public const int Speed = 4;
        public const int THGA = 0x3a;
        public const int Unknown = 0;

        public static bool Initialize()
        {
            bool flag = false;
            TypeNameContainer<_AvatarAttributeType>.SetTextSectionName("Code_AvatarAttribute");
            flag &= TypeNameContainer<_AvatarAttributeType>.RegisterType("MaxHP", 1, "AvatarAttribute_MaxHP");
            flag &= TypeNameContainer<_AvatarAttributeType>.RegisterType("HP", 2, "AvatarAttribute_HP");
            flag &= TypeNameContainer<_AvatarAttributeType>.RegisterType("DHP", 3, "AvatarAttribute_DHP");
            flag &= TypeNameContainer<_AvatarAttributeType>.RegisterType("Speed", 4, "AvatarAttribute_Speed");
            flag &= TypeNameContainer<_AvatarAttributeType>.RegisterType("PAP", 5, "AvatarAttribute_PAP");
            flag &= TypeNameContainer<_AvatarAttributeType>.RegisterType("PDP", 6, "AvatarAttribute_PDP");
            flag &= TypeNameContainer<_AvatarAttributeType>.RegisterType("MAP", 7, "AvatarAttribute_MAP");
            flag &= TypeNameContainer<_AvatarAttributeType>.RegisterType("MDP", 8, "AvatarAttribute_MDP");
            flag &= TypeNameContainer<_AvatarAttributeType>.RegisterType("BSP", 9, "AvatarAttribute_BSP");
            flag &= TypeNameContainer<_AvatarAttributeType>.RegisterType("DSP", 0x10, "AvatarAttribute_DSP");
            flag &= TypeNameContainer<_AvatarAttributeType>.RegisterType("SP", 0x11, "AvatarAttribute_SP");
            flag &= TypeNameContainer<_AvatarAttributeType>.RegisterType("SPA", 0x12, "AvatarAttribute_SPA");
            flag &= TypeNameContainer<_AvatarAttributeType>.RegisterType("SPD", 0x13, "AvatarAttribute_SPD");
            flag &= TypeNameContainer<_AvatarAttributeType>.RegisterType("PAR", 0x21, "AvatarAttribute_PAR");
            flag &= TypeNameContainer<_AvatarAttributeType>.RegisterType("PDR", 0x22, "AvatarAttribute_PDR");
            flag &= TypeNameContainer<_AvatarAttributeType>.RegisterType("MAR", 0x23, "AvatarAttribute_MAR");
            flag &= TypeNameContainer<_AvatarAttributeType>.RegisterType("MDR", 0x24, "AvatarAttribute_MDR");
            flag &= TypeNameContainer<_AvatarAttributeType>.RegisterType("PMDR", 0x25, "AvatarAttribute_PMDR");
            flag &= TypeNameContainer<_AvatarAttributeType>.RegisterType("HR", 0x26, "AvatarAttribute_HR");
            flag &= TypeNameContainer<_AvatarAttributeType>.RegisterType("DgR", 0x27, "AvatarAttribute_DgR");
            flag &= TypeNameContainer<_AvatarAttributeType>.RegisterType("CSR", 40, "AvatarAttribute_CSR");
            flag &= TypeNameContainer<_AvatarAttributeType>.RegisterType("RR", 0x29, "AvatarAttribute_RR");
            flag &= TypeNameContainer<_AvatarAttributeType>.RegisterType("CR", 0x30, "AvatarAttribute_CR");
            flag &= TypeNameContainer<_AvatarAttributeType>.RegisterType("RCR", 0x31, "AvatarAttribute_RCR");
            flag &= TypeNameContainer<_AvatarAttributeType>.RegisterType("AR", 50, "AvatarAttribute_AR");
            flag &= TypeNameContainer<_AvatarAttributeType>.RegisterType("DR", 0x33, "AvatarAttribute_DR");
            flag &= TypeNameContainer<_AvatarAttributeType>.RegisterType("FAR", 0x34, "AvatarAttribute_FAR");
            flag &= TypeNameContainer<_AvatarAttributeType>.RegisterType("CSF", 0x35, "AvatarAttribute_CSF");
            flag &= TypeNameContainer<_AvatarAttributeType>.RegisterType("SPDR", 0x36, "AvatarAttribute_SPDR");
            flag &= TypeNameContainer<_AvatarAttributeType>.RegisterType("RD", 0x37, "AvatarAttribute_RD");
            flag &= TypeNameContainer<_AvatarAttributeType>.RegisterType("CTLR", 0x38, "AvatarAttribute_CTLR");
            flag &= TypeNameContainer<_AvatarAttributeType>.RegisterType("RCTL", 0x39, "AvatarAttribute_RCTL");
            flag &= TypeNameContainer<_AvatarAttributeType>.RegisterType("THGA", 0x3a, "AvatarAttribute_THGA");
            flag &= TypeNameContainer<_AvatarAttributeType>.RegisterType("ShiledNormal", 0x3b, "AvatarAttribute_ShiledNormal");
            flag &= TypeNameContainer<_AvatarAttributeType>.RegisterType("ShiledActive", 60, "AvatarAttribute_ShiledActive");
            flag &= TypeNameContainer<_AvatarAttributeType>.RegisterType("ShiledComposite", 0x3d, "AvatarAttribute_ShiledComposite");
            flag &= TypeNameContainer<_AvatarAttributeType>.RegisterType("THGA", 0x3a);
            flag &= TypeNameContainer<_AvatarAttributeType>.RegisterType("CrtDR", 80);
            flag &= TypeNameContainer<_AvatarAttributeType>.RegisterType("CntAR", 0x51);
            flag &= TypeNameContainer<_AvatarAttributeType>.RegisterType("CntDR", 0x52);
            flag &= TypeNameContainer<_AvatarAttributeType>.RegisterType("CmpTRA", 0x53);
            flag &= TypeNameContainer<_AvatarAttributeType>.RegisterType("DmgHealR", 0x54);
            flag &= TypeNameContainer<_AvatarAttributeType>.RegisterType("Dan_AR", 0x55);
            flag &= TypeNameContainer<_AvatarAttributeType>.RegisterType("Dan_DR", 0x56);
            flag &= TypeNameContainer<_AvatarAttributeType>.RegisterType("Dan_DmgHealByDmg", 0x57);
            flag &= TypeNameContainer<_AvatarAttributeType>.RegisterType("Dan_DmgHealByAP", 0x58);
            return (flag & TypeNameContainer<_AvatarAttributeType>.RegisterType("Dan_DmgHealByMaxHp", 0x59));
        }
    }
}

