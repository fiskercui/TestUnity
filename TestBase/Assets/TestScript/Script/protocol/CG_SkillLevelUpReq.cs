namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="CG_SkillLevelUpReq")]
    public class CG_SkillLevelUpReq : IExtensible
    {
        private int _callback;
        private readonly List<string> _destroyskillGUIDs = new List<string>();
        private string _skillGUID = "";
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

        [ProtoMember(3, Name="destroyskillGUIDs", DataFormat=DataFormat.Default)]
        public List<string> destroyskillGUIDs
        {
            get
            {
                return this._destroyskillGUIDs;
            }
        }

        [DefaultValue(""), ProtoMember(2, IsRequired=false, Name="skillGUID", DataFormat=DataFormat.Default)]
        public string skillGUID
        {
            get
            {
                return this._skillGUID;
            }
            set
            {
                this._skillGUID = value;
            }
        }
    }
}

