namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="GC_QueryQuestInfoRes")]
    public class GC_QueryQuestInfoRes : IExtensible
    {
        private int _callback;
        private QuestQuick _questQuick;
        private readonly List<Quest> _quests = new List<Quest>();
        private int _result;
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

        [DefaultValue((string) null), ProtoMember(4, IsRequired=false, Name="questQuick", DataFormat=DataFormat.Default)]
        public QuestQuick questQuick
        {
            get
            {
                return this._questQuick;
            }
            set
            {
                this._questQuick = value;
            }
        }

        [ProtoMember(3, Name="quests", DataFormat=DataFormat.Default)]
        public List<Quest> quests
        {
            get
            {
                return this._quests;
            }
        }

        [ProtoMember(2, IsRequired=true, Name="result", DataFormat=DataFormat.TwosComplement)]
        public int result
        {
            get
            {
                return this._result;
            }
            set
            {
                this._result = value;
            }
        }
    }
}

