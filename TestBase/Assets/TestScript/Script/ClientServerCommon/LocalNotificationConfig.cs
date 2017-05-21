namespace ClientServerCommon
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Security;

    [ProtoContract(Name="LocalNotificationConfig")]
    public class LocalNotificationConfig : Configuration, IExtensible
    {
        private readonly List<Notification> _localNotifications = new List<Notification>();
        private IExtension extensionObject;

        public List<Notification> GetNotificationsByType(int type)
        {
            List<Notification> list = new List<Notification>();
            foreach (Notification notification in this._localNotifications)
            {
                if (notification.type == type)
                {
                    list.Add(notification);
                }
            }
            return list;
        }

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        public static void Initialize()
        {
            _NotificationType.Initialize();
        }

        public override void LoadFromXml(SecurityElement element)
        {
            if ((element.Tag == "LocalNotificationConfig") && (element.Children != null))
            {
                foreach (SecurityElement element2 in element.Children)
                {
                    string str;
                    if (((str = element2.Tag) != null) && (str == "Notification"))
                    {
                        this._localNotifications.Add(this.LoadNotification(element2));
                    }
                }
            }
        }

        private Notification LoadNotification(SecurityElement element)
        {
            return new Notification { 
                type = TypeNameContainer<_NotificationType>.Parse(StrParser.ParseStr(element.Attribute("Type"), ""), 0),
                messageBody = StrParser.ParseStr(element.Attribute("MessageBody"), ""),
                hasAction = StrParser.ParseBool(element.Attribute("HasAction"), false),
                actionTitle = StrParser.ParseStr(element.Attribute("ActionTitle"), ""),
                appIconBadageNumber = StrParser.ParseDecInt(element.Attribute("AppIconBadageNumber"), 0),
                isOpen = StrParser.ParseBool(element.Attribute("IsOpen"), false),
                delayTime = StrParser.ParseDecLong(element.Attribute("DelayTime"), 0L)
            };
        }

        [ProtoMember(1, Name="localNotifications", DataFormat=DataFormat.Default)]
        public List<Notification> localNotifications
        {
            get
            {
                return this._localNotifications;
            }
        }

        public class _NotificationType : TypeNameContainer<LocalNotificationConfig._NotificationType>
        {
            public const int FixedTimeActivity = 2;
            public const int Login = 1;
            public const int RecallPlayer = 4;
            public const int Stamina = 3;
            public const int Travern = 5;
            public const int Unkonwn = 0;

            public static bool Initialize()
            {
                bool flag = false;
                flag &= TypeNameContainer<LocalNotificationConfig._NotificationType>.RegisterType("Login", 1, "Login");
                flag &= TypeNameContainer<LocalNotificationConfig._NotificationType>.RegisterType("FixedTimeActivity", 2, "FixedTimeActivity");
                flag &= TypeNameContainer<LocalNotificationConfig._NotificationType>.RegisterType("Stamina", 3, "Stamina");
                flag &= TypeNameContainer<LocalNotificationConfig._NotificationType>.RegisterType("RecallPlayer", 4, "RecallPlayer");
                return (flag & TypeNameContainer<LocalNotificationConfig._NotificationType>.RegisterType("Travern", 5, "Travern"));
            }
        }

        [ProtoContract(Name="Notification")]
        public class Notification : IExtensible
        {
            private string _actionTitle = "";
            private int _appIconBadageNumber;
            private long _delayTime;
            private bool _hasAction;
            private bool _isOpen;
            private string _messageBody = "";
            private int _type;
            private IExtension extensionObject;

            IExtension IExtensible.GetExtensionObject(bool createIfMissing)
            {
                return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
            }

            [DefaultValue(""), ProtoMember(4, IsRequired=false, Name="actionTitle", DataFormat=DataFormat.Default)]
            public string actionTitle
            {
                get
                {
                    return this._actionTitle;
                }
                set
                {
                    this._actionTitle = value;
                }
            }

            [DefaultValue(0), ProtoMember(5, IsRequired=false, Name="appIconBadageNumber", DataFormat=DataFormat.TwosComplement)]
            public int appIconBadageNumber
            {
                get
                {
                    return this._appIconBadageNumber;
                }
                set
                {
                    this._appIconBadageNumber = value;
                }
            }

            [ProtoMember(7, IsRequired=false, Name="delayTime", DataFormat=DataFormat.TwosComplement), DefaultValue((long) 0L)]
            public long delayTime
            {
                get
                {
                    return this._delayTime;
                }
                set
                {
                    this._delayTime = value;
                }
            }

            [ProtoMember(3, IsRequired=false, Name="hasAction", DataFormat=DataFormat.Default), DefaultValue(false)]
            public bool hasAction
            {
                get
                {
                    return this._hasAction;
                }
                set
                {
                    this._hasAction = value;
                }
            }

            [DefaultValue(false), ProtoMember(6, IsRequired=false, Name="isOpen", DataFormat=DataFormat.Default)]
            public bool isOpen
            {
                get
                {
                    return this._isOpen;
                }
                set
                {
                    this._isOpen = value;
                }
            }

            [ProtoMember(2, IsRequired=false, Name="messageBody", DataFormat=DataFormat.Default), DefaultValue("")]
            public string messageBody
            {
                get
                {
                    return this._messageBody;
                }
                set
                {
                    this._messageBody = value;
                }
            }

            [DefaultValue(0), ProtoMember(1, IsRequired=false, Name="type", DataFormat=DataFormat.TwosComplement)]
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
        }
    }
}

