using System.Collections.Generic; 
 public class RebelBossServerTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<RebelBossServerTableObject> RebelBossServerTable{ get; set;}
}
public class RebelBossServerTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public string desc{ get; set;}
	 public int boss_level{ get; set;}
	 public int rewards_type{ get; set;}
	 public int rewards_value{ get; set;}
	 public int rewards_num{ get; set;}
}
