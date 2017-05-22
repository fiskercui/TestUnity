namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;

    public class EquipmentData
    {
        private int breakThrough;
        private int id;

        public void Copy(WeihuaGames.ClientClass.EquipmentData equipmentData)
        {
            this.id = equipmentData.id;
            this.breakThrough = equipmentData.breakThrough;
        }

        public WeihuaGames.ClientClass.EquipmentData FromProtobuf(com.kodgames.corgi.protocol.EquipmentData protocol)
        {
            this.id = protocol.id;
            this.breakThrough = protocol.breakThrough;
            return this;
        }

        public com.kodgames.corgi.protocol.EquipmentData ToProtobuf()
        {
            return new com.kodgames.corgi.protocol.EquipmentData { 
                id = this.id,
                breakThrough = this.breakThrough
            };
        }

        public int BreakThrough
        {
            get
            {
                return this.breakThrough;
            }
            set
            {
                this.breakThrough = value;
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

