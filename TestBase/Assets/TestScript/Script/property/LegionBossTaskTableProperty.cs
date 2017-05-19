using System.Collections.Generic; 
 public class LegionBossTaskTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<LegionBossTaskTableObject> LegionBossTaskTable{ get; set;}
}
public class LegionBossTaskTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public int type{ get; set;}
	 public int reward{ get; set;}
}
