namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="CG_JoinFriendCampaignReq")]
    public class CG_JoinFriendCampaignReq : IExtensible
    {
        private int _callback;
        private readonly List<int> _friendIds = new List<int>();
        private int _positionId;
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

        [ProtoMember(3, Name="friendIds", DataFormat=DataFormat.TwosComplement)]
        public List<int> friendIds
        {
            get
            {
                return this._friendIds;
            }
        }

        [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="positionId", DataFormat=DataFormat.TwosComplement)]
        public int positionId
        {
            get
            {
                return this._positionId;
            }
            set
            {
                this._positionId = value;
            }
        }
    }
}

