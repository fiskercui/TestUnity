namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="CG_AvatarBreakthoughtReq")]
    public class CG_AvatarBreakthoughtReq : IExtensible
    {
        private string _avatarGUID = "";
        private int _callback;
        private readonly List<string> _destroyAvatarGUIDs = new List<string>();
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [DefaultValue(""), ProtoMember(2, IsRequired=false, Name="avatarGUID", DataFormat=DataFormat.Default)]
        public string avatarGUID
        {
            get
            {
                return this._avatarGUID;
            }
            set
            {
                this._avatarGUID = value;
            }
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

        [ProtoMember(3, Name="destroyAvatarGUIDs", DataFormat=DataFormat.Default)]
        public List<string> destroyAvatarGUIDs
        {
            get
            {
                return this._destroyAvatarGUIDs;
            }
        }
    }
}

