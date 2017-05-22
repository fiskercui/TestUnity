namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="HiredDiner")]
    public class HiredDiner : IExtensible
    {
        private string _avatarGuid = "";
        private int _dinerId;
        private long _endTime;
        private long _hireTime;
        private int _qualityType;
        private int _state;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [DefaultValue(""), ProtoMember(3, IsRequired=false, Name="avatarGuid", DataFormat=DataFormat.Default)]
        public string avatarGuid
        {
            get
            {
                return this._avatarGuid;
            }
            set
            {
                this._avatarGuid = value;
            }
        }

        [ProtoMember(2, IsRequired=false, Name="dinerId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int dinerId
        {
            get
            {
                return this._dinerId;
            }
            set
            {
                this._dinerId = value;
            }
        }

        [DefaultValue((long) 0L), ProtoMember(5, IsRequired=false, Name="endTime", DataFormat=DataFormat.TwosComplement)]
        public long endTime
        {
            get
            {
                return this._endTime;
            }
            set
            {
                this._endTime = value;
            }
        }

        [DefaultValue((long) 0L), ProtoMember(4, IsRequired=false, Name="hireTime", DataFormat=DataFormat.TwosComplement)]
        public long hireTime
        {
            get
            {
                return this._hireTime;
            }
            set
            {
                this._hireTime = value;
            }
        }

        [ProtoMember(1, IsRequired=false, Name="qualityType", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int qualityType
        {
            get
            {
                return this._qualityType;
            }
            set
            {
                this._qualityType = value;
            }
        }

        [ProtoMember(6, IsRequired=false, Name="state", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int state
        {
            get
            {
                return this._state;
            }
            set
            {
                this._state = value;
            }
        }
    }
}

