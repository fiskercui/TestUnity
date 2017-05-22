namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="ActivityData")]
    public class ActivityData : IExtensible
    {
        private readonly List<ActivityInfo> _activityData = new List<ActivityInfo>();
        private int _activityId;
        private int _activityType;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(3, Name="activityData", DataFormat=DataFormat.Default)]
        public List<ActivityInfo> activityData
        {
            get
            {
                return this._activityData;
            }
        }

        [ProtoMember(2, IsRequired=false, Name="activityId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

        [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="activityType", DataFormat=DataFormat.TwosComplement)]
        public int activityType
        {
            get
            {
                return this._activityType;
            }
            set
            {
                this._activityType = value;
            }
        }
    }
}

