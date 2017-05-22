namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="GC_QueryFriendListRes")]
    public class GC_QueryFriendListRes : IExtensible
    {
        private int _callback;
        private readonly List<FriendInfo> _friendInfos = new List<FriendInfo>();
        private int _result;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(1, IsRequired=false, Name="callback", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

        [ProtoMember(3, Name="friendInfos", DataFormat=DataFormat.Default)]
        public List<FriendInfo> friendInfos
        {
            get
            {
                return this._friendInfos;
            }
        }

        [ProtoMember(2, IsRequired=false, Name="result", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

