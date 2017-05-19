using System.Collections.Generic; 
 public class LegionSkillTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<LegionSkillTableObject> LegionSkillTable{ get; set;}
}
public class LegionSkillTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public int level{ get; set;}
	 public int open_level{ get; set;}
	 public int type{ get; set;}
	 public int value{ get; set;}
	 public int exp{ get; set;}
	 public int learn_type{ get; set;}
	 public int learn_value{ get; set;}
	 public string icon{ get; set;}
	 public string name{ get; set;}
}
