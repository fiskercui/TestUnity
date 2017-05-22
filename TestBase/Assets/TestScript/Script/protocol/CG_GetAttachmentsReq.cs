namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="CG_GetAttachmentsReq")]
    public class CG_GetAttachmentsReq : IExtensible
    {
        private int _callback;
        private long _emailId;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="callback", DataFormat=DataFormat.TwosComplement)]
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

        [ProtoMember(2, IsRequired=false, Name="emailId", DataFormat=DataFormat.ZigZag), DefaultValue((long) 0L)]
        public long emailId
        {
            get
            {
                return this._emailId;
            }
            set
            {
                this._emailId = value;
            }
        }
    }
}

