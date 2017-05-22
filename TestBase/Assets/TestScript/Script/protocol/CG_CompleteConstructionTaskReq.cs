namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="CG_CompleteConstructionTaskReq")]
    public class CG_CompleteConstructionTaskReq : IExtensible
    {
        private int _callback;
        private readonly List<Cost> _costs = new List<Cost>();
        private int _taskId;
        private int _taskIndex;
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

        [ProtoMember(4, Name="costs", DataFormat=DataFormat.Default)]
        public List<Cost> costs
        {
            get
            {
                return this._costs;
            }
        }

        [ProtoMember(2, IsRequired=false, Name="taskId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int taskId
        {
            get
            {
                return this._taskId;
            }
            set
            {
                this._taskId = value;
            }
        }

        [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="taskIndex", DataFormat=DataFormat.TwosComplement)]
        public int taskIndex
        {
            get
            {
                return this._taskIndex;
            }
            set
            {
                this._taskIndex = value;
            }
        }
    }
}

