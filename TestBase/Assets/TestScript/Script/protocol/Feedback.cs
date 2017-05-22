namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="Feedback")]
    public class Feedback : IExtensible
    {
        private int _area;
        private string _content = "";
        private int _infoId;
        private int _parentInfoId;
        private int _parentInfoPlayerId;
        private int _playerId;
        private long _sendTime;
        private int _type;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(5, IsRequired=false, Name="area", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int area
        {
            get
            {
                return this._area;
            }
            set
            {
                this._area = value;
            }
        }

        [DefaultValue(""), ProtoMember(7, IsRequired=false, Name="content", DataFormat=DataFormat.Default)]
        public string content
        {
            get
            {
                return this._content;
            }
            set
            {
                this._content = value;
            }
        }

        [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="infoId", DataFormat=DataFormat.TwosComplement)]
        public int infoId
        {
            get
            {
                return this._infoId;
            }
            set
            {
                this._infoId = value;
            }
        }

        [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="parentInfoId", DataFormat=DataFormat.TwosComplement)]
        public int parentInfoId
        {
            get
            {
                return this._parentInfoId;
            }
            set
            {
                this._parentInfoId = value;
            }
        }

        [DefaultValue(0), ProtoMember(4, IsRequired=false, Name="parentInfoPlayerId", DataFormat=DataFormat.TwosComplement)]
        public int parentInfoPlayerId
        {
            get
            {
                return this._parentInfoPlayerId;
            }
            set
            {
                this._parentInfoPlayerId = value;
            }
        }

        [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="playerId", DataFormat=DataFormat.TwosComplement)]
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

        [DefaultValue((long) 0L), ProtoMember(8, IsRequired=false, Name="sendTime", DataFormat=DataFormat.TwosComplement)]
        public long sendTime
        {
            get
            {
                return this._sendTime;
            }
            set
            {
                this._sendTime = value;
            }
        }

        [ProtoMember(6, IsRequired=false, Name="type", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int type
        {
            get
            {
                return this._type;
            }
            set
            {
                this._type = value;
            }
        }
    }
}

