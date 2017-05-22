namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;

    [ProtoContract(Name="ReturnExceptionCallback")]
    public class ReturnExceptionCallback : IExtensible
    {
        private int _exceptionCallback;
        private int _result;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(1, IsRequired=true, Name="exceptionCallback", DataFormat=DataFormat.TwosComplement)]
        public int exceptionCallback
        {
            get
            {
                return this._exceptionCallback;
            }
            set
            {
                this._exceptionCallback = value;
            }
        }

        [ProtoMember(2, IsRequired=true, Name="result", DataFormat=DataFormat.TwosComplement)]
        public int result
        {
            get
            {
                return this._result;
            }
            set
            {
                this._result = value;
            }
        }
    }
}

