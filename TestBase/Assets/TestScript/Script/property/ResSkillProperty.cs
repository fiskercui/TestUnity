using System.Collections.Generic; 
 public class ResSkillProperty
{
	public TableHeadInfo TResHeadAll;
	public List<ResSkillObject> ResSkill{ get; set;}
}
public class ResSkillObject{
	 public AttributeInfo @attributes;
	 public int effectID{ get; set;}
	 public int effectType{ get; set;}
	 public string name{ get; set;}
	 public int start_pos{ get; set;}
	 public int start_x{ get; set;}
	 public int start_y{ get; set;}
	 public int pos{ get; set;}
	 public int x{ get; set;}
	 public int y{ get; set;}
	 public int mirror{ get; set;}
	 public string skin{ get; set;}
	 public string skel{ get; set;}
	 public string action{ get; set;}
	 public int times{ get; set;}
	 public string terrian_skin{ get; set;}
	 public string terrian_skel{ get; set;}
	 public int terrian_pos{ get; set;}
	 public int terrian_x{ get; set;}
	 public int terrian_y{ get; set;}
	 public int one_show{ get; set;}
	 public string shake_group{ get; set;}
	 public string sound_frame_group{ get; set;}
	 public string sound_group{ get; set;}
	 public string color_frame_group{ get; set;}
	 public string color_group{ get; set;}
	 public string ghost_frame_group{ get; set;}
	 public string ghost_group{ get; set;}
	 public int reverse_x{ get; set;}
	 public int reverse_y{ get; set;}
	 public int origin_dui{ get; set;}
	 public string seq_hurt{ get; set;}
	 public string seq_hurt_hp{ get; set;}
	 public int hurt_action_type{ get; set;}
	 public string hurt_action_args{ get; set;}
	 public int hurt_effect_type{ get; set;}
	 public string flash_args{ get; set;}
	 public string other_args{ get; set;}
}
