namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.ComponentModel;
    using System.Security;

    [ProtoContract(Name="ClientConfig")]
    public class ClientConfig : Configuration, IExtensible
    {
        private string _authServerIP = "";
        private int _authServerPort;
        private string _serverIP = "";
        private int _serverPort;
        private string _version = "";
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        public override void LoadFromXml(SecurityElement element)
        {
            if (element.Tag == "ClientConfig")
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string tag = element2.Tag;
                    if (tag != null)
                    {
                        if (tag != "ServerIP")
                        {
                            if (tag == "ServerPort")
                            {
                                goto Label_0099;
                            }
                            if (tag == "AuthServerIP")
                            {
                                goto Label_00B2;
                            }
                            if (tag == "AuthServerPort")
                            {
                                goto Label_00CB;
                            }
                            if (tag == "Version")
                            {
                                goto Label_00E4;
                            }
                        }
                        else
                        {
                            this._serverIP = StrParser.ParseStr(element2.Text, this._serverIP);
                        }
                    }
                    continue;
                Label_0099:
                    this._serverPort = StrParser.ParseDecInt(element2.Text, this._serverPort);
                    continue;
                Label_00B2:
                    this._authServerIP = StrParser.ParseStr(element2.Text, this._authServerIP);
                    continue;
                Label_00CB:
                    this._authServerPort = StrParser.ParseDecInt(element2.Text, this._authServerPort);
                    continue;
                Label_00E4:
                    this._version = StrParser.ParseStr(element2.Text, this._version);
                }
            }
        }

        [ProtoMember(3, IsRequired=false, Name="authServerIP", DataFormat=DataFormat.Default), DefaultValue("")]
        public string authServerIP
        {
            get
            {
                return this._authServerIP;
            }
            set
            {
                this._authServerIP = value;
            }
        }

        [DefaultValue(0), ProtoMember(4, IsRequired=false, Name="authServerPort", DataFormat=DataFormat.TwosComplement)]
        public int authServerPort
        {
            get
            {
                return this._authServerPort;
            }
            set
            {
                this._authServerPort = value;
            }
        }

        [ProtoMember(1, IsRequired=false, Name="serverIP", DataFormat=DataFormat.Default), DefaultValue("")]
        public string serverIP
        {
            get
            {
                return this._serverIP;
            }
            set
            {
                this._serverIP = value;
            }
        }

        [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="serverPort", DataFormat=DataFormat.TwosComplement)]
        public int serverPort
        {
            get
            {
                return this._serverPort;
            }
            set
            {
                this._serverPort = value;
            }
        }

        [ProtoMember(5, IsRequired=false, Name="version", DataFormat=DataFormat.Default), DefaultValue("")]
        public string version
        {
            get
            {
                return this._version;
            }
            set
            {
                this._version = value;
            }
        }
    }
}

