namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="GC_ChangeMeridianRes")]
    public class GC_ChangeMeridianRes : IExtensible
    {
        private int _buffId;
        private int _callback;
        private CostAndRewardAndSync _costAndRewardAndSync;
        private readonly List<PropertyModifier> _newModifiers = new List<PropertyModifier>();
        private int _result;
        private int _times;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(6, IsRequired=false, Name="buffId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

        [DefaultValue((string) null), ProtoMember(4, IsRequired=false, Name="costAndRewardAndSync", DataFormat=DataFormat.Default)]
        public CostAndRewardAndSync costAndRewardAndSync
        {
            get
            {
                return this._costAndRewardAndSync;
            }
            set
            {
                this._costAndRewardAndSync = value;
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

        [DefaultValue(0), ProtoMember(5, IsRequired=false, Name="times", DataFormat=DataFormat.TwosComplement)]
        public int times
        {
            get
            {
                return this._times;
            }
            set
            {
                this._times = value;
            }
        }
    }
}

