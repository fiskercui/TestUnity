namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="GC_GuildStageQueryExploreRankRes")]
    public class GC_GuildStageQueryExploreRankRes : IExtensible
    {
        private int _callback;
        private Rank _myRank;
        private readonly List<Rank> _ranks = new List<Rank>();
        private int _result;
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

        [ProtoMember(3, IsRequired=false, Name="myRank", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public Rank myRank
        {
            get
            {
                return this._myRank;
            }
            set
            {
                this._myRank = value;
            }
        }

        [ProtoMember(4, Name="ranks", DataFormat=DataFormat.Default)]
        public List<Rank> ranks
        {
            get
            {
                return this._ranks;
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
    }
}

