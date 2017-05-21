namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Security;

    [ProtoContract(Name="AnimationConfig")]
    public class AnimationConfig : Configuration, IExtensible
    {
        private readonly List<Animation> _animations = new List<Animation>();
        private readonly List<DefaultAnimation> _defaultAnimations = new List<DefaultAnimation>();
        private IExtension extensionObject;

        public override void ConstructLogicData(ConfigDatabase cfgDB, int fileFormat)
        {
            base.ConstructLogicData(cfgDB, fileFormat);
            for (int i = 0; i < this.animations.Count; i++)
            {
                Animation animation = this.animations[i];
                foreach (Event event2 in animation.events)
                {
                    if (event2 != null)
                    {
                        if (animation.id_EventMap.ContainsKey(event2.id))
                        {
                            Logger.Error(base.GetType().Name + " ContainsKey 0x" + event2.id.ToString("X"), new object[0]);
                        }
                        else
                        {
                            animation.id_EventMap.Add(event2.id, event2);
                        }
                    }
                }
            }
        }

        public Animation GetAnimation(string animationName)
        {
            for (int i = 0; i < this.animations.Count; i++)
            {
                if (this.animations[i].name.CompareTo(animationName) == 0)
                {
                    return this.animations[i];
                }
            }
            return null;
        }

        public Event GetAnimationEvent(string animationName, int eventId)
        {
            Event event2;
            Animation animation = this.GetAnimation(animationName);
            if (animation == null)
            {
                return null;
            }
            if (!animation.id_EventMap.TryGetValue(eventId, out event2))
            {
                return null;
            }
            return event2;
        }

        public string GetDefaultAnimation(int avatarAssetType)
        {
            for (int i = 0; i < this.defaultAnimations.Count; i++)
            {
                if (this.defaultAnimations[i].avatarAssetType == avatarAssetType)
                {
                    return this.defaultAnimations[i].animationName;
                }
            }
            return "";
        }

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        private Animation LoadAnimationFromXml(SecurityElement element)
        {
            Animation animation = new Animation {
                name = StrParser.ParseStr(element.Attribute("Name"), ""),
                assetName = StrParser.ParseStr(element.Attribute("AssetName"), ""),
                startFrame = StrParser.ParseDecInt(element.Attribute("StartFrame"), 0),
                endFrame = StrParser.ParseDecInt(element.Attribute("EndFrame"), 0),
                moveStartFrame = StrParser.ParseDecInt(element.Attribute("MoveStartFrame"), 0),
                moveEndFrame = StrParser.ParseDecInt(element.Attribute("MoveEndFrame"), 0),
                speed = StrParser.ParseFloat(element.Attribute("Speed"), 1f)
            };
            if (element.Children != null)
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    if (element2.Tag == "Event")
                    {
                        Event item = new Event {
                            id = StrParser.ParseDecInt(element2.Attribute("Id"), 0),
                            keyFrame = StrParser.ParseDecInt(element2.Attribute("KeyFrame"), 0)
                        };
                        animation.events.Add(item);
                    }
                }
            }
            return animation;
        }

        private DefaultAnimation LoadDefaultAnimationFromXml(SecurityElement element)
        {
            DefaultAnimation animation = new DefaultAnimation {
                avatarAssetType = StrParser.ParseHexInt(element.Attribute("AvatarAssetType"), 0)
            };
            animation.animationName = StrParser.ParseStr(element.Attribute("AnimationName"), animation.animationName);
            return animation;
        }

        private void LoadDefaultAnimationSetFromXml(SecurityElement element)
        {
            if ((element.Tag == "DefaultAnimationSet") && (element.Children != null))
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    if (element2.Tag == "DefaultAnimation")
                    {
                        this.defaultAnimations.Add(this.LoadDefaultAnimationFromXml(element2));
                    }
                }
            }
        }

        public override void LoadFromXml(SecurityElement element)
        {
            if ((element.Tag == "AnimationConfig") && (element.Children != null))
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    if (element2.Tag == "Animation")
                    {
                        this.animations.Add(this.LoadAnimationFromXml(element2));
                    }
                    else if (element2.Tag == "DefaultAnimationSet")
                    {
                        this.LoadDefaultAnimationSetFromXml(element2);
                    }
                }
            }
        }

        [ProtoMember(1, Name="animations", DataFormat=DataFormat.Default)]
        public List<Animation> animations
        {
            get
            {
                return this._animations;
            }
        }

        [ProtoMember(2, Name="defaultAnimations", DataFormat=DataFormat.Default)]
        public List<DefaultAnimation> defaultAnimations
        {
            get
            {
                return this._defaultAnimations;
            }
        }

        [ProtoContract(Name="Animation")]
        public class Animation : IExtensible
        {
            private string _assetName = "";
            private int _endFrame;
            private readonly List<AnimationConfig.Event> _events = new List<AnimationConfig.Event>();
            private Dictionary<int, AnimationConfig.Event> _id_eventMap = new Dictionary<int, AnimationConfig.Event>();
            private int _moveEndFrame;
            private int _moveStartFrame;
            private string _name = "";
            private float _speed;
            private int _startFrame;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue(""), ProtoMember(2, IsRequired=false, Name="assetName", DataFormat=DataFormat.Default)]
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

            [DefaultValue(0), ProtoMember(4, IsRequired=false, Name="endFrame", DataFormat=DataFormat.TwosComplement)]
            public int endFrame
            {
                get
                {
                    return this._endFrame;
                }
                set
                {
                    this._endFrame = value;
                }
            }

            [ProtoMember(8, Name="events", DataFormat=DataFormat.Default)]
            public List<AnimationConfig.Event> events
            {
                get
                {
                    return this._events;
                }
            }

            public Dictionary<int, AnimationConfig.Event> id_EventMap
            {
                get
                {
                    return this._id_eventMap;
                }
                set
                {
                    this._id_eventMap = value;
                }
            }

            [ProtoMember(6, IsRequired=false, Name="moveEndFrame", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int moveEndFrame
            {
                get
                {
                    return this._moveEndFrame;
                }
                set
                {
                    this._moveEndFrame = value;
                }
            }

            [DefaultValue(0), ProtoMember(5, IsRequired=false, Name="moveStartFrame", DataFormat=DataFormat.TwosComplement)]
            public int moveStartFrame
            {
                get
                {
                    return this._moveStartFrame;
                }
                set
                {
                    this._moveStartFrame = value;
                }
            }

            [DefaultValue(""), ProtoMember(1, IsRequired=false, Name="name", DataFormat=DataFormat.Default)]
            public string name
            {
                get
                {
                    return this._name;
                }
                set
                {
                    this._name = value;
                }
            }

            [DefaultValue((float) 0f), ProtoMember(7, IsRequired=false, Name="speed", DataFormat=DataFormat.FixedSize)]
            public float speed
            {
                get
                {
                    return this._speed;
                }
                set
                {
                    this._speed = value;
                }
            }

            [ProtoMember(3, IsRequired=false, Name="startFrame", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int startFrame
            {
                get
                {
                    return this._startFrame;
                }
                set
                {
                    this._startFrame = value;
                }
            }
        }

        [ProtoContract(Name="DefaultAnimation")]
        public class DefaultAnimation : IExtensible
        {
            private string _animationName = "";
            private int _avatarAssetType;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(2, IsRequired=false, Name="animationName", DataFormat=DataFormat.Default), DefaultValue("")]
            public string animationName
            {
                get
                {
                    return this._animationName;
                }
                set
                {
                    this._animationName = value;
                }
            }

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="avatarAssetType", DataFormat=DataFormat.TwosComplement)]
            public int avatarAssetType
            {
                get
                {
                    return this._avatarAssetType;
                }
                set
                {
                    this._avatarAssetType = value;
                }
            }
        }

        [ProtoContract(Name="Event")]
        public class Event : IExtensible
        {
            private int _id;
            private int _keyFrame;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [ProtoMember(1, IsRequired=false, Name="id", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
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

            [ProtoMember(2, IsRequired=false, Name="keyFrame", DataFormat=DataFormat.TwosComplement), DefaultValue(0)]
            public int keyFrame
            {
                get
                {
                    return this._keyFrame;
                }
                set
                {
                    this._keyFrame = value;
                }
            }
        }
    }
}

