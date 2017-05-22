namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="ChatMessage")]
    public class ChatMessage : IExtensible
    {
        private string _content = "";
        private int _displayCount;
        private bool _isDisplayOnMarquee;
        private bool _isReceiverOnline;
        private long _messageId;
        private int _messageType;
        private int _receiverId;
        private string _receiverName = "";
        private int _receiverVipLevel;
        private int _senderId;
        private int _senderLevel;
        private string _senderName = "";
        private int _senderRoleId;
        private int _senderVipLevel;
        private long _time;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [DefaultValue(""), ProtoMember(6, IsRequired=false, Name="content", DataFormat=DataFormat.Default)]
        public string content
        {
            get
            {
                return this._content;
            }
            set
            {
                this._content = value;
            }
        }

        [DefaultValue(0), ProtoMember(12, IsRequired=false, Name="displayCount", DataFormat=DataFormat.TwosComplement)]
        public int displayCount
        {
            get
            {
                return this._displayCount;
            }
            set
            {
                this._displayCount = value;
            }
        }

        [ProtoMember(13, IsRequired=false, Name="isDisplayOnMarquee", DataFormat=DataFormat.Default), DefaultValue(false)]
        public bool isDisplayOnMarquee
        {
            get
            {
                return this._isDisplayOnMarquee;
            }
            set
            {
                this._isDisplayOnMarquee = value;
            }
        }

        [DefaultValue(false), ProtoMember(11, IsRequired=false, Name="isReceiverOnline", DataFormat=DataFormat.Default)]
        public bool isReceiverOnline
        {
            get
            {
                return this._isReceiverOnline;
            }
            set
            {
                this._isReceiverOnline = value;
            }
        }

        [DefaultValue((long) 0L), ProtoMember(2, IsRequired=false, Name="messageId", DataFormat=DataFormat.ZigZag)]
        public long messageId
        {
            get
            {
                return this._messageId;
            }
            set
            {
                this._messageId = value;
            }
        }

        [ProtoMember(1, IsRequired=false, Name="messageType", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int messageType
        {
            get
            {
                return this._messageType;
            }
            set
            {
                this._messageType = value;
            }
        }

        [DefaultValue(0), ProtoMember(5, IsRequired=false, Name="receiverId", DataFormat=DataFormat.TwosComplement)]
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

        [DefaultValue(""), ProtoMember(10, IsRequired=false, Name="receiverName", DataFormat=DataFormat.Default)]
        public string receiverName
        {
            get
            {
                return this._receiverName;
            }
            set
            {
                this._receiverName = value;
            }
        }

        [DefaultValue(0), ProtoMember(9, IsRequired=false, Name="receiverVipLevel", DataFormat=DataFormat.TwosComplement)]
        public int receiverVipLevel
        {
            get
            {
                return this._receiverVipLevel;
            }
            set
            {
                this._receiverVipLevel = value;
            }
        }

        [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="senderId", DataFormat=DataFormat.TwosComplement)]
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

        [ProtoMember(15, IsRequired=false, Name="senderLevel", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int senderLevel
        {
            get
            {
                return this._senderLevel;
            }
            set
            {
                this._senderLevel = value;
            }
        }

        [DefaultValue(""), ProtoMember(4, IsRequired=false, Name="senderName", DataFormat=DataFormat.Default)]
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

        [ProtoMember(14, IsRequired=false, Name="senderRoleId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int senderRoleId
        {
            get
            {
                return this._senderRoleId;
            }
            set
            {
                this._senderRoleId = value;
            }
        }

        [ProtoMember(8, IsRequired=false, Name="senderVipLevel", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int senderVipLevel
        {
            get
            {
                return this._senderVipLevel;
            }
            set
            {
                this._senderVipLevel = value;
            }
        }

        [ProtoMember(7, IsRequired=false, Name="time", DataFormat=DataFormat.ZigZag), DefaultValue((long) 0L)]
        public long time
        {
            get
            {
                return this._time;
            }
            set
            {
                this._time = value;
            }
        }
    }
}

