namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="CG_GuildStageExploreReq")]
    public class CG_GuildStageExploreReq : IExtensible
    {
        private int _callback;
        private int _exploreIndex;
        private int _moveIndex;
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

        [ProtoMember(3, IsRequired=false, Name="exploreIndex", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int exploreIndex
        {
            get
            {
                return this._exploreIndex;
            }
            set
            {
                this._exploreIndex = value;
            }
        }

        [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="moveIndex", DataFormat=DataFormat.TwosComplement)]
        public int moveIndex
        {
            get
            {
                return this._moveIndex;
            }
            set
            {
                this._moveIndex = value;
            }
        }
    }
}

