namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="QinInfo")]
    public class QinInfo : IExtensible
    {
        private int _continueAnswerCount;
        private int _questionId;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="continueAnswerCount", DataFormat=DataFormat.TwosComplement)]
        public int continueAnswerCount
        {
            get
            {
                return this._continueAnswerCount;
            }
            set
            {
                this._continueAnswerCount = value;
            }
        }

        [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="questionId", DataFormat=DataFormat.TwosComplement)]
        public int questionId
        {
            get
            {
                return this._questionId;
            }
            set
            {
                this._questionId = value;
            }
        }
    }
}

