namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;

    [ProtoContract(Name="GC_QuerySevenElevenGiftRes")]
    public class GC_QuerySevenElevenGiftRes : IExtensible
    {
        private string _areaName = "";
        private int _callback;
        private bool _canSevenElevenConvert;
        private int _decadePos;
        private int _handredPos;
        private bool _isConvertArea;
        private int _result;
        private SevenElevenGift _sevenElevenGift;
        private int _unitPos;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(8, IsRequired=false, Name="areaName", DataFormat=DataFormat.Default), DefaultValue("")]
        public string areaName
        {
            get
            {
                return this._areaName;
            }
            set
            {
                this._areaName = value;
            }
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

        [DefaultValue(false), ProtoMember(9, IsRequired=false, Name="canSevenElevenConvert", DataFormat=DataFormat.Default)]
        public bool canSevenElevenConvert
        {
            get
            {
                return this._canSevenElevenConvert;
            }
            set
            {
                this._canSevenElevenConvert = value;
            }
        }

        [ProtoMember(4, IsRequired=false, Name="decadePos", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int decadePos
        {
            get
            {
                return this._decadePos;
            }
            set
            {
                this._decadePos = value;
            }
        }

        [DefaultValue(0), ProtoMember(3, IsRequired=false, Name="handredPos", DataFormat=DataFormat.TwosComplement)]
        public int handredPos
        {
            get
            {
                return this._handredPos;
            }
            set
            {
                this._handredPos = value;
            }
        }

        [DefaultValue(false), ProtoMember(7, IsRequired=false, Name="isConvertArea", DataFormat=DataFormat.Default)]
        public bool isConvertArea
        {
            get
            {
                return this._isConvertArea;
            }
            set
            {
                this._isConvertArea = value;
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

        [ProtoMember(6, IsRequired=false, Name="sevenElevenGift", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public SevenElevenGift sevenElevenGift
        {
            get
            {
                return this._sevenElevenGift;
            }
            set
            {
                this._sevenElevenGift = value;
            }
        }

        [ProtoMember(5, IsRequired=false, Name="unitPos", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int unitPos
        {
            get
            {
                return this._unitPos;
            }
            set
            {
                this._unitPos = value;
            }
        }
    }
}

