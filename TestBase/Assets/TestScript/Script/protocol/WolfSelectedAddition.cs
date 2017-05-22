namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="WolfSelectedAddition")]
    public class WolfSelectedAddition : IExtensible
    {
        private int _additionId;
        private int _stageId;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="additionId", DataFormat=DataFormat.TwosComplement)]
        public int additionId
        {
            get
            {
                return this._additionId;
            }
            set
            {
                this._additionId = value;
            }
        }

        [ProtoMember(1, IsRequired=false, Name="stageId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int stageId
        {
            get
            {
                return this._stageId;
            }
            set
            {
                this._stageId = value;
            }
        }
    }
}

