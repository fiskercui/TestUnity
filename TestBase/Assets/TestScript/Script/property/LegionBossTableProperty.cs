using System.Collections.Generic; 
 public class LegionBossTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<LegionBossTableObject> LegionBossTable{ get; set;}
}
public class LegionBossTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public string boss_name{ get; set;}
	 public int group{ get; set;}
	 public string icon{ get; set;}
	 public int res{ get; set;}
	 public string slogan{ get; set;}
	 public string background{ get; set;}
	 public string stage_skill1{ get; set;}
	 public string stage_skill2{ get; set;}
	 public string stage_skill3{ get; set;}
	 public string stage_skill4{ get; set;}
	 public string stage_skill5{ get; set;}
	 public string stage_skill6{ get; set;}
	 public int reward{ get; set;}
	 public int attack_reward{ get; set;}
}
