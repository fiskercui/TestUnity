namespace ClientServerCommon
{
    using System;
    using System.Security;

    public abstract class Configuration
    {
        private ConfigDatabase cfgDB;
        private bool delayUnload;

        protected Configuration()
        {
        }

        public virtual void AfterSerialize()
        {
        }

        public virtual void BeforSerialize()
        {
        }

        public virtual void ConstructLogicData(ConfigDatabase cfgDB, int fileFormat)
        {
            this.cfgDB = cfgDB;
        }

        public virtual void LoadFromXml(SecurityElement element)
        {
        }

        public virtual void Validate()
        {
        }

        public ConfigDatabase CfgDB
        {
            get
            {
                return this.cfgDB;
            }
        }

        public bool DelayUnload
        {
            get
            {
                return this.delayUnload;
            }
            set
            {
                this.delayUnload = value;
            }
        }

        public class _FileFormat
        {
            public const int ProtoBufBinary = 2;
            public const int Unknown = 0;
            public const int Xml = 1;
            public const int XMLMemory = 3;
        }
    }
}

