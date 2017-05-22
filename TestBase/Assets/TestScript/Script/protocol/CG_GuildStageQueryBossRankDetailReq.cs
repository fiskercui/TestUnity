namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="CG_GuildStageQueryBossRankDetailReq")]
    public class CG_GuildStageQueryBossRankDetailReq : IExtensible
    {
        private int _callback;
        private int _index;
        private int _mapNum;
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

        [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="index", DataFormat=DataFormat.TwosComplement)]
        public int index
        {
            get
            {
                return this._index;
            }
            set
            {
                this._index = value;
            }
        }

        [ProtoMember(2, IsRequired=false, Name="mapNum", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int mapNum
        {
            get
            {
                return this._mapNum;
            }
            set
            {
                this._mapNum = value;
            }
        }
    }
}

