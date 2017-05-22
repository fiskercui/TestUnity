namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="Quest")]
    public class Quest : IExtensible
    {
        private int _currentStep;
        private int _phase;
        private int _questId;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(2, IsRequired=false, Name="currentStep", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int currentStep
        {
            get
            {
                return this._currentStep;
            }
            set
            {
                this._currentStep = value;
            }
        }

        [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="phase", DataFormat=DataFormat.TwosComplement)]
        public int phase
        {
            get
            {
                return this._phase;
            }
            set
            {
                this._phase = value;
            }
        }

        [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="questId", DataFormat=DataFormat.TwosComplement)]
        public int questId
        {
            get
            {
                return this._questId;
            }
            set
            {
                this._questId = value;
            }
        }
    }
}

