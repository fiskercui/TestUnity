namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="AvatarResult")]
    public class AvatarResult : IExtensible
    {
        private int _avatarIndex;
        private CombatAvatarData _combatAvatarData;
        private ActionRecord _endAction;
        private int _leftHP;
        private int _maxHP;
        private int _teamIndex;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="avatarIndex", DataFormat=DataFormat.TwosComplement)]
        public int avatarIndex
        {
            get
            {
                return this._avatarIndex;
            }
            set
            {
                this._avatarIndex = value;
            }
        }

        [DefaultValue((string) null), ProtoMember(7, IsRequired=false, Name="combatAvatarData", DataFormat=DataFormat.Default)]
        public CombatAvatarData combatAvatarData
        {
            get
            {
                return this._combatAvatarData;
            }
            set
            {
                this._combatAvatarData = value;
            }
        }

        [DefaultValue((string) null), ProtoMember(6, IsRequired=false, Name="endAction", DataFormat=DataFormat.Default)]
        public ActionRecord endAction
        {
            get
            {
                return this._endAction;
            }
            set
            {
                this._endAction = value;
            }
        }

        [DefaultValue(0), ProtoMember(4, IsRequired=false, Name="leftHP", DataFormat=DataFormat.TwosComplement)]
        public int leftHP
        {
            get
            {
                return this._leftHP;
            }
            set
            {
                this._leftHP = value;
            }
        }

        [ProtoMember(3, IsRequired=false, Name="maxHP", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int maxHP
        {
            get
            {
                return this._maxHP;
            }
            set
            {
                this._maxHP = value;
            }
        }

        [ProtoMember(2, IsRequired=false, Name="teamIndex", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int teamIndex
        {
            get
            {
                return this._teamIndex;
            }
            set
            {
                this._teamIndex = value;
            }
        }
    }
}

