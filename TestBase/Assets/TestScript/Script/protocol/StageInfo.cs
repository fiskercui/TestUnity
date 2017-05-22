namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="StageInfo")]
    public class StageInfo : IExtensible
    {
        private readonly List<AvatarHp> _avatarHps = new List<AvatarHp>();
        private int _difficult;
        private int _eventType;
        private readonly List<ShowReward> _extraShowRewards = new List<ShowReward>();
        private int _iconId;
        private int _index;
        private string _name = "";
        private Player _player;
        private readonly List<ShowReward> _showRewards = new List<ShowReward>();
        private int _status;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(9, Name="avatarHps", DataFormat=DataFormat.Default)]
        public List<AvatarHp> avatarHps
        {
            get
            {
                return this._avatarHps;
            }
        }

        [ProtoMember(10, IsRequired=false, Name="difficult", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int difficult
        {
            get
            {
                return this._difficult;
            }
            set
            {
                this._difficult = value;
            }
        }

        [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="eventType", DataFormat=DataFormat.TwosComplement)]
        public int eventType
        {
            get
            {
                return this._eventType;
            }
            set
            {
                this._eventType = value;
            }
        }

        [ProtoMember(7, Name="extraShowRewards", DataFormat=DataFormat.Default)]
        public List<ShowReward> extraShowRewards
        {
            get
            {
                return this._extraShowRewards;
            }
        }

        [DefaultValue(0), ProtoMember(4, IsRequired=false, Name="iconId", DataFormat=DataFormat.TwosComplement)]
        public int iconId
        {
            get
            {
                return this._iconId;
            }
            set
            {
                this._iconId = value;
            }
        }

        [ProtoMember(1, IsRequired=false, Name="index", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int index
        {
            get
            {
                return this._index;
            }
            set
            {
                this._index = value;
            }
        }

        [DefaultValue(""), ProtoMember(5, IsRequired=false, Name="name", DataFormat=DataFormat.Default)]
        public string name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
            }
        }

        [DefaultValue((string) null), ProtoMember(8, IsRequired=false, Name="player", DataFormat=DataFormat.Default)]
        public Player player
        {
            get
            {
                return this._player;
            }
            set
            {
                this._player = value;
            }
        }

        [ProtoMember(6, Name="showRewards", DataFormat=DataFormat.Default)]
        public List<ShowReward> showRewards
        {
            get
            {
                return this._showRewards;
            }
        }

        [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="status", DataFormat=DataFormat.TwosComplement)]
        public int status
        {
            get
            {
                return this._status;
            }
            set
            {
                this._status = value;
            }
        }
    }
}

