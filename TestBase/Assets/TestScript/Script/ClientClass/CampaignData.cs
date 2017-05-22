namespace WeihuaGames.ClientClass
{
    using System;
    using System.Collections.Generic;

    public class CampaignData
    {
        private Dictionary<int, List<DungeonGuideNpc>> dic_dungeonGuidNpcs = new Dictionary<int, List<DungeonGuideNpc>>();
        private Dictionary<int, List<RecruiteNpc>> dic_recruiteNpcs = new Dictionary<int, List<RecruiteNpc>>();
        private Dictionary<int, TravelData> dic_travelDatas = new Dictionary<int, TravelData>();
        private bool interruptCampaign;
        private int lastBattleDungeonId;
        private int lastBattleZoneId;
        private int lastNormalBattleDungeonId;
        private int lastNormalBattleZoneId;
        private long lastResetDungeonTime;
        private int lastSecretBattleDungeonId;
        private int lastSecretBattleZoneId;
        private Dictionary<int, int> localRecordDiffTab = new Dictionary<int, int>();
        private int positionId;
        private Dictionary<int, Zone> zones;

        public List<DungeonGuideNpc> GetDungeonGuidNpcsByDungeonId(int dungeonId)
        {
            if (this.dic_dungeonGuidNpcs.ContainsKey(dungeonId))
            {
                return this.dic_dungeonGuidNpcs[dungeonId];
            }
            return null;
        }

        public List<RecruiteNpc> GetDungeonRecruiteNpcs(int dungeonId)
        {
            if (this.dic_recruiteNpcs.ContainsKey(dungeonId))
            {
                return this.dic_recruiteNpcs[dungeonId];
            }
            return null;
        }

        public int GetDungeonStatus(int zoneId, int dungeonId)
        {
            Dungeon dungeon = this.SearchDungeon(zoneId, dungeonId);
            if (dungeon == null)
            {
                return 0;
            }
            return dungeon.DungeonStatus;
        }

        public TravelData GetDungeonTravelDataByDungeonId(int dungeonId)
        {
            if (this.dic_travelDatas.ContainsKey(dungeonId))
            {
                return this.dic_travelDatas[dungeonId];
            }
            return null;
        }

        public Dungeon SearchDungeon(int zoneID, int dungeonID)
        {
            Zone zone = this.SearchZone(zoneID);
            if ((zone != null) && (zone.DungeonDifficulties != null))
            {
                foreach (DungeonDifficulty difficulty in zone.DungeonDifficulties)
                {
                    if (difficulty.Dungeons != null)
                    {
                        foreach (Dungeon dungeon in difficulty.Dungeons)
                        {
                            if (dungeonID == dungeon.DungeonId)
                            {
                                return dungeon;
                            }
                        }
                    }
                }
            }
            return null;
        }

        public Zone SearchZone(int zoneID)
        {
            if (this.zones.ContainsKey(zoneID))
            {
                return this.zones[zoneID];
            }
            return null;
        }

        public void SetDungeonGuidNpcs(int dungeonId, List<DungeonGuideNpc> dungeonGuidNpcs)
        {
            if (!this.dic_dungeonGuidNpcs.ContainsKey(dungeonId))
            {
                this.dic_dungeonGuidNpcs.Add(dungeonId, new List<DungeonGuideNpc>());
            }
            this.dic_dungeonGuidNpcs[dungeonId].Clear();
            foreach (DungeonGuideNpc npc in dungeonGuidNpcs)
            {
                DungeonGuideNpc item = new DungeonGuideNpc();
                item.ShallowCopy(npc);
                this.dic_dungeonGuidNpcs[dungeonId].Add(item);
            }
        }

        public void SetDungeonRecruiteNpcs(int dungeonId, List<RecruiteNpc> npcs)
        {
            if (!this.dic_recruiteNpcs.ContainsKey(dungeonId))
            {
                this.dic_recruiteNpcs.Add(dungeonId, new List<RecruiteNpc>());
            }
            this.dic_recruiteNpcs[dungeonId].Clear();
            foreach (RecruiteNpc npc in npcs)
            {
                RecruiteNpc item = new RecruiteNpc();
                item.ShallowCopy(npc);
                this.dic_recruiteNpcs[dungeonId].Add(item);
            }
        }

        public void SetDungeonTravelData(int dungeonId, TravelData travelData)
        {
            if (!this.dic_travelDatas.ContainsKey(dungeonId))
            {
                this.dic_travelDatas.Add(dungeonId, new TravelData());
            }
            this.dic_travelDatas[dungeonId].ShallowCopy(travelData);
        }

        public void SetZones(List<Zone> tempZones)
        {
            if ((tempZones != null) && (tempZones.Count > 0))
            {
                if (this.zones == null)
                {
                    this.zones = new Dictionary<int, Zone>();
                }
                foreach (Zone zone in tempZones)
                {
                    if (this.zones.ContainsKey(zone.ZoneId))
                    {
                        this.zones[zone.ZoneId] = zone;
                    }
                    else
                    {
                        this.zones.Add(zone.ZoneId, zone);
                    }
                }
            }
        }

        public void UpdateTravelData(TravelData travelData)
        {
            int dungeonId = travelData.DungeonId;
            if (dungeonId != 0)
            {
                if (!this.dic_travelDatas.ContainsKey(dungeonId))
                {
                    this.dic_travelDatas.Add(dungeonId, new TravelData());
                }
                this.dic_travelDatas[dungeonId].ShallowCopy(travelData);
            }
        }

        public bool InterruptCampaign
        {
            get
            {
                return this.interruptCampaign;
            }
            set
            {
                this.interruptCampaign = value;
            }
        }

        public int LastBattleDungeonId
        {
            get
            {
                return this.lastBattleDungeonId;
            }
            set
            {
                this.lastBattleDungeonId = value;
            }
        }

        public int LastBattleZoneID
        {
            get
            {
                return this.lastBattleZoneId;
            }
            set
            {
                this.lastBattleZoneId = value;
            }
        }

        public int LastNormalBattleDungeonId
        {
            get
            {
                return this.lastNormalBattleDungeonId;
            }
            set
            {
                this.lastNormalBattleDungeonId = value;
            }
        }

        public int LastNormalBattleZoneId
        {
            get
            {
                return this.lastNormalBattleZoneId;
            }
            set
            {
                this.lastNormalBattleZoneId = value;
            }
        }

        public long LastResetDungeonTime
        {
            get
            {
                return this.lastResetDungeonTime;
            }
            set
            {
                this.lastResetDungeonTime = value;
            }
        }

        public int LastSecretBattleDungeonId
        {
            get
            {
                return this.lastSecretBattleDungeonId;
            }
            set
            {
                this.lastSecretBattleDungeonId = value;
            }
        }

        public int LastSecretBattleZoneId
        {
            get
            {
                return this.lastSecretBattleZoneId;
            }
            set
            {
                this.lastSecretBattleZoneId = value;
            }
        }

        public Dictionary<int, int> LocalRecordDiffTab
        {
            get
            {
                return this.localRecordDiffTab;
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

        public Dictionary<int, Zone> Zones
        {
            get
            {
                return this.zones;
            }
        }
    }
}

