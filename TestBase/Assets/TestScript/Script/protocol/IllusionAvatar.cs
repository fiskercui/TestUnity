namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="IllusionAvatar")]
    public class IllusionAvatar : IExtensible
    {
        private float _illusionDanPower;
        private readonly List<Illusion> _illusions = new List<Illusion>();
        private int _recourseId;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [DefaultValue((float) 0f), ProtoMember(3, IsRequired=false, Name="illusionDanPower", DataFormat=DataFormat.FixedSize)]
        public float illusionDanPower
        {
            get
            {
                return this._illusionDanPower;
            }
            set
            {
                this._illusionDanPower = value;
            }
        }

        [ProtoMember(2, Name="illusions", DataFormat=DataFormat.Default)]
        public List<Illusion> illusions
        {
            get
            {
                return this._illusions;
            }
        }

        [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="recourseId", DataFormat=DataFormat.TwosComplement)]
        public int recourseId
        {
            get
            {
                return this._recourseId;
            }
            set
            {
                this._recourseId = value;
            }
        }
    }
}

