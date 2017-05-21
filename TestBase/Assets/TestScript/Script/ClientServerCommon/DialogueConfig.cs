namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Security;

    [ProtoContract(Name="DialogueConfig")]
    public class DialogueConfig : Configuration, IExtensible
    {
        private readonly List<DialogueSet> _dialogueSets = new List<DialogueSet>();
        private Dictionary<int, DialogueSet> _id_DialogueSet = new Dictionary<int, DialogueSet>();
        private readonly List<int> _playerAssistantPortraitIcons = new List<int>();
        private readonly List<int> _playerPortraitIcons = new List<int>();
        private int _tutorialAfterCombat;
        private int _tutorialBeforeCombat;
        private IExtension extensionObject;

        public override void ConstructLogicData(ConfigDatabase cfgDB, int fileFormat)
        {
            base.ConstructLogicData(cfgDB, fileFormat);
            foreach (DialogueSet set in this._dialogueSets)
            {
                if (set != null)
                {
                    if (this._id_DialogueSet.ContainsKey(set.dialogueSetId))
                    {
                        Logger.Error(base.GetType().Name + " ContainsKey 0x" + set.dialogueSetId.ToString("X"), new object[0]);
                    }
                    else
                    {
                        this._id_DialogueSet.Add(set.dialogueSetId, set);
                    }
                }
            }
        }

        public DialogueSet GetDialogueSet(int dialogueSetId)
        {
            DialogueSet set;
            if (!this._id_DialogueSet.TryGetValue(dialogueSetId, out set))
            {
                return null;
            }
            return set;
        }

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        public static void Initialize()
        {
            _CampType.Initialize();
            _PositionType.Initialize();
            _PortraitType.Initialize();
            _PortraitDisplayType.Initialize();
        }

        private DialogueSet LoadDialogueSetFromXml(SecurityElement element)
        {
            DialogueSet set = new DialogueSet {
                dialogueSetId = StrParser.ParseHexInt(element.Attribute("DialogueSetId"), 0),
                combatDialogue = StrParser.ParseBool(element.Attribute("CombatDialogue"), false)
            };
            if (element.Children != null)
            {
                for (int i = 0; i < element.Children.Count; i++)
                {
                    string str;
                    SecurityElement element2 = element.Children[i] as SecurityElement;
                    if (((str = element2.Tag) != null) && (str == "Dialogues"))
                    {
                        set.dialogues.Add(this.LoadDialoguesFromXml(element2, i));
                    }
                }
            }
            return set;
        }

        private Dialogues LoadDialoguesFromXml(SecurityElement element, int dialogueIndex)
        {
            return new Dialogues { 
                dialogueIndex = dialogueIndex,
                dialogueCampType = TypeNameContainer<_CampType>.Parse(element.Attribute("DialogueCampType"), 0),
                positionType = TypeNameContainer<_PositionType>.Parse(element.Attribute("PositionType"), 0),
                portraitType = TypeNameContainer<_PortraitType>.Parse(element.Attribute("PortraitType"), 0),
                portraitDisplayType = TypeNameContainer<_PortraitDisplayType>.Parse(element.Attribute("PortraitDisplayType"), 0),
                avatarId = StrParser.ParseHexInt(element.Attribute("AvatarId"), 0),
                portraitAnimation = StrParser.ParseStr(element.Attribute("PortraitAnimation"), ""),
                portraitName = StrParser.ParseStr(element.Attribute("PortraitName"), "", true),
                npcId = StrParser.ParseHexInt(element.Attribute("NpcId"), 0),
                npcStageIndex = StrParser.ParseDecInt(element.Attribute("NpcStageIndex"), 0),
                npcTeamIndex = StrParser.ParseDecInt(element.Attribute("NpcTeamIndex"), 0),
                npcIndex = StrParser.ParseDecInt(element.Attribute("NpcIndex"), 0),
                avatarAnimation = StrParser.ParseStr(element.Attribute("AvatarAnimation"), ""),
                dialogueValue = StrParser.ParseStr(element.Attribute("DialogueValue"), "", true),
                portraitIconIndex = StrParser.ParseDecInt(element.Attribute("PortraitIconIndex"), 0)
            };
        }

        public override void LoadFromXml(SecurityElement element)
        {
            if ((element.Tag == "Dialogue") && (element.Children != null))
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string tag = element2.Tag;
                    if (tag != null)
                    {
                        if (tag != "DialogueSet")
                        {
                            if (tag == "PlayerPortraitIcon")
                            {
                                goto Label_0084;
                            }
                            if (tag == "PlayerAssistantPortraitIcon")
                            {
                                goto Label_00A2;
                            }
                        }
                        else
                        {
                            DialogueSet item = this.LoadDialogueSetFromXml(element2);
                            this._dialogueSets.Add(item);
                        }
                    }
                    continue;
                Label_0084:
                    this.playerPortraitIcons.Add(StrParser.ParseHexInt(element2.Attribute("Id"), 0));
                    continue;
                Label_00A2:
                    this.playerAssistantPortraitIcons.Add(StrParser.ParseHexInt(element2.Attribute("Id"), 0));
                }
            }
        }

        [ProtoMember(1, Name="dialogueSets", DataFormat=DataFormat.Default)]
        public List<DialogueSet> dialogueSets
        {
            get
            {
                return this._dialogueSets;
            }
        }

        [ProtoMember(5, Name="playerAssistantPortraitIcons", DataFormat=DataFormat.TwosComplement)]
        public List<int> playerAssistantPortraitIcons
        {
            get
            {
                return this._playerAssistantPortraitIcons;
            }
        }

        [ProtoMember(4, Name="playerPortraitIcons", DataFormat=DataFormat.TwosComplement)]
        public List<int> playerPortraitIcons
        {
            get
            {
                return this._playerPortraitIcons;
            }
        }

        [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="tutorialAfterCombat", DataFormat=DataFormat.TwosComplement)]
        public int tutorialAfterCombat
        {
            get
            {
                return this._tutorialAfterCombat;
            }
            set
            {
                this._tutorialAfterCombat = value;
            }
        }

        [ProtoMember(2, IsRequired=false, Name="tutorialBeforeCombat", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int tutorialBeforeCombat
        {
            get
            {
                return this._tutorialBeforeCombat;
            }
            set
            {
                this._tutorialBeforeCombat = value;
            }
        }

        public class _CampType : TypeNameContainer<DialogueConfig._CampType>
        {
            public const int Enemy = 2;
            public const int MyRange = 1;
            public const int Other = 3;
            public const int Unknown = 0;

            public static bool Initialize()
            {
                bool flag = false;
                flag &= TypeNameContainer<DialogueConfig._CampType>.RegisterType("Unknown", 0, "Dialogue_CampTye_Unknown");
                flag &= TypeNameContainer<DialogueConfig._CampType>.RegisterType("MyRange", 1, "Dialogue_CampTye_MyRange");
                flag &= TypeNameContainer<DialogueConfig._CampType>.RegisterType("Enemy", 2, "Dialogue_CampTye_Enemy");
                return (flag & TypeNameContainer<DialogueConfig._CampType>.RegisterType("Other", 3, "Dialogue_CampTye_Other"));
            }
        }

        public class _PortraitDisplayType : TypeNameContainer<DialogueConfig._PortraitDisplayType>
        {
            public const int None = 1;
            public const int Portrait2D = 2;
            public const int Portrait3D = 3;
            public const int Unknown = 0;

            public static bool Initialize()
            {
                bool flag = false;
                flag &= TypeNameContainer<DialogueConfig._PortraitDisplayType>.RegisterType("Unknown", 0);
                flag &= TypeNameContainer<DialogueConfig._PortraitDisplayType>.RegisterType("None", 1);
                flag &= TypeNameContainer<DialogueConfig._PortraitDisplayType>.RegisterType("Portrait2D", 2);
                return (flag & TypeNameContainer<DialogueConfig._PortraitDisplayType>.RegisterType("Portrait3D", 3));
            }
        }

        public class _PortraitType : TypeNameContainer<DialogueConfig._PortraitType>
        {
            public const int Avatar = 3;
            public const int Npc = 4;
            public const int Player = 1;
            public const int PlayerAssistant = 2;
            public const int Unknown = 0;

            public static bool Initialize()
            {
                bool flag = false;
                flag &= TypeNameContainer<DialogueConfig._PortraitType>.RegisterType("Unknown", 0);
                flag &= TypeNameContainer<DialogueConfig._PortraitType>.RegisterType("Player", 1);
                flag &= TypeNameContainer<DialogueConfig._PortraitType>.RegisterType("PlayerAssistant", 2);
                flag &= TypeNameContainer<DialogueConfig._PortraitType>.RegisterType("Avatar", 3);
                return (flag & TypeNameContainer<DialogueConfig._PortraitType>.RegisterType("Npc", 4));
            }
        }

        public class _PositionType : TypeNameContainer<DialogueConfig._PositionType>
        {
            public const int Left = 1;
            public const int Right = 2;
            public const int Unknown = 0;

            public static bool Initialize()
            {
                bool flag = false;
                flag &= TypeNameContainer<DialogueConfig._PositionType>.RegisterType("Unknown", 0);
                flag &= TypeNameContainer<DialogueConfig._PositionType>.RegisterType("Left", 1);
                return (flag & TypeNameContainer<DialogueConfig._PositionType>.RegisterType("Right", 2));
            }
        }

        [ProtoContract(Name="Dialogues")]
        public class Dialogues : IExtensible
        {
            private string _avatarAnimation = "";
            private int _avatarId;
            private int _dialogueCampType;
            private int _dialogueIndex;
            private string _dialogueValue = "";
            private int _npcId;
            private int _npcIndex;
            private int _npcStageIndex;
            private int _npcTeamIndex;
            private string _portraitAnimation = "";
            private int _portraitDisplayType;
            private int _portraitIconIndex;
            private string _portraitName = "";
            private int _portraitType;
            private int _positionType;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(12, IsRequired=false, Name="avatarAnimation", DataFormat=DataFormat.Default), DefaultValue("")]
            public string avatarAnimation
            {
                get
                {
                    return this._avatarAnimation;
                }
                set
                {
                    this._avatarAnimation = value;
                }
            }

            [DefaultValue(0), ProtoMember(5, IsRequired=false, Name="avatarId", DataFormat=DataFormat.TwosComplement)]
            public int avatarId
            {
                get
                {
                    return this._avatarId;
                }
                set
                {
                    this._avatarId = value;
                }
            }

            [ProtoMember(1, IsRequired=false, Name="dialogueCampType", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int dialogueCampType
            {
                get
                {
                    return this._dialogueCampType;
                }
                set
                {
                    this._dialogueCampType = value;
                }
            }

            [ProtoMember(15, IsRequired=false, Name="dialogueIndex", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int dialogueIndex
            {
                get
                {
                    return this._dialogueIndex;
                }
                set
                {
                    this._dialogueIndex = value;
                }
            }

            [ProtoMember(13, IsRequired=false, Name="dialogueValue", DataFormat=DataFormat.Default), DefaultValue("")]
            public string dialogueValue
            {
                get
                {
                    return this._dialogueValue;
                }
                set
                {
                    this._dialogueValue = value;
                }
            }

            [ProtoMember(11, IsRequired=false, Name="npcId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int npcId
            {
                get
                {
                    return this._npcId;
                }
                set
                {
                    this._npcId = value;
                }
            }

            [ProtoMember(10, IsRequired=false, Name="npcIndex", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int npcIndex
            {
                get
                {
                    return this._npcIndex;
                }
                set
                {
                    this._npcIndex = value;
                }
            }

            [DefaultValue(0), ProtoMember(8, IsRequired=false, Name="npcStageIndex", DataFormat=DataFormat.TwosComplement)]
            public int npcStageIndex
            {
                get
                {
                    return this._npcStageIndex;
                }
                set
                {
                    this._npcStageIndex = value;
                }
            }

            [ProtoMember(9, IsRequired=false, Name="npcTeamIndex", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int npcTeamIndex
            {
                get
                {
                    return this._npcTeamIndex;
                }
                set
                {
                    this._npcTeamIndex = value;
                }
            }

            [DefaultValue(""), ProtoMember(6, IsRequired=false, Name="portraitAnimation", DataFormat=DataFormat.Default)]
            public string portraitAnimation
            {
                get
                {
                    return this._portraitAnimation;
                }
                set
                {
                    this._portraitAnimation = value;
                }
            }

            [ProtoMember(4, IsRequired=false, Name="portraitDisplayType", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int portraitDisplayType
            {
                get
                {
                    return this._portraitDisplayType;
                }
                set
                {
                    this._portraitDisplayType = value;
                }
            }

            [DefaultValue(0), ProtoMember(14, IsRequired=false, Name="portraitIconIndex", DataFormat=DataFormat.TwosComplement)]
            public int portraitIconIndex
            {
                get
                {
                    return this._portraitIconIndex;
                }
                set
                {
                    this._portraitIconIndex = value;
                }
            }

            [ProtoMember(7, IsRequired=false, Name="portraitName", DataFormat=DataFormat.Default), DefaultValue("")]
            public string portraitName
            {
                get
                {
                    return this._portraitName;
                }
                set
                {
                    this._portraitName = value;
                }
            }

            [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="portraitType", DataFormat=DataFormat.TwosComplement)]
            public int portraitType
            {
                get
                {
                    return this._portraitType;
                }
                set
                {
                    this._portraitType = value;
                }
            }

            [ProtoMember(2, IsRequired=false, Name="positionType", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int positionType
            {
                get
                {
                    return this._positionType;
                }
                set
                {
                    this._positionType = value;
                }
            }
        }

        [ProtoContract(Name="DialogueSet")]
        public class DialogueSet : IExtensible
        {
            private bool _combatDialogue;
            private readonly List<DialogueConfig.Dialogues> _dialogues = new List<DialogueConfig.Dialogues>();
            private int _dialogueSetId;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(3, IsRequired=false, Name="combatDialogue", DataFormat=DataFormat.Default), DefaultValue(false)]
            public bool combatDialogue
            {
                get
                {
                    return this._combatDialogue;
                }
                set
                {
                    this._combatDialogue = value;
                }
            }

            [ProtoMember(2, Name="dialogues", DataFormat=DataFormat.Default)]
            public List<DialogueConfig.Dialogues> dialogues
            {
                get
                {
                    return this._dialogues;
                }
            }

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="dialogueSetId", DataFormat=DataFormat.TwosComplement)]
            public int dialogueSetId
            {
                get
                {
                    return this._dialogueSetId;
                }
                set
                {
                    this._dialogueSetId = value;
                }
            }
        }
    }
}

