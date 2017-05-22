namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;

    [ProtoContract(Name="ModifierSet")]
    public class ModifierSet : IExtensible
    {
        private readonly List<Modifier> _modifiers = new List<Modifier>();
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(1, Name="modifiers", DataFormat=DataFormat.Default)]
        public List<Modifier> modifiers
        {
            get
            {
                return this._modifiers;
            }
        }
    }
}

