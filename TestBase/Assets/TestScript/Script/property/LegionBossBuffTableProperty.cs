using System.Collections.Generic; 
 public class LegionBossBuffTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<LegionBossBuffTableObject> LegionBossBuffTable{ get; set;}
}
public class LegionBossBuffTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public int type{ get; set;}
	 public int value{ get; set;}
	 public int buff_id{ get; set;}
}
