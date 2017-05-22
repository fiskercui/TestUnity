namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;

    [ProtoContract(Name="HireDinerData")]
    public class HireDinerData : IExtensible
    {
        private readonly List<HiredDiner> _hireDiners = new List<HiredDiner>();
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(1, Name="hireDiners", DataFormat=DataFormat.Default)]
        public List<HiredDiner> hireDiners
        {
            get
            {
                return this._hireDiners;
            }
        }
    }
}

