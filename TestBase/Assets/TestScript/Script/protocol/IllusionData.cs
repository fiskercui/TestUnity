namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;

    [ProtoContract(Name="IllusionData")]
    public class IllusionData : IExtensible
    {
        private readonly List<int> _historyAvatarIds = new List<int>();
        private readonly List<IllusionAvatar> _illusionAvatars = new List<IllusionAvatar>();
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(1, Name="historyAvatarIds", DataFormat=DataFormat.TwosComplement)]
        public List<int> historyAvatarIds
        {
            get
            {
                return this._historyAvatarIds;
            }
        }

        [ProtoMember(2, Name="illusionAvatars", DataFormat=DataFormat.Default)]
        public List<IllusionAvatar> illusionAvatars
        {
            get
            {
                return this._illusionAvatars;
            }
        }
    }
}

