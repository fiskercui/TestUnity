namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="AvatarAction")]
    public class AvatarAction : IExtensible
    {
        private int _actionType;
        private readonly List<Animation> _animations = new List<Animation>();
        private int _combatStateType;
        private readonly List<Event> _events = new List<Event>();
        private int _id;
        private bool _loop;
        private int _sourceTurnId;
        private int _weaponType;
        private IExtension extensionObject;

        public void AddEvent(Event newEvent)
        {
            this.events.Add(newEvent);
        }

        public string GetAnimationName(int avatarAssetId)
        {
            int num = AvatarAssetConfig.ComponentIdToAvatarTypeId(avatarAssetId);
            foreach (Animation animation in this.animations)
            {
                switch (animation.type)
                {
                    case 1:
                        return animation.animation;

                    case 2:
                        if (num != animation.value)
                        {
                            break;
                        }
                        return animation.animation;

                    case 3:
                        if (avatarAssetId != animation.value)
                        {
                            break;
                        }
                        return animation.animation;
                }
            }
            return "";
        }

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        public static bool IsBuffActionID(int actionID)
        {
            int num = (actionID & 0xff0000) >> 0x10;
            if ((num != 0xf1) && (num != 0xf2))
            {
                return (num == 0xf3);
            }
            return true;
        }

        [ProtoMember(3, IsRequired=false, Name="actionType", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int actionType
        {
            get
            {
                return this._actionType;
            }
            set
            {
                this._actionType = value;
            }
        }

        [ProtoMember(11, Name="animations", DataFormat=DataFormat.Default)]
        public List<Animation> animations
        {
            get
            {
                return this._animations;
            }
        }

        [ProtoMember(5, IsRequired=false, Name="combatStateType", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
        public int combatStateType
        {
            get
            {
                return this._combatStateType;
            }
            set
            {
                this._combatStateType = value;
            }
        }

        [ProtoMember(8, Name="events", DataFormat=DataFormat.Default)]
        public List<Event> events
        {
            get
            {
                return this._events;
            }
        }

        [ProtoMember(2, IsRequired=false, Name="id", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

        [ProtoMember(6, IsRequired=false, Name="loop", DataFormat=DataFormat.Default), DefaultValue(false)]
        public bool loop
        {
            get
            {
                return this._loop;
            }
            set
            {
                this._loop = value;
            }
        }

        [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="sourceTurnId", DataFormat=DataFormat.TwosComplement)]
        public int sourceTurnId
        {
            get
            {
                return this._sourceTurnId;
            }
            set
            {
                this._sourceTurnId = value;
            }
        }

        [DefaultValue(0), ProtoMember(4, IsRequired=false, Name="weaponType", DataFormat=DataFormat.TwosComplement)]
        public int weaponType
        {
            get
            {
                return this._weaponType;
            }
            set
            {
                this._weaponType = value;
            }
        }

        public class _Type : TypeNameContainer<AvatarAction._Type>
        {
            public const int BossAttack = 0xf6;
            public const int BossGetHit = 0xf7;
            public const int BossRoleDie = 0xf8;
            public const int BuffTimeUp = 0xf4;
            public const int ChangleCloth = 0xa3;
            public const int CombatIdle = 1;
            public const int CompositeSkillStart = 0x19;
            public const int CompositeSupporterAction = 0x1a;
            public const int Counter = 8;
            public const int CounterAttack_MAP = 0x17;
            public const int CounterAttack_PAP = 0x16;
            public const int CounterAttackStart = 0x18;
            public const int CoverPosition = 2;
            public const int Dan_DmgHeal = 0x1b;
            public const int DefaultIdle = 0xfd;
            public const int DefaultRole = 0xfb;
            public const int Dialogue = 250;
            public const int Die = 11;
            public const int Die_KO = 12;
            public const int Dodge = 5;
            public const int DodgeBack = 6;
            public const int EnterBattleGround = 9;
            public const int EnterBlockingState = 240;
            public const int EnterScene = 10;
            public const int GetHit = 7;
            public const int Idle = 160;
            public const int IllusionUIIdle = 0xd0;
            public const int IllusionUISelectRole = 0xd1;
            public const int Interface = 0x1c;
            public const int Lose = 0x10;
            public const int MaxRound = 0xf5;
            public const int MelaleucaFloorIdle = 0xfe;
            public const int NormalAttack = 3;
            public const int OnCreateBuff = 0xf1;
            public const int OnDeleteBuff = 0xf3;
            public const int OnUpdateBuff = 0xf2;
            public const int RandomIdle = 0xa1;
            public const int Revive = 0x11;
            public const int Run = 0xa4;
            public const int SelectRole = 0xf9;
            public const int Skill = 0x81;
            public const int SkillStart = 0x12;
            public const int SpecialRole = 0xfc;
            public const int SuperSkillEffect = 20;
            public const int SuperSkillStart = 0x13;
            public const int SwitchColumn = 4;
            public const int TurnBack = 14;
            public const int TurnRush = 13;
            public const int Unknown = 0;
            public const int UseItem = 0x15;
            public const int Walk = 0xa2;
            public const int Win = 15;

            public static bool Initialize()
            {
                bool flag = false;
                flag &= TypeNameContainer<AvatarAction._Type>.RegisterType("CombatIdle", 1);
                flag &= TypeNameContainer<AvatarAction._Type>.RegisterType("CoverPosition", 2);
                flag &= TypeNameContainer<AvatarAction._Type>.RegisterType("NormalAttack", 3);
                flag &= TypeNameContainer<AvatarAction._Type>.RegisterType("SwitchColumn", 4);
                flag &= TypeNameContainer<AvatarAction._Type>.RegisterType("Dodge", 5);
                flag &= TypeNameContainer<AvatarAction._Type>.RegisterType("DodgeBack", 6);
                flag &= TypeNameContainer<AvatarAction._Type>.RegisterType("GetHit", 7);
                flag &= TypeNameContainer<AvatarAction._Type>.RegisterType("Counter", 8);
                flag &= TypeNameContainer<AvatarAction._Type>.RegisterType("EnterBattleGround", 9);
                flag &= TypeNameContainer<AvatarAction._Type>.RegisterType("EnterScene", 10);
                flag &= TypeNameContainer<AvatarAction._Type>.RegisterType("Die", 11);
                flag &= TypeNameContainer<AvatarAction._Type>.RegisterType("Die_KO", 12);
                flag &= TypeNameContainer<AvatarAction._Type>.RegisterType("TurnRush", 13);
                flag &= TypeNameContainer<AvatarAction._Type>.RegisterType("TurnBack", 14);
                flag &= TypeNameContainer<AvatarAction._Type>.RegisterType("Win", 15);
                flag &= TypeNameContainer<AvatarAction._Type>.RegisterType("Lose", 0x10);
                flag &= TypeNameContainer<AvatarAction._Type>.RegisterType("Revive", 0x11);
                flag &= TypeNameContainer<AvatarAction._Type>.RegisterType("SkillStart", 0x12);
                flag &= TypeNameContainer<AvatarAction._Type>.RegisterType("CompositeSkillStart", 0x19);
                flag &= TypeNameContainer<AvatarAction._Type>.RegisterType("CompositeSupporterAction", 0x1a);
                flag &= TypeNameContainer<AvatarAction._Type>.RegisterType("SuperSkillStart", 0x13);
                flag &= TypeNameContainer<AvatarAction._Type>.RegisterType("SuperSkillEffect", 20);
                flag &= TypeNameContainer<AvatarAction._Type>.RegisterType("UseItem", 0x15);
                flag &= TypeNameContainer<AvatarAction._Type>.RegisterType("Dan_DmgHeal", 0x1b);
                flag &= TypeNameContainer<AvatarAction._Type>.RegisterType("Interface", 0x1c);
                flag &= TypeNameContainer<AvatarAction._Type>.RegisterType("Skill", 0x81);
                flag &= TypeNameContainer<AvatarAction._Type>.RegisterType("Idle", 160);
                flag &= TypeNameContainer<AvatarAction._Type>.RegisterType("RandomIdle", 0xa1);
                flag &= TypeNameContainer<AvatarAction._Type>.RegisterType("Walk", 0xa2);
                flag &= TypeNameContainer<AvatarAction._Type>.RegisterType("ChangleCloth", 0xa3);
                flag &= TypeNameContainer<AvatarAction._Type>.RegisterType("Run", 0xa4);
                flag &= TypeNameContainer<AvatarAction._Type>.RegisterType("EnterBlockingState", 240);
                flag &= TypeNameContainer<AvatarAction._Type>.RegisterType("OnCreateBuff", 0xf1);
                flag &= TypeNameContainer<AvatarAction._Type>.RegisterType("OnUpdateBuff", 0xf2);
                flag &= TypeNameContainer<AvatarAction._Type>.RegisterType("OnDeleteBuff", 0xf3);
                flag &= TypeNameContainer<AvatarAction._Type>.RegisterType("BuffTimeUp", 0xf4);
                flag &= TypeNameContainer<AvatarAction._Type>.RegisterType("MaxRound", 0xf5);
                flag &= TypeNameContainer<AvatarAction._Type>.RegisterType("CounterAttack_PAP", 0x16);
                flag &= TypeNameContainer<AvatarAction._Type>.RegisterType("CounterAttackStart", 0x18);
                flag &= TypeNameContainer<AvatarAction._Type>.RegisterType("CounterAttack_MAP", 0x17);
                flag &= TypeNameContainer<AvatarAction._Type>.RegisterType("BossAttack", 0xf6);
                flag &= TypeNameContainer<AvatarAction._Type>.RegisterType("BossGetHit", 0xf7);
                flag &= TypeNameContainer<AvatarAction._Type>.RegisterType("BossRoleDie", 0xf8);
                flag &= TypeNameContainer<AvatarAction._Type>.RegisterType("SelectRole", 0xf9);
                flag &= TypeNameContainer<AvatarAction._Type>.RegisterType("Dialogue", 250);
                flag &= TypeNameContainer<AvatarAction._Type>.RegisterType("DefaultRole", 0xfb);
                flag &= TypeNameContainer<AvatarAction._Type>.RegisterType("SpecialRole", 0xfc);
                flag &= TypeNameContainer<AvatarAction._Type>.RegisterType("DefaultIdle", 0xfd);
                flag &= TypeNameContainer<AvatarAction._Type>.RegisterType("MelaleucaFloorIdle", 0xfe);
                flag &= TypeNameContainer<AvatarAction._Type>.RegisterType("IllusionUIIdle", 0xd0);
                return (flag & TypeNameContainer<AvatarAction._Type>.RegisterType("IllusionUISelectRole", 0xd1));
            }
        }

        [ProtoContract(Name="Animation")]
        public class Animation : IExtensible
        {
            private string _animation = "";
            private int _type;
            private int _value;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue(""), ProtoMember(3, IsRequired=false, Name="animation", DataFormat=DataFormat.Default)]
            public string animation
            {
                get
                {
                    return this._animation;
                }
                set
                {
                    this._animation = value;
                }
            }

            [ProtoMember(1, IsRequired=false, Name="type", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int type
            {
                get
                {
                    return this._type;
                }
                set
                {
                    this._type = value;
                }
            }

            [ProtoMember(2, IsRequired=false, Name="value", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int value
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

        [ProtoContract(Name="Effect")]
        public class Effect : IExtensible
        {
            private float _cfx_Duration;
            private float _cfx_Intensity;
            private float _cfx_Interval;
            private bool _isGetHitFX;
            private string _pfx_Bone = "";
            private bool _pfx_BoneFollow;
            private string _pfx_Curve = "";
            private string _pfx_Curve_Miss = "";
            private float _pfx_CurveSpeed;
            private string _pfx_CurveTargetBone = "";
            private vector3 _pfx_CurveTargetOffset;
            private bool _pfx_CurveToTarget;
            private float _pfx_CurveTranslateSpeed;
            private int _pfx_DestroyType;
            private string _pfx_Model = "";
            private string _pfx_ModelBone = "";
            private vector3 _pfx_Offset;
            private bool _pfx_PlayOnTarget;
            private int _pfx_PlayTargetType;
            private vector3 _pfx_Rotate;
            private bool _sfx_Loop;
            private string _sfx_Sound = "";
            private float _sfx_Volume;
            private float _tfx_Duration;
            private float _tfx_Scale;
            private int _type;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue((float) 0f), ProtoMember(0x18, IsRequired=false, Name="cfx_Duration", DataFormat=DataFormat.FixedSize)]
            public float cfx_Duration
            {
                get
                {
                    return this._cfx_Duration;
                }
                set
                {
                    this._cfx_Duration = value;
                }
            }

            [DefaultValue((float) 0f), ProtoMember(0x17, IsRequired=false, Name="cfx_Intensity", DataFormat=DataFormat.FixedSize)]
            public float cfx_Intensity
            {
                get
                {
                    return this._cfx_Intensity;
                }
                set
                {
                    this._cfx_Intensity = value;
                }
            }

            [ProtoMember(0x19, IsRequired=false, Name="cfx_Interval", DataFormat=DataFormat.FixedSize), DefaultValue((float) 0f)]
            public float cfx_Interval
            {
                get
                {
                    return this._cfx_Interval;
                }
                set
                {
                    this._cfx_Interval = value;
                }
            }

            [DefaultValue(false), ProtoMember(2, IsRequired=false, Name="isGetHitFX", DataFormat=DataFormat.Default)]
            public bool isGetHitFX
            {
                get
                {
                    return this._isGetHitFX;
                }
                set
                {
                    this._isGetHitFX = value;
                }
            }

            [ProtoMember(6, IsRequired=false, Name="pfx_Bone", DataFormat=DataFormat.Default), DefaultValue("")]
            public string pfx_Bone
            {
                get
                {
                    return this._pfx_Bone;
                }
                set
                {
                    this._pfx_Bone = value;
                }
            }

            [ProtoMember(8, IsRequired=false, Name="pfx_BoneFollow", DataFormat=DataFormat.Default), DefaultValue(false)]
            public bool pfx_BoneFollow
            {
                get
                {
                    return this._pfx_BoneFollow;
                }
                set
                {
                    this._pfx_BoneFollow = value;
                }
            }

            [ProtoMember(9, IsRequired=false, Name="pfx_Curve", DataFormat=DataFormat.Default), DefaultValue("")]
            public string pfx_Curve
            {
                get
                {
                    return this._pfx_Curve;
                }
                set
                {
                    this._pfx_Curve = value;
                }
            }

            [ProtoMember(10, IsRequired=false, Name="pfx_Curve_Miss", DataFormat=DataFormat.Default), DefaultValue("")]
            public string pfx_Curve_Miss
            {
                get
                {
                    return this._pfx_Curve_Miss;
                }
                set
                {
                    this._pfx_Curve_Miss = value;
                }
            }

            [DefaultValue((float) 0f), ProtoMember(11, IsRequired=false, Name="pfx_CurveSpeed", DataFormat=DataFormat.FixedSize)]
            public float pfx_CurveSpeed
            {
                get
                {
                    return this._pfx_CurveSpeed;
                }
                set
                {
                    this._pfx_CurveSpeed = value;
                }
            }

            [DefaultValue(""), ProtoMember(13, IsRequired=false, Name="pfx_CurveTargetBone", DataFormat=DataFormat.Default)]
            public string pfx_CurveTargetBone
            {
                get
                {
                    return this._pfx_CurveTargetBone;
                }
                set
                {
                    this._pfx_CurveTargetBone = value;
                }
            }

            [DefaultValue((string) null), ProtoMember(14, IsRequired=false, Name="pfx_CurveTargetOffset", DataFormat=DataFormat.Default)]
            public vector3 pfx_CurveTargetOffset
            {
                get
                {
                    return this._pfx_CurveTargetOffset;
                }
                set
                {
                    this._pfx_CurveTargetOffset = value;
                }
            }

            [ProtoMember(12, IsRequired=false, Name="pfx_CurveToTarget", DataFormat=DataFormat.Default), DefaultValue(false)]
            public bool pfx_CurveToTarget
            {
                get
                {
                    return this._pfx_CurveToTarget;
                }
                set
                {
                    this._pfx_CurveToTarget = value;
                }
            }

            [ProtoMember(0x1d, IsRequired=false, Name="pfx_CurveTranslateSpeed", DataFormat=DataFormat.FixedSize), DefaultValue((float) 0f)]
            public float pfx_CurveTranslateSpeed
            {
                get
                {
                    return this._pfx_CurveTranslateSpeed;
                }
                set
                {
                    this._pfx_CurveTranslateSpeed = value;
                }
            }

            [DefaultValue(0), ProtoMember(15, IsRequired=false, Name="pfx_DestroyType", DataFormat=DataFormat.TwosComplement)]
            public int pfx_DestroyType
            {
                get
                {
                    return this._pfx_DestroyType;
                }
                set
                {
                    this._pfx_DestroyType = value;
                }
            }

            [DefaultValue(""), ProtoMember(5, IsRequired=false, Name="pfx_Model", DataFormat=DataFormat.Default)]
            public string pfx_Model
            {
                get
                {
                    return this._pfx_Model;
                }
                set
                {
                    this._pfx_Model = value;
                }
            }

            [ProtoMember(30, IsRequired=false, Name="pfx_ModelBone", DataFormat=DataFormat.Default), DefaultValue("")]
            public string pfx_ModelBone
            {
                get
                {
                    return this._pfx_ModelBone;
                }
                set
                {
                    this._pfx_ModelBone = value;
                }
            }

            [ProtoMember(7, IsRequired=false, Name="pfx_Offset", DataFormat=DataFormat.Default), DefaultValue((string) null)]
            public vector3 pfx_Offset
            {
                get
                {
                    return this._pfx_Offset;
                }
                set
                {
                    this._pfx_Offset = value;
                }
            }

            [ProtoMember(3, IsRequired=false, Name="pfx_PlayOnTarget", DataFormat=DataFormat.Default), DefaultValue(false)]
            public bool pfx_PlayOnTarget
            {
                get
                {
                    return this._pfx_PlayOnTarget;
                }
                set
                {
                    this._pfx_PlayOnTarget = value;
                }
            }

            [DefaultValue(0), ProtoMember(4, IsRequired=false, Name="pfx_PlayTargetType", DataFormat=DataFormat.TwosComplement)]
            public int pfx_PlayTargetType
            {
                get
                {
                    return this._pfx_PlayTargetType;
                }
                set
                {
                    this._pfx_PlayTargetType = value;
                }
            }

            [DefaultValue((string) null), ProtoMember(0x1c, IsRequired=false, Name="pfx_Rotate", DataFormat=DataFormat.Default)]
            public vector3 pfx_Rotate
            {
                get
                {
                    return this._pfx_Rotate;
                }
                set
                {
                    this._pfx_Rotate = value;
                }
            }

            [ProtoMember(0x15, IsRequired=false, Name="sfx_Loop", DataFormat=DataFormat.Default), DefaultValue(false)]
            public bool sfx_Loop
            {
                get
                {
                    return this._sfx_Loop;
                }
                set
                {
                    this._sfx_Loop = value;
                }
            }

            [ProtoMember(20, IsRequired=false, Name="sfx_Sound", DataFormat=DataFormat.Default), DefaultValue("")]
            public string sfx_Sound
            {
                get
                {
                    return this._sfx_Sound;
                }
                set
                {
                    this._sfx_Sound = value;
                }
            }

            [ProtoMember(0x16, IsRequired=false, Name="sfx_Volume", DataFormat=DataFormat.FixedSize), DefaultValue((float) 0f)]
            public float sfx_Volume
            {
                get
                {
                    return this._sfx_Volume;
                }
                set
                {
                    this._sfx_Volume = value;
                }
            }

            [DefaultValue((float) 0f), ProtoMember(0x1b, IsRequired=false, Name="tfx_Duration", DataFormat=DataFormat.FixedSize)]
            public float tfx_Duration
            {
                get
                {
                    return this._tfx_Duration;
                }
                set
                {
                    this._tfx_Duration = value;
                }
            }

            [ProtoMember(0x1a, IsRequired=false, Name="tfx_Scale", DataFormat=DataFormat.FixedSize), DefaultValue((float) 0f)]
            public float tfx_Scale
            {
                get
                {
                    return this._tfx_Scale;
                }
                set
                {
                    this._tfx_Scale = value;
                }
            }

            [ProtoMember(1, IsRequired=false, Name="type", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int type
            {
                get
                {
                    return this._type;
                }
                set
                {
                    this._type = value;
                }
            }

            public class _DestroyType : TypeNameContainer<AvatarAction.Effect._DestroyType>
            {
                public const int Action = 2;
                public const int BlockAction = 1;
                public const int Buff = 3;
                public const int Normal = 0;

                public static bool Initialize()
                {
                    bool flag = false;
                    flag &= TypeNameContainer<AvatarAction.Effect._DestroyType>.RegisterType("Normal", 0);
                    flag &= TypeNameContainer<AvatarAction.Effect._DestroyType>.RegisterType("BlockAction", 1);
                    flag &= TypeNameContainer<AvatarAction.Effect._DestroyType>.RegisterType("Action", 2);
                    return (flag & TypeNameContainer<AvatarAction.Effect._DestroyType>.RegisterType("Buff", 3));
                }
            }

            public class _PlayTargetType : TypeNameContainer<AvatarAction.Effect._PlayTargetType>
            {
                public const int Avatar = 0;
                public const int ColumnFront = 2;
                public const int RowCenter = 1;
                public const int SceneCenter = 4;
                public const int TeamCenter = 3;

                public static bool Initialize()
                {
                    bool flag = false;
                    flag &= TypeNameContainer<AvatarAction.Effect._PlayTargetType>.RegisterType("Avatar", 0);
                    flag &= TypeNameContainer<AvatarAction.Effect._PlayTargetType>.RegisterType("RowCenter", 1);
                    flag &= TypeNameContainer<AvatarAction.Effect._PlayTargetType>.RegisterType("ColumnFront", 2);
                    flag &= TypeNameContainer<AvatarAction.Effect._PlayTargetType>.RegisterType("TeamCenter", 3);
                    return (flag & TypeNameContainer<AvatarAction.Effect._PlayTargetType>.RegisterType("SceneCenter", 4));
                }
            }

            public class _Type : TypeNameContainer<AvatarAction.Effect._Type>
            {
                public const int CameraShake = 3;
                public const int PFX = 1;
                public const int SFX = 2;
                public const int TimeScale = 4;
                public const int Unknown = 0;

                public static bool Initialize()
                {
                    bool flag = false;
                    flag &= TypeNameContainer<AvatarAction.Effect._Type>.RegisterType("PFX", 1);
                    flag &= TypeNameContainer<AvatarAction.Effect._Type>.RegisterType("SFX", 2);
                    flag &= TypeNameContainer<AvatarAction.Effect._Type>.RegisterType("CameraShake", 3);
                    return (flag & TypeNameContainer<AvatarAction.Effect._Type>.RegisterType("TimeScale", 4));
                }
            }
        }

        [ProtoContract(Name="Event")]
        public class Event : IExtensible
        {
            private string _boneName = "";
            private int _buffId;
            private int _buffType;
            private float _delay;
            private readonly List<AvatarAction.Effect> _effects = new List<AvatarAction.Effect>();
            private int _eventType;
            private int _index;
            private int _keyFrameId;
            private bool _loop;
            private readonly List<PropertyModifierSet> _modifierSets = new List<PropertyModifierSet>();
            private int _modifyType;
            private bool _playOnAllTarget;
            private int _sourceTurnId;
            private int _testType;
            private int _weaponId;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            public bool IsLogicEvent()
            {
                return (((((this._eventType != 1) && (this._eventType != 0x10)) && ((this._eventType != 0x11) && (this._eventType != 0x13))) && ((this._eventType != 20) && (this._eventType != 0x15))) && (this._eventType != 0x16));
            }

            [ProtoMember(0x13, IsRequired=false, Name="boneName", DataFormat=DataFormat.Default), DefaultValue("")]
            public string boneName
            {
                get
                {
                    return this._boneName;
                }
                set
                {
                    this._boneName = value;
                }
            }

            [DefaultValue(0), ProtoMember(13, IsRequired=false, Name="buffId", DataFormat=DataFormat.TwosComplement)]
            public int buffId
            {
                get
                {
                    return this._buffId;
                }
                set
                {
                    this._buffId = value;
                }
            }

            [DefaultValue(0), ProtoMember(0x15, IsRequired=false, Name="buffType", DataFormat=DataFormat.TwosComplement)]
            public int buffType
            {
                get
                {
                    return this._buffType;
                }
                set
                {
                    this._buffType = value;
                }
            }

            [DefaultValue((float) 0f), ProtoMember(5, IsRequired=false, Name="delay", DataFormat=DataFormat.FixedSize)]
            public float delay
            {
                get
                {
                    return this._delay;
                }
                set
                {
                    this._delay = value;
                }
            }

            [ProtoMember(10, Name="effects", DataFormat=DataFormat.Default)]
            public List<AvatarAction.Effect> effects
            {
                get
                {
                    return this._effects;
                }
            }

            [DefaultValue(0), ProtoMember(4, IsRequired=false, Name="eventType", DataFormat=DataFormat.TwosComplement)]
            public int eventType
            {
                get
                {
                    return this._eventType;
                }
                set
                {
                    this._eventType = value;
                }
            }

            [DefaultValue(0), ProtoMember(2, IsRequired=false, Name="index", DataFormat=DataFormat.TwosComplement)]
            public int index
            {
                get
                {
                    return this._index;
                }
                set
                {
                    this._index = value;
                }
            }

            [ProtoMember(3, IsRequired=false, Name="keyFrameId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int keyFrameId
            {
                get
                {
                    return this._keyFrameId;
                }
                set
                {
                    this._keyFrameId = value;
                }
            }

            [DefaultValue(false), ProtoMember(6, IsRequired=false, Name="loop", DataFormat=DataFormat.Default)]
            public bool loop
            {
                get
                {
                    return this._loop;
                }
                set
                {
                    this._loop = value;
                }
            }

            [ProtoMember(20, Name="modifierSets", DataFormat=DataFormat.Default)]
            public List<PropertyModifierSet> modifierSets
            {
                get
                {
                    return this._modifierSets;
                }
            }

            [ProtoMember(0x17, IsRequired=false, Name="modifyType", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int modifyType
            {
                get
                {
                    return this._modifyType;
                }
                set
                {
                    this._modifyType = value;
                }
            }

            [DefaultValue(false), ProtoMember(7, IsRequired=false, Name="playOnAllTarget", DataFormat=DataFormat.Default)]
            public bool playOnAllTarget
            {
                get
                {
                    return this._playOnAllTarget;
                }
                set
                {
                    this._playOnAllTarget = value;
                }
            }

            [ProtoMember(1, IsRequired=false, Name="sourceTurnId", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int sourceTurnId
            {
                get
                {
                    return this._sourceTurnId;
                }
                set
                {
                    this._sourceTurnId = value;
                }
            }

            [ProtoMember(0x16, IsRequired=false, Name="testType", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int testType
            {
                get
                {
                    return this._testType;
                }
                set
                {
                    this._testType = value;
                }
            }

            [DefaultValue(0), ProtoMember(0x12, IsRequired=false, Name="weaponId", DataFormat=DataFormat.TwosComplement)]
            public int weaponId
            {
                get
                {
                    return this._weaponId;
                }
                set
                {
                    this._weaponId = value;
                }
            }

            public class _Type : TypeNameContainer<AvatarAction.Event._Type>
            {
                public const int AddBuff = 4;
                public const int AttributeChange = 0x1f;
                public const int BuffTimeUp = 6;
                public const int ChangeBattlePosition = 0x1c;
                public const int ChangeWeapon = 0x15;
                public const int CompositeSkillStart = 13;
                public const int CounterAttackStart = 0x18;
                public const int Damage = 2;
                public const int Dan_DamageHeal = 0x20;
                public const int DeleteBuff = 0x19;
                public const int EnterBattleGround = 15;
                public const int EnterState = 9;
                public const int Heal = 14;
                public const int HideWeapon = 0x13;
                public const int InactiveAvatar = 0x11;
                public const int LeaveState = 10;
                public const int PlayEffect = 1;
                public const int RecoverWeapon = 0x16;
                public const int RefreshBuff = 5;
                public const int RemoveAllBuff = 8;
                public const int RemoveBuff = 7;
                public const int SetBattleTrans = 0x1d;
                public const int SetSkillPower = 0x17;
                public const int ShowAvatar = 0x10;
                public const int ShowBattleBar = 30;
                public const int ShowDialogue = 0x1b;
                public const int ShowWeapon = 20;
                public const int SkillStart = 11;
                public const int SPDamage = 0x1a;
                public const int SuperSkillEffect = 12;
                public const int ThrowDamage = 3;
                public const int Unknown = 0;

                public static bool Initialize()
                {
                    bool flag = false;
                    flag &= TypeNameContainer<AvatarAction.Event._Type>.RegisterType("PlayEffect", 1);
                    flag &= TypeNameContainer<AvatarAction.Event._Type>.RegisterType("Damage", 2);
                    flag &= TypeNameContainer<AvatarAction.Event._Type>.RegisterType("SPDamage", 0x1a);
                    flag &= TypeNameContainer<AvatarAction.Event._Type>.RegisterType("ThrowDamage", 3);
                    flag &= TypeNameContainer<AvatarAction.Event._Type>.RegisterType("AddBuff", 4);
                    flag &= TypeNameContainer<AvatarAction.Event._Type>.RegisterType("BuffTimeUp", 6);
                    flag &= TypeNameContainer<AvatarAction.Event._Type>.RegisterType("RemoveBuff", 7);
                    flag &= TypeNameContainer<AvatarAction.Event._Type>.RegisterType("RemoveAllBuff", 8);
                    flag &= TypeNameContainer<AvatarAction.Event._Type>.RegisterType("EnterState", 9);
                    flag &= TypeNameContainer<AvatarAction.Event._Type>.RegisterType("LeaveState", 10);
                    flag &= TypeNameContainer<AvatarAction.Event._Type>.RegisterType("SkillStart", 11);
                    flag &= TypeNameContainer<AvatarAction.Event._Type>.RegisterType("SuperSkillEffect", 12);
                    flag &= TypeNameContainer<AvatarAction.Event._Type>.RegisterType("CompositeSkillStart", 13);
                    flag &= TypeNameContainer<AvatarAction.Event._Type>.RegisterType("Heal", 14);
                    flag &= TypeNameContainer<AvatarAction.Event._Type>.RegisterType("EnterBattleGround", 15);
                    flag &= TypeNameContainer<AvatarAction.Event._Type>.RegisterType("ShowAvatar", 0x10);
                    flag &= TypeNameContainer<AvatarAction.Event._Type>.RegisterType("InactiveAvatar", 0x11);
                    flag &= TypeNameContainer<AvatarAction.Event._Type>.RegisterType("HideWeapon", 0x13);
                    flag &= TypeNameContainer<AvatarAction.Event._Type>.RegisterType("ShowWeapon", 20);
                    flag &= TypeNameContainer<AvatarAction.Event._Type>.RegisterType("ChangeWeapon", 0x15);
                    flag &= TypeNameContainer<AvatarAction.Event._Type>.RegisterType("RecoverWeapon", 0x16);
                    flag &= TypeNameContainer<AvatarAction.Event._Type>.RegisterType("SetSkillPower", 0x17);
                    flag &= TypeNameContainer<AvatarAction.Event._Type>.RegisterType("CounterAttackStart", 0x18);
                    flag &= TypeNameContainer<AvatarAction.Event._Type>.RegisterType("DeleteBuff", 0x19);
                    flag &= TypeNameContainer<AvatarAction.Event._Type>.RegisterType("ShowDialogue", 0x1b);
                    flag &= TypeNameContainer<AvatarAction.Event._Type>.RegisterType("ChangeBattlePosition", 0x1c);
                    flag &= TypeNameContainer<AvatarAction.Event._Type>.RegisterType("SetBattleTrans", 0x1d);
                    flag &= TypeNameContainer<AvatarAction.Event._Type>.RegisterType("ShowBattleBar", 30);
                    flag &= TypeNameContainer<AvatarAction.Event._Type>.RegisterType("AttributeChange", 0x1f);
                    return (flag & TypeNameContainer<AvatarAction.Event._Type>.RegisterType("Dan_DamageHeal", 0x20));
                }
            }
        }
    }
}

