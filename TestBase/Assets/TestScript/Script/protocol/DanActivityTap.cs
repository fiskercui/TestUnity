namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="DanActivityTap")]
    public class DanActivityTap : IExtensible
    {
        private string _activityDesc = "";
        private readonly List<DanActivityReward> _danActivityRewards = new List<DanActivityReward>();
        private int _iconId;
        private int _type;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [DefaultValue(""), ProtoMember(3, IsRequired=false, Name="activityDesc", DataFormat=DataFormat.Default)]
        public string activityDesc
        {
            get
            {
                return this._activityDesc;
            }
            set
            {
                this._activityDesc = value;
            }
        }

        [ProtoMember(4, Name="danActivityRewards", DataFormat=DataFormat.Default)]
        public List<DanActivityReward> danActivityRewards
        {
            get
            {
                return this._danActivityRewards;
            }
        }

        [ProtoMember(2, IsRequired=false, Name="iconId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int iconId
        {
            get
            {
                return this._iconId;
            }
            set
            {
                this._iconId = value;
            }
        }

        [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="type", DataFormat=DataFormat.TwosComplement)]
        public int type
        {
            get
            {
                return this._type;
            }
            set
            {
                this._type = value;
            }
        }
    }
}

