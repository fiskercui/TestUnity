namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="GC_AccomplishInvisibleTaskNotify")]
    public class GC_AccomplishInvisibleTaskNotify : IExtensible
    {
        private int _taskId;
        private int _taskStatus;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="taskId", DataFormat=DataFormat.TwosComplement)]
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

        [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="taskStatus", DataFormat=DataFormat.TwosComplement)]
        public int taskStatus
        {
            get
            {
                return this._taskStatus;
            }
            set
            {
                this._taskStatus = value;
            }
        }
    }
}

