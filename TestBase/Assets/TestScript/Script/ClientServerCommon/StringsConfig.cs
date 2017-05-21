namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Security;

    [ProtoContract(Name="StringsConfig")]
    public class StringsConfig : Configuration, IExtensible
    {
        private readonly List<Block> _blocks = new List<Block>();
        private Dictionary<string, Dictionary<string, string>> _name_blockMap = new Dictionary<string, Dictionary<string, string>>();
        private IExtension extensionObject;

        public override void AfterSerialize()
        {
            this._blocks.Clear();
        }

        public override void BeforSerialize()
        {
            this._blocks.Clear();
            foreach (KeyValuePair<string, Dictionary<string, string>> pair in this._name_blockMap)
            {
                Block item = new Block {
                    blockName = pair.Key
                };
                foreach (KeyValuePair<string, string> pair2 in pair.Value)
                {
                    KeyValue value2 = new KeyValue {
                        key = pair2.Key,
                        value = pair2.Value
                    };
                    item.keyValues.Add(value2);
                }
                this._blocks.Add(item);
            }
        }

        public override void ConstructLogicData(ConfigDatabase cfgDB, int fileFormat)
        {
            foreach (Block block in this._blocks)
            {
                string blockName = block.blockName;
                if (blockName.Length != 0)
                {
                    if (this._name_blockMap.ContainsKey(blockName))
                    {
                        Logger.Error(base.GetType().Name + " ContainsKey " + blockName, new object[0]);
                    }
                    else
                    {
                        Dictionary<string, string> dictionary = new Dictionary<string, string>();
                        this._name_blockMap[blockName] = dictionary;
                        foreach (KeyValue value2 in block.keyValues)
                        {
                            string key = value2.key;
                            if (key.Length != 0)
                            {
                                if (dictionary.ContainsKey(key))
                                {
                                    Logger.Error(base.GetType().Name + " ContainsKey " + key, new object[0]);
                                }
                                else
                                {
                                    dictionary[key] = value2.value;
                                }
                            }
                        }
                    }
                }
            }
        }

        public List<string> GetAllStringsInBlock(string blockStr)
        {
            Dictionary<string, string> dictionary;
            if (!this._name_blockMap.TryGetValue(blockStr, out dictionary))
            {
                Logger.Error("Can't find string block = " + blockStr, new object[0]);
                return new List<string>();
            }
            return new List<string>(dictionary.Values);
        }

        public string GetString(string blockStr, string keyStr)
        {
            Dictionary<string, string> dictionary;
            string str;
            if (!this._name_blockMap.TryGetValue(blockStr, out dictionary))
            {
                Logger.Error("Can't find string block = " + blockStr, new object[0]);
                return "";
            }
            if (!dictionary.TryGetValue(keyStr, out str))
            {
                Logger.Error(string.Format("Can't find string with key : {1} in block {0}", blockStr, keyStr), new object[0]);
                return "";
            }
            return str;
        }

        public int GetStringCount(string blockStr)
        {
            Dictionary<string, string> dictionary;
            if (!this._name_blockMap.TryGetValue(blockStr, out dictionary))
            {
                return 0;
            }
            return dictionary.Count;
        }

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        public bool HasString(string blockStr, string keyStr)
        {
            return (this._name_blockMap.ContainsKey(blockStr) && this._name_blockMap[blockStr].ContainsKey(keyStr));
        }

        private Block LoadBlock(SecurityElement element)
        {
            string str = StrParser.ParseStr(element.Attribute("name"), "");
            if (string.IsNullOrEmpty(str))
            {
                return null;
            }
            Block block = new Block {
                blockName = str
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    if (element2.Tag == "String")
                    {
                        KeyValue item = this.LoadString(element2);
                        if (item != null)
                        {
                            block.keyValues.Add(item);
                        }
                    }
                }
            }
            return block;
        }

        public override void LoadFromXml(SecurityElement element)
        {
            if ((element.Tag == "Strings") && (element.Children != null))
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    if ((element2.Tag == "Block") && (this.LoadBlock(element2) != null))
                    {
                        this._blocks.Add(this.LoadBlock(element2));
                    }
                }
            }
        }

        private KeyValue LoadString(SecurityElement element)
        {
            string str = StrParser.ParseStr(element.Attribute("name"), "");
            if (string.IsNullOrEmpty(str))
            {
                return null;
            }
            return new KeyValue { 
                key = str,
                value = StrParser.ParseStr(element.Text, "", true)
            };
        }

        [ProtoMember(1, Name="blocks", DataFormat=DataFormat.Default)]
        public List<Block> blocks
        {
            get
            {
                return this._blocks;
            }
        }

        [ProtoContract(Name="Block")]
        public class Block : IExtensible
        {
            private string _blockName = "";
            private readonly List<StringsConfig.KeyValue> _keyValues = new List<StringsConfig.KeyValue>();
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(1, IsRequired=false, Name="blockName", DataFormat=DataFormat.Default), DefaultValue("")]
            public string blockName
            {
                get
                {
                    return this._blockName;
                }
                set
                {
                    this._blockName = value;
                }
            }

            [ProtoMember(2, Name="keyValues", DataFormat=DataFormat.Default)]
            public List<StringsConfig.KeyValue> keyValues
            {
                get
                {
                    return this._keyValues;
                }
            }
        }

        [ProtoContract(Name="KeyValue")]
        public class KeyValue : IExtensible
        {
            private string _key = "";
            private string _value = "";
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue(""), ProtoMember(1, IsRequired=false, Name="key", DataFormat=DataFormat.Default)]
            public string key
            {
                get
                {
                    return this._key;
                }
                set
                {
                    this._key = value;
                }
            }

            [ProtoMember(2, IsRequired=false, Name="value", DataFormat=DataFormat.Default), DefaultValue("")]
            public string value
            {
                get
                {
                    return this._value;
                }
                set
                {
                    this._value = value;
                }
            }
        }
    }
}

