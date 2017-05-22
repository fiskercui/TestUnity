namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;

    [ProtoContract(Name="GC_TavernQueryRes")]
    public class GC_TavernQueryRes : IExtensible
    {
        private int _callback;
        private readonly List<TavernInfo> _infos = new List<TavernInfo>();
        private readonly List<int> _mysteryerResourceIds = new List<int>();
        private int _result;
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

        [ProtoMember(3, Name="infos", DataFormat=DataFormat.Default)]
        public List<TavernInfo> infos
        {
            get
            {
                return this._infos;
            }
        }

        [ProtoMember(4, Name="mysteryerResourceIds", DataFormat=DataFormat.TwosComplement)]
        public List<int> mysteryerResourceIds
        {
            get
            {
                return this._mysteryerResourceIds;
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

