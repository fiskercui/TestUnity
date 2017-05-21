namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="Buff")]
    public class Buff : IExtensible
    {
        private readonly List<AvatarAction> _actions = new List<AvatarAction>();
        private int _buffType;
        private int _conflictStrategy;
        private readonly List<AvatarAction.Effect> _effects = new List<AvatarAction.Effect>();
        private int _id;
        private readonly List<PropertyModifierSet> _modifierSets = new List<PropertyModifierSet>();
        private int _superpositionType;
        private string _uiName = "";
        private IExtension extensionObject;

        public static int ComposeBuffActionID(int actionID, int buffID)
        {
            if (!AvatarAction.IsBuffActionID(actionID))
            {
                return 0;
            }
            return ((actionID & -65536) | (buffID & 0xffff));
        }

        public AvatarAction GetActionById(int id)
        {
            foreach (AvatarAction action in this.actions)
            {
                if (action.id == id)
                {
                    return action;
                }
            }
            return null;
        }

        public AvatarAction GetActionByType(int type)
        {
            foreach (AvatarAction action in this.actions)
            {
                if (action.actionType == type)
                {
                    return action;
                }
            }
            return null;
        }

        public static int GetActionIDFromBuffActionID(int actionID)
        {
            if (!AvatarAction.IsBuffActionID(actionID))
            {
                return 0;
            }
            return (actionID & ((int) 0x07fff0000L));
        }

        public static int GetBuffIDFromBuffActionID(int actionID)
        {
            if (!AvatarAction.IsBuffActionID(actionID))
            {
                return 0;
            }
            return (0x5000000 | (actionID & 0xffff));
        }

        public PropertyModifierSet GetModifierSetByLevelFilter(int levelFilter)
        {
            foreach (PropertyModifierSet set in this.modifierSets)
            {
                if (set.levelFilter == levelFilter)
                {
                    return set;
                }
            }
            return null;
        }

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(4, Name="actions", DataFormat=DataFormat.Default)]
        public List<AvatarAction> actions
        {
            get
            {
                return this._actions;
            }
        }

        [DefaultValue(0), ProtoMember(8, IsRequired=false, Name="buffType", DataFormat=DataFormat.TwosComplement)]
        public int buffType
        {
            get
            {
                return this._buffType;
            }
            set
            {
                this._buffType = value;
            }
        }

        [ProtoMember(10, IsRequired=false, Name="conflictStrategy", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int conflictStrategy
        {
            get
            {
                return this._conflictStrategy;
            }
            set
            {
                this._conflictStrategy = value;
            }
        }

        [ProtoMember(5, Name="effects", DataFormat=DataFormat.Default)]
        public List<AvatarAction.Effect> effects
        {
            get
            {
                return this._effects;
            }
        }

        [ProtoMember(1, IsRequired=false, Name="id", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int id
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }

        [ProtoMember(2, Name="modifierSets", DataFormat=DataFormat.Default)]
        public List<PropertyModifierSet> modifierSets
        {
            get
            {
                return this._modifierSets;
            }
        }

        [ProtoMember(9, IsRequired=false, Name="superpositionType", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int superpositionType
        {
            get
            {
                return this._superpositionType;
            }
            set
            {
                this._superpositionType = value;
            }
        }

        [DefaultValue(""), ProtoMember(7, IsRequired=false, Name="uiName", DataFormat=DataFormat.Default)]
        public string uiName
        {
            get
            {
                return this._uiName;
            }
            set
            {
                this._uiName = value;
            }
        }

        public class _BuffType : TypeNameContainer<ClientServerCommon.Buff._BuffType>
        {
            public const int All = -1;
            public const int Beneficial = 2;
            public const int Domineer = 0x40;
            public const int Dot = 8;
            public const int Harmful = 4;
            public const int Hot = 0x10;
            public const int Normal = 1;
            public const int Stun = 0x20;
            public const int Unknown = 0;

            public static bool Initialize()
            {
                bool flag = false;
                flag &= TypeNameContainer<ClientServerCommon.Buff._BuffType>.RegisterType("Normal", 1);
                flag &= TypeNameContainer<ClientServerCommon.Buff._BuffType>.RegisterType("Beneficial", 2);
                flag &= TypeNameContainer<ClientServerCommon.Buff._BuffType>.RegisterType("Harmful", 4);
                flag &= TypeNameContainer<ClientServerCommon.Buff._BuffType>.RegisterType("Dot", 8);
                flag &= TypeNameContainer<ClientServerCommon.Buff._BuffType>.RegisterType("Hot", 0x10);
                flag &= TypeNameContainer<ClientServerCommon.Buff._BuffType>.RegisterType("Stun", 0x20);
                flag &= TypeNameContainer<ClientServerCommon.Buff._BuffType>.RegisterType("Domineer", 0x40);
                return (flag & TypeNameContainer<ClientServerCommon.Buff._BuffType>.RegisterType("All", -1));
            }
        }

        public class _ConflictStrategy : TypeNameContainer<ClientServerCommon.Buff._ConflictStrategy>
        {
            public const int KeepLongestDuration = 2;
            public const int SuperpositionIfDifferentSrcAvatar_ElseUpdateDuration = 3;
            public const int UpdateDuration = 1;

            public static bool Initialize()
            {
                bool flag = false;
                flag &= TypeNameContainer<ClientServerCommon.Buff._ConflictStrategy>.RegisterType("UpdateDuration", 1);
                flag &= TypeNameContainer<ClientServerCommon.Buff._ConflictStrategy>.RegisterType("KeepLongestDuration", 2);
                return (flag & TypeNameContainer<ClientServerCommon.Buff._ConflictStrategy>.RegisterType("SuperpositionIfDifferentSrcAvatar_ElseUpdateDuration", 3));
            }
        }

        public class _DurationCheckType : TypeNameContainer<ClientServerCommon.Buff._DurationCheckType>
        {
            public const int AftarMainAction = 2;
            public const int AftarRound = 1;
            public const int Count = 3;
            public const int NoCheck = 0;

            public static bool Initialize()
            {
                bool flag = false;
                flag &= TypeNameContainer<ClientServerCommon.Buff._DurationCheckType>.RegisterType("NoCheck", 0);
                flag &= TypeNameContainer<ClientServerCommon.Buff._DurationCheckType>.RegisterType("AftarRound", 1);
                return (flag & TypeNameContainer<ClientServerCommon.Buff._DurationCheckType>.RegisterType("AftarMainAction", 2));
            }
        }

        public class _SuperpositionType : TypeNameContainer<ClientServerCommon.Buff._SuperpositionType>
        {
            public const int IDMutualExclusion = 1;
            public const int IDSuperposition = 2;
            public const int TypeMutualExclusion = 3;

            public static bool Initialize()
            {
                bool flag = false;
                flag &= TypeNameContainer<ClientServerCommon.Buff._SuperpositionType>.RegisterType("IDMutualExclusion", 1);
                flag &= TypeNameContainer<ClientServerCommon.Buff._SuperpositionType>.RegisterType("IDSuperposition", 2);
                return (flag & TypeNameContainer<ClientServerCommon.Buff._SuperpositionType>.RegisterType("TypeMutualExclusion", 3));
            }
        }
    }
}

