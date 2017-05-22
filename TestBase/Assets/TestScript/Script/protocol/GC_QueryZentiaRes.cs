namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="GC_QueryZentiaRes")]
    public class GC_QueryZentiaRes : IExtensible
    {
        private int _callback;
        private readonly List<string> _flowMessages = new List<string>();
        private Cost _refreshCost;
        private string _refreshDesc = "";
        private int _result;
        private string _zentiaDesc = "";
        private readonly List<ZentiaExchange> _zentiaExchanges = new List<ZentiaExchange>();
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

        [ProtoMember(7, Name="flowMessages", DataFormat=DataFormat.Default)]
        public List<string> flowMessages
        {
            get
            {
                return this._flowMessages;
            }
        }

        [DefaultValue((string) null), ProtoMember(4, IsRequired=false, Name="refreshCost", DataFormat=DataFormat.Default)]
        public Cost refreshCost
        {
            get
            {
                return this._refreshCost;
            }
            set
            {
                this._refreshCost = value;
            }
        }

        [ProtoMember(5, IsRequired=false, Name="refreshDesc", DataFormat=DataFormat.Default), DefaultValue("")]
        public string refreshDesc
        {
            get
            {
                return this._refreshDesc;
            }
            set
            {
                this._refreshDesc = value;
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

        [DefaultValue(""), ProtoMember(6, IsRequired=false, Name="zentiaDesc", DataFormat=DataFormat.Default)]
        public string zentiaDesc
        {
            get
            {
                return this._zentiaDesc;
            }
            set
            {
                this._zentiaDesc = value;
            }
        }

        [ProtoMember(3, Name="zentiaExchanges", DataFormat=DataFormat.Default)]
        public List<ZentiaExchange> zentiaExchanges
        {
            get
            {
                return this._zentiaExchanges;
            }
        }
    }
}

