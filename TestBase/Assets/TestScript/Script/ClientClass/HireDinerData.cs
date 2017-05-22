namespace WeihuaGames.ClientClass
{
    using com.kodgames.corgi.protocol;
    using System;
    using System.Collections.Generic;

    public class HireDinerData
    {
        private Dictionary<int, WeihuaGames.ClientClass.DinerPackage> dic_packages = new Dictionary<int, WeihuaGames.ClientClass.DinerPackage>();
        private List<WeihuaGames.ClientClass.DinerPackage> dinerPackages;
        private List<WeihuaGames.ClientClass.HiredDiner> hireDiners = new List<WeihuaGames.ClientClass.HiredDiner>();

        public WeihuaGames.ClientClass.HireDinerData FromProtoBuf(com.kodgames.corgi.protocol.HireDinerData proto)
        {
            if (proto != null)
            {
                foreach (com.kodgames.corgi.protocol.HiredDiner diner in proto.hireDiners)
                {
                    this.hireDiners.Add(new WeihuaGames.ClientClass.HiredDiner().FromProtoBuf(diner));
                }
            }
            return this;
        }

        public WeihuaGames.ClientClass.DinerPackage GetDinerPackageByQualityType(int qualityType)
        {
            if (this.dic_packages.ContainsKey(qualityType))
            {
                return this.dic_packages[qualityType];
            }
            return null;
        }

        public WeihuaGames.ClientClass.HiredDiner GetHiredDiner(int qualityType, int dinerID)
        {
            foreach (WeihuaGames.ClientClass.HiredDiner diner in this.hireDiners)
            {
                if ((diner.QualityType == qualityType) && (diner.DinerId == dinerID))
                {
                    return diner;
                }
            }
            return null;
        }

        public WeihuaGames.ClientClass.QueryDiner GetQueryDiner(int qualityType, int dinerID)
        {
            WeihuaGames.ClientClass.DinerPackage dinerPackageByQualityType = this.GetDinerPackageByQualityType(qualityType);
            if (dinerPackageByQualityType == null)
            {
                return null;
            }
            return dinerPackageByQualityType.GetQueryDinerById(dinerID);
        }

        public void SetDinerPackage(List<WeihuaGames.ClientClass.DinerPackage> packages)
        {
            if (packages != null)
            {
                if (this.dinerPackages != null)
                {
                    this.dinerPackages.Clear();
                }
                else
                {
                    this.dinerPackages = new List<WeihuaGames.ClientClass.DinerPackage>();
                }
                this.dic_packages.Clear();
                foreach (WeihuaGames.ClientClass.DinerPackage package in packages)
                {
                    WeihuaGames.ClientClass.DinerPackage item = new WeihuaGames.ClientClass.DinerPackage();
                    item.ShallowCopy(package);
                    this.dinerPackages.Add(item);
                    this.dic_packages.Add(item.QualityType, item);
                }
            }
        }

        public List<WeihuaGames.ClientClass.DinerPackage> DinerPackages
        {
            get
            {
                return this.dinerPackages;
            }
            set
            {
                this.dinerPackages = value;
            }
        }

        public List<WeihuaGames.ClientClass.HiredDiner> HireDiners
        {
            get
            {
                return this.hireDiners;
            }
            set
            {
                this.hireDiners = value;
            }
        }
    }
}

