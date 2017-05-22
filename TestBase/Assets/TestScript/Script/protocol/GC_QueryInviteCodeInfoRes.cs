namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="GC_QueryInviteCodeInfoRes")]
    public class GC_QueryInviteCodeInfoRes : IExtensible
    {
        private int _callback;
        private string _codeOwnerName = "";
        private int _iconId;
        private readonly List<InviteReward> _inviteRewards = new List<InviteReward>();
        private int _result;
        private string _rewardDesc = "";
        private string _selfInviteCode = "";
        private Reward _useCodeReward;
        private bool _useCodeRewardHasPick;
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

        [DefaultValue(""), ProtoMember(8, IsRequired=false, Name="codeOwnerName", DataFormat=DataFormat.Default)]
        public string codeOwnerName
        {
            get
            {
                return this._codeOwnerName;
            }
            set
            {
                this._codeOwnerName = value;
            }
        }

        [ProtoMember(9, IsRequired=false, Name="iconId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

        [ProtoMember(6, Name="inviteRewards", DataFormat=DataFormat.Default)]
        public List<InviteReward> inviteRewards
        {
            get
            {
                return this._inviteRewards;
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

        [ProtoMember(5, IsRequired=false, Name="rewardDesc", DataFormat=DataFormat.Default), DefaultValue("")]
        public string rewardDesc
        {
            get
            {
                return this._rewardDesc;
            }
            set
            {
                this._rewardDesc = value;
            }
        }

        [DefaultValue(""), ProtoMember(4, IsRequired=false, Name="selfInviteCode", DataFormat=DataFormat.Default)]
        public string selfInviteCode
        {
            get
            {
                return this._selfInviteCode;
            }
            set
            {
                this._selfInviteCode = value;
            }
        }

        [DefaultValue((string) null), ProtoMember(3, IsRequired=false, Name="useCodeReward", DataFormat=DataFormat.Default)]
        public Reward useCodeReward
        {
            get
            {
                return this._useCodeReward;
            }
            set
            {
                this._useCodeReward = value;
            }
        }

        [ProtoMember(7, IsRequired=false, Name="useCodeRewardHasPick", DataFormat=DataFormat.Default), DefaultValue(false)]
        public bool useCodeRewardHasPick
        {
            get
            {
                return this._useCodeRewardHasPick;
            }
            set
            {
                this._useCodeRewardHasPick = value;
            }
        }
    }
}

