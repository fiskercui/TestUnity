namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="GuildApplyInfo")]
    public class GuildApplyInfo : IExtensible
    {
        private int _playerId;
        private int _playerLevel;
        private string _playerName = "";
        private int _power;
        private int _rank;
        private long _time;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
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

        [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="playerLevel", DataFormat=DataFormat.TwosComplement)]
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

        [DefaultValue(0), ProtoMember(6, IsRequired=false, Name="power", DataFormat=DataFormat.TwosComplement)]
        public int power
        {
            get
            {
                return this._power;
            }
            set
            {
                this._power = value;
            }
        }

        [ProtoMember(4, IsRequired=false, Name="rank", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int rank
        {
            get
            {
                return this._rank;
            }
            set
            {
                this._rank = value;
            }
        }

        [ProtoMember(5, IsRequired=false, Name="time", DataFormat=DataFormat.TwosComplement), DefaultValue((long) 0L)]
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

