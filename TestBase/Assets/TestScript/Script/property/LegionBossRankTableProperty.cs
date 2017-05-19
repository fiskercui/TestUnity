using System.Collections.Generic; 
 public class LegionBossRankTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<LegionBossRankTableObject> LegionBossRankTable{ get; set;}
}
public class LegionBossRankTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public int type{ get; set;}
	 public int rank1{ get; set;}
	 public int rank2{ get; set;}
	 public int reward{ get; set;}
	 public int mail{ get; set;}
}
