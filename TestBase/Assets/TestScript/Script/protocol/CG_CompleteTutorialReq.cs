namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="CG_CompleteTutorialReq")]
    public class CG_CompleteTutorialReq : IExtensible
    {
        private int _callback;
        private int _tutorialId;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(1, IsRequired=false, Name="callback", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

        [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="tutorialId", DataFormat=DataFormat.TwosComplement)]
        public int tutorialId
        {
            get
            {
                return this._tutorialId;
            }
            set
            {
                this._tutorialId = value;
            }
        }
    }
}

