namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="Task")]
    public class Task : IExtensible
    {
        private readonly List<int> _datas = new List<int>();
        private int _taskId;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(2, Name="datas", DataFormat=DataFormat.TwosComplement)]
        public List<int> datas
        {
            get
            {
                return this._datas;
            }
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
    }
}

