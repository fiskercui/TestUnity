using System.Collections.Generic; 
 public class RebelBossTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<RebelBossTableObject> RebelBossTable{ get; set;}
}
public class RebelBossTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public string name{ get; set;}
	 public string image{ get; set;}
	 public string monster_id_1{ get; set;}
	 public int reward_type{ get; set;}
	 public int reward_id{ get; set;}
	 public int reward_num{ get; set;}
}
