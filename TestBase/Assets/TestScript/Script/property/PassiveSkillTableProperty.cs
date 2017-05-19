using System.Collections.Generic; 
 public class PassiveSkillTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<PassiveSkillTableObject> PassiveSkillTable{ get; set;}
}
public class PassiveSkillTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public string name{ get; set;}
	 public int type{ get; set;}
	 public int value{ get; set;}
	 public int target{ get; set;}
	 public string desc{ get; set;}
	 public int type2{ get; set;}
	 public int value2{ get; set;}
}
