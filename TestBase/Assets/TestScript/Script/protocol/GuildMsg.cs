namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="GuildMsg")]
    public class GuildMsg : IExtensible
    {
        private string _msg = "";
        private int _playerId;
        private int _playerLevel;
        private string _playerName = "";
        private int _roleId;
        private long _time;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [DefaultValue(""), ProtoMember(5, IsRequired=false, Name="msg", DataFormat=DataFormat.Default)]
        public string msg
        {
            get
            {
                return this._msg;
            }
            set
            {
                this._msg = value;
            }
        }

        [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="playerId", DataFormat=DataFormat.TwosComplement)]
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

        [DefaultValue(0), ProtoMember(6, IsRequired=false, Name="playerLevel", DataFormat=DataFormat.TwosComplement)]
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

        [DefaultValue(""), ProtoMember(3, IsRequired=false, Name="playerName", DataFormat=DataFormat.Default)]
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

        [ProtoMember(4, IsRequired=false, Name="roleId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

        [DefaultValue((long) 0L), ProtoMember(1, IsRequired=false, Name="time", DataFormat=DataFormat.TwosComplement)]
        public long time
        {
            get
            {
                return this._time;
            }
            set
            {
                this._time = value;
            }
        }
    }
}

