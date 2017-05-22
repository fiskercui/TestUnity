namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="CG_SetPlayerNameReq")]
    public class CG_SetPlayerNameReq : IExtensible
    {
        private int _callback;
        private string _playerName = "";
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

        [DefaultValue(""), ProtoMember(2, IsRequired=false, Name="playerName", DataFormat=DataFormat.Default)]
        public string playerName
        {
            get
            {
                return this._playerName;
            }
            set
            {
                this._playerName = value;
            }
        }
    }
}

