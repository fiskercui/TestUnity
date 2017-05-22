namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="CG_MergeIllustrationReq")]
    public class CG_MergeIllustrationReq : IExtensible
    {
        private int _callback;
        private int _count;
        private int _illustrationId;
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

        [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="count", DataFormat=DataFormat.TwosComplement)]
        public int count
        {
            get
            {
                return this._count;
            }
            set
            {
                this._count = value;
            }
        }

        [ProtoMember(2, IsRequired=false, Name="illustrationId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int illustrationId
        {
            get
            {
                return this._illustrationId;
            }
            set
            {
                this._illustrationId = value;
            }
        }
    }
}

