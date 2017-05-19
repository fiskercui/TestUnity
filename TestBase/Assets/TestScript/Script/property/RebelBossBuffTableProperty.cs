using System.Collections.Generic; 
 public class RebelBossBuffTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<RebelBossBuffTableObject> RebelBossBuffTable{ get; set;}
}
public class RebelBossBuffTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public string name{ get; set;}
	 public string desc{ get; set;}
	 public string icon{ get; set;}
	 public int skill_id{ get; set;}
}
