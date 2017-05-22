namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="GC_SaveMeridianRes")]
    public class GC_SaveMeridianRes : IExtensible
    {
        private int _buffId;
        private int _callback;
        private readonly List<PropertyModifier> _newModifiers = new List<PropertyModifier>();
        private int _result;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [DefaultValue(0), ProtoMember(4, IsRequired=false, Name="buffId", DataFormat=DataFormat.TwosComplement)]
        public int buffId
        {
            get
            {
                return this._buffId;
            }
            set
            {
                this._buffId = value;
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

        [ProtoMember(3, Name="newModifiers", DataFormat=DataFormat.Default)]
        public List<PropertyModifier> newModifiers
        {
            get
            {
                return this._newModifiers;
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

