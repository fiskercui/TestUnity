namespace com.kodgames.corgi.protocol
{
    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ProtoContract(Name="RobotInfo")]
    public class RobotInfo : IExtensible
    {
        private bool _isRobot;
        private string _name = "";
        private readonly List<RobotNpc> _robotNpcs = new List<RobotNpc>();
        private IExtension extensionObject;

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }

        [DefaultValue(false), ProtoMember(1, IsRequired=false, Name="isRobot", DataFormat=DataFormat.Default)]
        public bool isRobot
        {
            get
            {
                return this._isRobot;
            }
            set
            {
                this._isRobot = value;
            }
        }

        [DefaultValue(""), ProtoMember(2, IsRequired=false, Name="name", DataFormat=DataFormat.Default)]
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

        [ProtoMember(3, Name="robotNpcs", DataFormat=DataFormat.Default)]
        public List<RobotNpc> robotNpcs
        {
            get
            {
                return this._robotNpcs;
            }
        }
    }
}

