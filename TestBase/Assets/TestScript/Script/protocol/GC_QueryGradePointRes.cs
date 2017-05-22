namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="GC_QueryGradePointRes")]
    public class GC_QueryGradePointRes : IExtensible
    {
        private int _callback;
        private long _gradePoint;
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

        [ProtoMember(3, IsRequired=false, Name="gradePoint", DataFormat=DataFormat.TwosComplement), DefaultValue((long) 0L)]
        public long gradePoint
        {
            get
            {
                return this._gradePoint;
            }
            set
            {
                this._gradePoint = value;
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

