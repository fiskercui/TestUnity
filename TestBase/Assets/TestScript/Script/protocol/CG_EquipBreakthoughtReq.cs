namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="CG_EquipBreakthoughtReq")]
    public class CG_EquipBreakthoughtReq : IExtensible
    {
        private int _callback;
        private readonly List<string> _destroyEquipGUIDs = new List<string>();
        private string _equipGUID = "";
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

        [ProtoMember(3, Name="destroyEquipGUIDs", DataFormat=DataFormat.Default)]
        public List<string> destroyEquipGUIDs
        {
            get
            {
                return this._destroyEquipGUIDs;
            }
        }

        [DefaultValue(""), ProtoMember(2, IsRequired=false, Name="equipGUID", DataFormat=DataFormat.Default)]
        public string equipGUID
        {
            get
            {
                return this._equipGUID;
            }
            set
            {
                this._equipGUID = value;
            }
        }
    }
}

