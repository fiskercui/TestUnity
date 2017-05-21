namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Security;

    [ProtoContract(Name="ClientManifest")]
    public class ClientManifest : Configuration, IExtensible
    {
        private readonly List<FileInfo> _fileInfos = new List<FileInfo>();
        private Dictionary<string, FileInfo> _name_fileDict = new Dictionary<string, FileInfo>();
        private IExtension extensionObject;

        public override void ConstructLogicData(ConfigDatabase cfgDB, int fileFormat)
        {
            base.ConstructLogicData(cfgDB, fileFormat);
            foreach (FileInfo info in this._fileInfos)
            {
                if (info != null)
                {
                    if (this._name_fileDict.ContainsKey(info.assetName))
                    {
                        Logger.Error(base.GetType().Name + " ContainsKey " + info.assetName, new object[0]);
                    }
                    else
                    {
                        this._name_fileDict.Add(info.assetName, info);
                    }
                }
            }
        }

        public bool ContainsFile(string lowerCaseName)
        {
            return this._name_fileDict.ContainsKey(lowerCaseName);
        }

        public FileInfo GetFileByName(string lowerCaseName)
        {
            FileInfo info = null;
            if (!this._name_fileDict.TryGetValue(lowerCaseName, out info))
            {
                return null;
            }
            return info;
        }

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        public override void LoadFromXml(SecurityElement element)
        {
            if ((element.Tag == "ClientManifest") && (element.Children != null))
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    if (element2.Tag == "FileInfo")
                    {
                        FileInfo item = new FileInfo {
                            assetName = StrParser.ParseStr(element2.Attribute("AssetName"), "")
                        };
                        item.revision = StrParser.ParseDecInt(element2.Attribute("Revision"), item.revision);
                        item.fileName = StrParser.ParseStr(element2.Attribute("FileName"), "");
                        item.fileSize = StrParser.ParseDecInt(element2.Attribute("FileSize"), item.fileSize);
                        item.uncompressedFileSize = StrParser.ParseDecInt(element2.Attribute("UncompressedFileSize"), item.uncompressedFileSize);
                        item.isStreamAsset = StrParser.ParseBool(element2.Attribute("IsStreamAsset"), false);
                        item.keepFileName = StrParser.ParseBool(element2.Attribute("KeepFileName"), false);
                        this._fileInfos.Add(item);
                    }
                }
            }
        }

        [ProtoMember(1, Name="fileInfos", DataFormat=DataFormat.Default)]
        public List<FileInfo> fileInfos
        {
            get
            {
                return this._fileInfos;
            }
        }

        [ProtoContract(Name="FileInfo")]
        public class FileInfo : IExtensible
        {
            private string _assetName = "";
            private string _fileName = "";
            private int _fileSize;
            private bool _isStreamAsset;
            private bool _keepFileName;
            private int _revision;
            private int _uncompressedFileSize;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue(""), ProtoMember(1, IsRequired=false, Name="assetName", DataFormat=DataFormat.Default)]
            public string assetName
            {
                get
                {
                    return this._assetName;
                }
                set
                {
                    this._assetName = value;
                }
            }

            [ProtoMember(3, IsRequired=false, Name="fileName", DataFormat=DataFormat.Default), DefaultValue("")]
            public string fileName
            {
                get
                {
                    return this._fileName;
                }
                set
                {
                    this._fileName = value;
                }
            }

            [DefaultValue(0), ProtoMember(4, IsRequired=false, Name="fileSize", DataFormat=DataFormat.TwosComplement)]
            public int fileSize
            {
                get
                {
                    return this._fileSize;
                }
                set
                {
                    this._fileSize = value;
                }
            }

            [ProtoMember(6, IsRequired=false, Name="isStreamAsset", DataFormat=DataFormat.Default), DefaultValue(false)]
            public bool isStreamAsset
            {
                get
                {
                    return this._isStreamAsset;
                }
                set
                {
                    this._isStreamAsset = value;
                }
            }

            [ProtoMember(7, IsRequired=false, Name="keepFileName", DataFormat=DataFormat.Default), DefaultValue(false)]
            public bool keepFileName
            {
                get
                {
                    return this._keepFileName;
                }
                set
                {
                    this._keepFileName = value;
                }
            }

            [ProtoMember(2, IsRequired=false, Name="revision", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int revision
            {
                get
                {
                    return this._revision;
                }
                set
                {
                    this._revision = value;
                }
            }

            [ProtoMember(5, IsRequired=false, Name="uncompressedFileSize", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int uncompressedFileSize
            {
                get
                {
                    return this._uncompressedFileSize;
                }
                set
                {
                    this._uncompressedFileSize = value;
                }
            }
        }
    }
}

