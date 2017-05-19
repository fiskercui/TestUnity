using System.Collections.Generic; 
 public class SkillTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<SkillTableObject> SkillTable{ get; set;}
}
public class SkillTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public string name{ get; set;}
	 public string desc{ get; set;}
	 public int skill_type{ get; set;}
	 public int max_level{ get; set;}
	 public int is_unite{ get; set;}
	 public string unite_hero_id{ get; set;}
	 public int skill_acc{ get; set;}
	 public int skill_crit{ get; set;}
	 public int effect_1_type{ get; set;}
	 public int effect_1_target{ get; set;}
	 public int effect_1_prob{ get; set;}
	 public int effect_1_formula{ get; set;}
	 public int effect_1_value_1{ get; set;}
	 public int effecet_1_value_1_growth{ get; set;}
	 public int effect_1_value_2{ get; set;}
	 public int effect_1_value_2_growth{ get; set;}
	 public int effect_2_type{ get; set;}
	 public int effect_2_target{ get; set;}
	 public int effect_2_prob{ get; set;}
	 public int effect_2_formula{ get; set;}
	 public int effect_2_value_1{ get; set;}
	 public int effecet_2_value_1_growth{ get; set;}
	 public int effect_2_value_2{ get; set;}
	 public int effect_2_value_2_growth{ get; set;}
	 public int buff_1_id{ get; set;}
	 public int buff_1_target{ get; set;}
	 public int buff_1_prob{ get; set;}
	 public int buff_1_duration{ get; set;}
	 public int buff_2_id{ get; set;}
	 public int buff_2_target{ get; set;}
	 public int buff_2_prob{ get; set;}
	 public int buff_2_duration{ get; set;}
	 public int buff_3_id{ get; set;}
	 public int buff_3_target{ get; set;}
	 public int buff_3_prob{ get; set;}
	 public int buff_3_duration{ get; set;}
	 public int rage_type{ get; set;}
	 public int rage_value{ get; set;}
	 public string start_sound{ get; set;}
	 public string hit_sound{ get; set;}
	 public string attackaction{ get; set;}
	 public int attackcount{ get; set;}
	 public int playgroup{ get; set;}
	 public string text_id{ get; set;}
	 public string dialog_text{ get; set;}
	 public string dialog_frame{ get; set;}
	 public int dialog_voice{ get; set;}
}
