namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;

    public class Location
    {
        private string guid;
        private int index;
        private int locationId;
        private int positionId;
        private int resourceId;
        private int showLocationId;

        public void FromProtobuf(com.kodgames.corgi.protocol.Location location)
        {
            this.guid = location.guid;
            this.resourceId = location.recourseId;
            this.locationId = location.locationId;
            this.positionId = location.positionId;
            this.showLocationId = location.showLocationId;
            this.index = location.index;
        }

        public void ShallowCopy(WeihuaGames.ClientClass.Location location)
        {
            this.guid = location.guid;
            this.resourceId = location.resourceId;
            this.positionId = location.positionId;
            this.locationId = location.locationId;
            this.showLocationId = location.showLocationId;
            this.index = location.index;
        }

        public com.kodgames.corgi.protocol.Location ToProtobuf()
        {
            return new com.kodgames.corgi.protocol.Location { 
                guid = this.guid,
                recourseId = this.resourceId,
                locationId = this.locationId,
                positionId = this.positionId,
                showLocationId = this.showLocationId,
                index = this.index
            };
        }

        public string Guid
        {
            get
            {
                return this.guid;
            }
            set
            {
                this.guid = value;
            }
        }

        public int Index
        {
            get
            {
                return this.index;
            }
            set
            {
                this.index = value;
            }
        }

        public int LocationId
        {
            get
            {
                return this.locationId;
            }
            set
            {
                this.locationId = value;
            }
        }

        public int PositionId
        {
            get
            {
                return this.positionId;
            }
            set
            {
                this.positionId = value;
            }
        }

        public int ResourceId
        {
            get
            {
                return this.resourceId;
            }
            set
            {
                this.resourceId = value;
            }
        }

        public int ShowLocationId
        {
            get
            {
                return this.showLocationId;
            }
            set
            {
                this.showLocationId = value;
            }
        }
    }
}

