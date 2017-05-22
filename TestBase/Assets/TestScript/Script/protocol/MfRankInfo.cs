namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="MfRankInfo")]
    public class MfRankInfo : IExtensible
    {
        private int _arrivalLayer;
        private int _playerId;
        private string _playerName = "";
        private int _point;
        private int _power;
        private int _rank;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(4, IsRequired=false, Name="arrivalLayer", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int arrivalLayer
        {
            get
            {
                return this._arrivalLayer;
            }
            set
            {
                this._arrivalLayer = value;
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

        [ProtoMember(3, IsRequired=false, Name="point", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int point
        {
            get
            {
                return this._point;
            }
            set
            {
                this._point = value;
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

        [DefaultValue(0), ProtoMember(5, IsRequired=false, Name="rank", DataFormat=DataFormat.TwosComplement)]
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
    }
}

