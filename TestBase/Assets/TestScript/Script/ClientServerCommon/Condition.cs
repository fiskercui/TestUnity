namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;
    using System.Security;

    [ProtoContract(Name="Condition")]
    public class Condition : IExtensible
    {
        private int _compareType;
        private int _compareValue;
        private int _type;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        public static ClientServerCommon.Condition LoadFromXml(SecurityElement element)
        {
            return new ClientServerCommon.Condition();
        }

        [ProtoMember(2, IsRequired=false, Name="compareType", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int compareType
        {
            get
            {
                return this._compareType;
            }
            set
            {
                this._compareType = value;
            }
        }

        [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="compareValue", DataFormat=DataFormat.TwosComplement)]
        public int compareValue
        {
            get
            {
                return this._compareValue;
            }
            set
            {
                this._compareValue = value;
            }
        }

        [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="type", DataFormat=DataFormat.TwosComplement)]
        public int type
        {
            get
            {
                return this._type;
            }
            set
            {
                this._type = value;
            }
        }

        public class _Type : TypeNameContainer<ClientServerCommon.Condition._Type>
        {
            public const int DungeonEnterTimes_Daily = 1;
            public const int Unknown = 0;

            public static bool Initialize()
            {
                bool flag = false;
                return (flag & TypeNameContainer<ClientServerCommon.Condition._Type>.RegisterType("DungeonEnterTimes_Daily", 1));
            }
        }
    }
}

