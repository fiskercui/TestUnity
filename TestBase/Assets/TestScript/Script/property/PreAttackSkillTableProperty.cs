using System.Collections.Generic; 
 public class PreAttackSkillTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<PreAttackSkillTableObject> PreAttackSkillTable{ get; set;}
}
public class PreAttackSkillTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public int cond_type{ get; set;}
	 public int cond_range{ get; set;}
	 public int cond_val1{ get; set;}
	 public int cond_val2{ get; set;}
	 public int skill_id{ get; set;}
}
