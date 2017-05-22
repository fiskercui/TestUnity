namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="EmailPlayer")]
    public class EmailPlayer : IExtensible
    {
        private Reward _attachmentRewards;
        private string _emailBody = "";
        private long _emailGroupId;
        private long _emailId;
        private string _emailTitle = "";
        private int _emailType;
        private int _receiverId;
        private int _senderId;
        private string _senderName = "";
        private long _sendTime;
        private int _statusDidPick;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(10, IsRequired=false, Name="attachmentRewards", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public Reward attachmentRewards
        {
            get
            {
                return this._attachmentRewards;
            }
            set
            {
                this._attachmentRewards = value;
            }
        }

        [ProtoMember(8, IsRequired=false, Name="emailBody", DataFormat=DataFormat.Default), DefaultValue("")]
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

        [ProtoMember(9, IsRequired=false, Name="emailGroupId", DataFormat=DataFormat.ZigZag), DefaultValue((long) 0L)]
        public long emailGroupId
        {
            get
            {
                return this._emailGroupId;
            }
            set
            {
                this._emailGroupId = value;
            }
        }

        [ProtoMember(1, IsRequired=false, Name="emailId", DataFormat=DataFormat.ZigZag), DefaultValue((long) 0L)]
        public long emailId
        {
            get
            {
                return this._emailId;
            }
            set
            {
                this._emailId = value;
            }
        }

        [ProtoMember(3, IsRequired=false, Name="emailTitle", DataFormat=DataFormat.Default), DefaultValue("")]
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

        [DefaultValue(0), ProtoMember(7, IsRequired=false, Name="receiverId", DataFormat=DataFormat.TwosComplement)]
        public int receiverId
        {
            get
            {
                return this._receiverId;
            }
            set
            {
                this._receiverId = value;
            }
        }

        [ProtoMember(4, IsRequired=false, Name="senderId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int senderId
        {
            get
            {
                return this._senderId;
            }
            set
            {
                this._senderId = value;
            }
        }

        [ProtoMember(5, IsRequired=false, Name="senderName", DataFormat=DataFormat.Default), DefaultValue("")]
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

        [ProtoMember(6, IsRequired=false, Name="sendTime", DataFormat=DataFormat.ZigZag), DefaultValue((long) 0L)]
        public long sendTime
        {
            get
            {
                return this._sendTime;
            }
            set
            {
                this._sendTime = value;
            }
        }

        [ProtoMember(11, IsRequired=false, Name="statusDidPick", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int statusDidPick
        {
            get
            {
                return this._statusDidPick;
            }
            set
            {
                this._statusDidPick = value;
            }
        }
    }
}

