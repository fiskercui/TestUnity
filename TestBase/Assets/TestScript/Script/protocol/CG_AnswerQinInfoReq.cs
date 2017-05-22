namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="CG_AnswerQinInfoReq")]
    public class CG_AnswerQinInfoReq : IExtensible
    {
        private int _answerEnum;
        private int _callback;
        private int _questionId;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(3, IsRequired=false, Name="answerEnum", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int answerEnum
        {
            get
            {
                return this._answerEnum;
            }
            set
            {
                this._answerEnum = value;
            }
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

        [ProtoMember(2, IsRequired=false, Name="questionId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

