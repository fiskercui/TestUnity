namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="CG_SetZoneStatusReq")]
    public class CG_SetZoneStatusReq : IExtensible
    {
        private int _callback;
        private int _status;
        private int _zoneId;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(1, IsRequired=true, Name="callback", DataFormat=DataFormat.TwosComplement)]
        public int callback
        {
            get
            {
                return this._callback;
            }
            set
            {
                this._callback = value;
            }
        }

        [ProtoMember(3, IsRequired=false, Name="status", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

        [ProtoMember(2, IsRequired=false, Name="zoneId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int zoneId
        {
            get
            {
                return this._zoneId;
            }
            set
            {
                this._zoneId = value;
            }
        }
    }
}

