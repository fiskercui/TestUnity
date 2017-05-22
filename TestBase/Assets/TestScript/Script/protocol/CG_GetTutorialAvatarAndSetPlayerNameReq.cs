namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="CG_GetTutorialAvatarAndSetPlayerNameReq")]
    public class CG_GetTutorialAvatarAndSetPlayerNameReq : IExtensible
    {
        private int _callback;
        private string _playerName = "";
        private int _resourceId;
        private int _tutorialId;
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

        [DefaultValue(""), ProtoMember(3, IsRequired=false, Name="playerName", DataFormat=DataFormat.Default)]
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

        [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="resourceId", DataFormat=DataFormat.TwosComplement)]
        public int resourceId
        {
            get
            {
                return this._resourceId;
            }
            set
            {
                this._resourceId = value;
            }
        }

        [DefaultValue(0), ProtoMember(4, IsRequired=false, Name="tutorialId", DataFormat=DataFormat.TwosComplement)]
        public int tutorialId
        {
            get
            {
                return this._tutorialId;
            }
            set
            {
                this._tutorialId = value;
            }
        }
    }
}

