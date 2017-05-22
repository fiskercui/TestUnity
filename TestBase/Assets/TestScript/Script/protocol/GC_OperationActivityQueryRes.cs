namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="GC_OperationActivityQueryRes")]
    public class GC_OperationActivityQueryRes : IExtensible
    {
        private int _activityId;
        private int _callback;
        private int _cycleMoney;
        private readonly List<OperationActivityItem> _operationActivityItems = new List<OperationActivityItem>();
        private int _operationIndex;
        private long _pickRewardCloseTime;
        private long _pickRewardOpenTime;
        private long _purchaseCloseTime;
        private long _purchaseOpenTime;
        private int _result;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(3, IsRequired=false, Name="activityId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int activityId
        {
            get
            {
                return this._activityId;
            }
            set
            {
                this._activityId = value;
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

        [ProtoMember(5, IsRequired=false, Name="cycleMoney", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int cycleMoney
        {
            get
            {
                return this._cycleMoney;
            }
            set
            {
                this._cycleMoney = value;
            }
        }

        [ProtoMember(6, Name="operationActivityItems", DataFormat=DataFormat.Default)]
        public List<OperationActivityItem> operationActivityItems
        {
            get
            {
                return this._operationActivityItems;
            }
        }

        [DefaultValue(0), ProtoMember(4, IsRequired=false, Name="operationIndex", DataFormat=DataFormat.TwosComplement)]
        public int operationIndex
        {
            get
            {
                return this._operationIndex;
            }
            set
            {
                this._operationIndex = value;
            }
        }

        [DefaultValue((long) 0L), ProtoMember(10, IsRequired=false, Name="pickRewardCloseTime", DataFormat=DataFormat.TwosComplement)]
        public long pickRewardCloseTime
        {
            get
            {
                return this._pickRewardCloseTime;
            }
            set
            {
                this._pickRewardCloseTime = value;
            }
        }

        [ProtoMember(9, IsRequired=false, Name="pickRewardOpenTime", DataFormat=DataFormat.TwosComplement), DefaultValue((long) 0L)]
        public long pickRewardOpenTime
        {
            get
            {
                return this._pickRewardOpenTime;
            }
            set
            {
                this._pickRewardOpenTime = value;
            }
        }

        [DefaultValue((long) 0L), ProtoMember(8, IsRequired=false, Name="purchaseCloseTime", DataFormat=DataFormat.TwosComplement)]
        public long purchaseCloseTime
        {
            get
            {
                return this._purchaseCloseTime;
            }
            set
            {
                this._purchaseCloseTime = value;
            }
        }

        [DefaultValue((long) 0L), ProtoMember(7, IsRequired=false, Name="purchaseOpenTime", DataFormat=DataFormat.TwosComplement)]
        public long purchaseOpenTime
        {
            get
            {
                return this._purchaseOpenTime;
            }
            set
            {
                this._purchaseOpenTime = value;
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

