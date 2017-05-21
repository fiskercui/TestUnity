namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Security;

    [ProtoContract(Name="ChangeNameConfig")]
    public class ChangeNameConfig : Configuration, IExtensible
    {
        private readonly List<Cost> _changeGuildNameCosts = new List<Cost>();
        private Cost _changeGuildNameItem;
        private readonly List<Cost> _changePlayNameCosts = new List<Cost>();
        private Cost _changePlayNameItem;
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        public override void LoadFromXml(SecurityElement element)
        {
            if ((element.Tag == "ChangeNameConfig") && (element.Children != null))
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string tag = element2.Tag;
                    if (tag != null)
                    {
                        if (tag != "ChangePlayNameItem")
                        {
                            if (tag == "ChangePlayNameCost")
                            {
                                goto Label_0089;
                            }
                            if (tag == "ChangeGuildNameItem")
                            {
                                goto Label_009C;
                            }
                            if (tag == "ChangeGuildNameCost")
                            {
                                goto Label_00AA;
                            }
                        }
                        else
                        {
                            this._changePlayNameItem = Cost.LoadFromXml(element2);
                        }
                    }
                    continue;
                Label_0089:
                    this._changePlayNameCosts.Add(Cost.LoadFromXml(element2));
                    continue;
                Label_009C:
                    this._changeGuildNameItem = Cost.LoadFromXml(element2);
                    continue;
                Label_00AA:
                    this._changeGuildNameCosts.Add(Cost.LoadFromXml(element2));
                }
            }
        }

        [ProtoMember(4, Name="changeGuildNameCosts", DataFormat=DataFormat.Default)]
        public List<Cost> ChangeGuildNameCosts
        {
            get
            {
                return this._changeGuildNameCosts;
            }
        }

        [ProtoMember(3, IsRequired=false, Name="changeGuildNameItem", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public Cost ChangeGuildNameItem
        {
            get
            {
                return this._changeGuildNameItem;
            }
            set
            {
                this._changeGuildNameItem = value;
            }
        }

        [ProtoMember(2, Name="changePlayNameCosts", DataFormat=DataFormat.Default)]
        public List<Cost> ChangePlayNameCosts
        {
            get
            {
                return this._changePlayNameCosts;
            }
        }

        [ProtoMember(1, IsRequired=false, Name="changePlayNameItem", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public Cost ChangePlayNameItem
        {
            get
            {
                return this._changePlayNameItem;
            }
            set
            {
                this._changePlayNameItem = value;
            }
        }
    }
}

