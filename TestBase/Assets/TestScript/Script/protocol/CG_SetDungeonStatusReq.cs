namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="CG_SetDungeonStatusReq")]
    public class CG_SetDungeonStatusReq : IExtensible
    {
        private int _callback;
        private int _dungeonId;
        private int _status;
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

        [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="dungeonId", DataFormat=DataFormat.TwosComplement)]
        public int dungeonId
        {
            get
            {
                return this._dungeonId;
            }
            set
            {
                this._dungeonId = value;
            }
        }

        [ProtoMember(3, IsRequired=false, Name="status", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int status
        {
            get
            {
                return this._status;
            }
            set
            {
                this._status = value;
            }
        }
    }
}

