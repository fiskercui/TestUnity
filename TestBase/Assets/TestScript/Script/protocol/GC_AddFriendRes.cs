namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="GC_AddFriendRes")]
    public class GC_AddFriendRes : IExtensible
    {
        private FriendInfo _friendInfo;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [DefaultValue((string) null), ProtoMember(1, IsRequired=false, Name="friendInfo", DataFormat=DataFormat.Default)]
        public FriendInfo friendInfo
        {
            get
            {
                return this._friendInfo;
            }
            set
            {
                this._friendInfo = value;
            }
        }
    }
}

