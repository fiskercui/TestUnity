namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="CG_AcceptConstructionTaskReq")]
    public class CG_AcceptConstructionTaskReq : IExtensible
    {
        private int _callback;
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

        [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="taskId", DataFormat=DataFormat.TwosComplement)]
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

        [ProtoMember(3, IsRequired=false, Name="taskIndex", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

