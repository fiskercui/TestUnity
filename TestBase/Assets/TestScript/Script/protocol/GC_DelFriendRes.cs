namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="GC_DelFriendRes")]
    public class GC_DelFriendRes : IExtensible
    {
        private int _delPlayerId;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="delPlayerId", DataFormat=DataFormat.TwosComplement)]
        public int delPlayerId
        {
            get
            {
                return this._delPlayerId;
            }
            set
            {
                this._delPlayerId = value;
            }
        }
    }
}

