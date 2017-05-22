namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="BattleRecord")]
    public class BattleRecord : IExtensible
    {
        private CombatRecord _combatRecord;
        private RoundRecord _matchinRoundRecord;
        private int _maxRecordCount;
        private int _sceneId;
        private readonly List<TeamRecord> _teamRecord = new List<TeamRecord>();
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [ProtoMember(4, IsRequired=false, Name="combatRecord", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public CombatRecord combatRecord
        {
            get
            {
                return this._combatRecord;
            }
            set
            {
                this._combatRecord = value;
            }
        }

        [ProtoMember(3, IsRequired=false, Name="matchinRoundRecord", DataFormat=DataFormat.Default), DefaultValue((string) null)]
        public RoundRecord matchinRoundRecord
        {
            get
            {
                return this._matchinRoundRecord;
            }
            set
            {
                this._matchinRoundRecord = value;
            }
        }

        [DefaultValue(0), ProtoMember(5, IsRequired=false, Name="maxRecordCount", DataFormat=DataFormat.TwosComplement)]
        public int maxRecordCount
        {
            get
            {
                return this._maxRecordCount;
            }
            set
            {
                this._maxRecordCount = value;
            }
        }

        [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="sceneId", DataFormat=DataFormat.TwosComplement)]
        public int sceneId
        {
            get
            {
                return this._sceneId;
            }
            set
            {
                this._sceneId = value;
            }
        }

        [ProtoMember(2, Name="teamRecord", DataFormat=DataFormat.Default)]
        public List<TeamRecord> teamRecord
        {
            get
            {
                return this._teamRecord;
            }
        }
    }
}

