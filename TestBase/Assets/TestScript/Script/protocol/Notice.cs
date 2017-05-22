namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="Notice")]
    public class Notice : IExtensible
    {
        private string _content = "";
        private int _gotoUI;
        private int _iconId;
        private int _id;
        private bool _isActivity;
        private long _timeBegin;
        private long _timeEnd;
        private string _title = "";
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

        [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="gotoUI", DataFormat=DataFormat.TwosComplement)]
        public int gotoUI
        {
            get
            {
                return this._gotoUI;
            }
            set
            {
                this._gotoUI = value;
            }
        }

        [ProtoMember(8, IsRequired=false, Name="iconId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int iconId
        {
            get
            {
                return this._iconId;
            }
            set
            {
                this._iconId = value;
            }
        }

        [ProtoMember(1, IsRequired=false, Name="id", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int id
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }

        [DefaultValue(false), ProtoMember(7, IsRequired=false, Name="isActivity", DataFormat=DataFormat.Default)]
        public bool isActivity
        {
            get
            {
                return this._isActivity;
            }
            set
            {
                this._isActivity = value;
            }
        }

        [ProtoMember(4, IsRequired=false, Name="timeBegin", DataFormat=DataFormat.TwosComplement), DefaultValue((long) 0L)]
        public long timeBegin
        {
            get
            {
                return this._timeBegin;
            }
            set
            {
                this._timeBegin = value;
            }
        }

        [ProtoMember(5, IsRequired=false, Name="timeEnd", DataFormat=DataFormat.TwosComplement), DefaultValue((long) 0L)]
        public long timeEnd
        {
            get
            {
                return this._timeEnd;
            }
            set
            {
                this._timeEnd = value;
            }
        }

        [ProtoMember(2, IsRequired=false, Name="title", DataFormat=DataFormat.Default), DefaultValue("")]
        public string title
        {
            get
            {
                return this._title;
            }
            set
            {
                this._title = value;
            }
        }
    }
}

