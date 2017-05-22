namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="GuildTransferMember")]
    public class GuildTransferMember : IExtensible
    {
        private long _joinTime;
        private int _playerId;
        private int _playerLevel;
        private string _playerName = "";
        private int _roleId;
        private int _totalContribution;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [DefaultValue((long) 0L), ProtoMember(6, IsRequired=false, Name="joinTime", DataFormat=DataFormat.TwosComplement)]
        public long joinTime
        {
            get
            {
                return this._joinTime;
            }
            set
            {
                this._joinTime = value;
            }
        }

        [ProtoMember(1, IsRequired=false, Name="playerId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int playerId
        {
            get
            {
                return this._playerId;
            }
            set
            {
                this._playerId = value;
            }
        }

        [DefaultValue(0), ProtoMember(4, IsRequired=false, Name="playerLevel", DataFormat=DataFormat.TwosComplement)]
        public int playerLevel
        {
            get
            {
                return this._playerLevel;
            }
            set
            {
                this._playerLevel = value;
            }
        }

        [DefaultValue(""), ProtoMember(2, IsRequired=false, Name="playerName", DataFormat=DataFormat.Default)]
        public string playerName
        {
            get
            {
                return this._playerName;
            }
            set
            {
                this._playerName = value;
            }
        }

        [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="roleId", DataFormat=DataFormat.TwosComplement)]
        public int roleId
        {
            get
            {
                return this._roleId;
            }
            set
            {
                this._roleId = value;
            }
        }

        [ProtoMember(5, IsRequired=false, Name="totalContribution", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int totalContribution
        {
            get
            {
                return this._totalContribution;
            }
            set
            {
                this._totalContribution = value;
            }
        }
    }
}

