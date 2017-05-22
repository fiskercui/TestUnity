namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="GC_ResetWolfSmokeRes")]
    public class GC_ResetWolfSmokeRes : IExtensible
    {
        private int _callback;
        private bool _isJoin;
        private int _result;
        private WolfInfo _wolfInfo;
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

        [DefaultValue(false), ProtoMember(3, IsRequired=false, Name="isJoin", DataFormat=DataFormat.Default)]
        public bool isJoin
        {
            get
            {
                return this._isJoin;
            }
            set
            {
                this._isJoin = value;
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

        [DefaultValue((string) null), ProtoMember(4, IsRequired=false, Name="wolfInfo", DataFormat=DataFormat.Default)]
        public WolfInfo wolfInfo
        {
            get
            {
                return this._wolfInfo;
            }
            set
            {
                this._wolfInfo = value;
            }
        }
    }
}

