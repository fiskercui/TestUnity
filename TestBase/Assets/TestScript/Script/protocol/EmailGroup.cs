namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="EmailGroup")]
    public class EmailGroup : IExtensible
    {
        private readonly List<Attachment> _attachments = new List<Attachment>();
        private long _createPlayerEndTime;
        private long _createPlayerStartTime;
        private string _emailBody = "";
        private long _emailTime;
        private string _emailTitle = "";
        private int _emailType;
        private long _endTime;
        private long _groupId;
        private int _receiverLevelMin;
        private int _receiverPlayerId;
        private int _recieverLevelMax;
        private string _senderName = "";
        private int _senderPlayerId;
        private long _startTime;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(13, Name="attachments", DataFormat=DataFormat.Default)]
        public List<Attachment> attachments
        {
            get
            {
                return this._attachments;
            }
        }

        [DefaultValue((long) 0L), ProtoMember(15, IsRequired=false, Name="createPlayerEndTime", DataFormat=DataFormat.TwosComplement)]
        public long createPlayerEndTime
        {
            get
            {
                return this._createPlayerEndTime;
            }
            set
            {
                this._createPlayerEndTime = value;
            }
        }

        [DefaultValue((long) 0L), ProtoMember(14, IsRequired=false, Name="createPlayerStartTime", DataFormat=DataFormat.TwosComplement)]
        public long createPlayerStartTime
        {
            get
            {
                return this._createPlayerStartTime;
            }
            set
            {
                this._createPlayerStartTime = value;
            }
        }

        [DefaultValue(""), ProtoMember(4, IsRequired=false, Name="emailBody", DataFormat=DataFormat.Default)]
        public string emailBody
        {
            get
            {
                return this._emailBody;
            }
            set
            {
                this._emailBody = value;
            }
        }

        [DefaultValue((long) 0L), ProtoMember(5, IsRequired=false, Name="emailTime", DataFormat=DataFormat.TwosComplement)]
        public long emailTime
        {
            get
            {
                return this._emailTime;
            }
            set
            {
                this._emailTime = value;
            }
        }

        [DefaultValue(""), ProtoMember(3, IsRequired=false, Name="emailTitle", DataFormat=DataFormat.Default)]
        public string emailTitle
        {
            get
            {
                return this._emailTitle;
            }
            set
            {
                this._emailTitle = value;
            }
        }

        [ProtoMember(2, IsRequired=false, Name="emailType", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int emailType
        {
            get
            {
                return this._emailType;
            }
            set
            {
                this._emailType = value;
            }
        }

        [DefaultValue((long) 0L), ProtoMember(12, IsRequired=false, Name="endTime", DataFormat=DataFormat.TwosComplement)]
        public long endTime
        {
            get
            {
                return this._endTime;
            }
            set
            {
                this._endTime = value;
            }
        }

        [DefaultValue((long) 0L), ProtoMember(1, IsRequired=false, Name="groupId", DataFormat=DataFormat.ZigZag)]
        public long groupId
        {
            get
            {
                return this._groupId;
            }
            set
            {
                this._groupId = value;
            }
        }

        [DefaultValue(0), ProtoMember(9, IsRequired=false, Name="receiverLevelMin", DataFormat=DataFormat.TwosComplement)]
        public int receiverLevelMin
        {
            get
            {
                return this._receiverLevelMin;
            }
            set
            {
                this._receiverLevelMin = value;
            }
        }

        [DefaultValue(0), ProtoMember(8, IsRequired=false, Name="receiverPlayerId", DataFormat=DataFormat.TwosComplement)]
        public int receiverPlayerId
        {
            get
            {
                return this._receiverPlayerId;
            }
            set
            {
                this._receiverPlayerId = value;
            }
        }

        [ProtoMember(10, IsRequired=false, Name="recieverLevelMax", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int recieverLevelMax
        {
            get
            {
                return this._recieverLevelMax;
            }
            set
            {
                this._recieverLevelMax = value;
            }
        }

        [DefaultValue(""), ProtoMember(6, IsRequired=false, Name="senderName", DataFormat=DataFormat.Default)]
        public string senderName
        {
            get
            {
                return this._senderName;
            }
            set
            {
                this._senderName = value;
            }
        }

        [ProtoMember(7, IsRequired=false, Name="senderPlayerId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int senderPlayerId
        {
            get
            {
                return this._senderPlayerId;
            }
            set
            {
                this._senderPlayerId = value;
            }
        }

        [ProtoMember(11, IsRequired=false, Name="startTime", DataFormat=DataFormat.TwosComplement), DefaultValue((long) 0L)]
        public long startTime
        {
            get
            {
                return this._startTime;
            }
            set
            {
                this._startTime = value;
            }
        }
    }
}

