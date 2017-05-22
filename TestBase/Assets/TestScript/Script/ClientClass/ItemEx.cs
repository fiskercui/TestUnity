namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;

    public class ItemEx
    {
        private int count;
        private int extensionBreakThroughLevelFrom;
        private int extensionBreakThroughLevelTo;
        private int extensionLevelFrom;
        private int extensionLevelTo;
        private int id;

        public WeihuaGames.ClientClass.ItemEx FromProtobuf(com.kodgames.corgi.protocol.ItemEx itemEx)
        {
            if (itemEx != null)
            {
                this.id = itemEx.id;
                this.count = itemEx.count;
                this.extensionBreakThroughLevelFrom = itemEx.extensionBreakThroughLevelFrom;
                this.extensionBreakThroughLevelTo = itemEx.extensionBreakThroughLevelTo;
                this.extensionLevelFrom = itemEx.extensionLevelFrom;
                this.extensionLevelTo = itemEx.extensionLevelTo;
            }
            return this;
        }

        public int Count
        {
            get
            {
                return this.count;
            }
            set
            {
                this.count = value;
            }
        }

        public int ExtensionBreakThroughLevelFrom
        {
            get
            {
                return this.extensionBreakThroughLevelFrom;
            }
            set
            {
                this.extensionBreakThroughLevelFrom = value;
            }
        }

        public int ExtensionBreakThroughLevelTo
        {
            get
            {
                return this.extensionBreakThroughLevelTo;
            }
            set
            {
                this.extensionBreakThroughLevelTo = value;
            }
        }

        public int ExtensionLevelFrom
        {
            get
            {
                return this.extensionLevelFrom;
            }
            set
            {
                this.extensionLevelFrom = value;
            }
        }

        public int ExtensionLevelTo
        {
            get
            {
                return this.extensionLevelTo;
            }
            set
            {
                this.extensionLevelTo = value;
            }
        }

        public int Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }
    }
}

