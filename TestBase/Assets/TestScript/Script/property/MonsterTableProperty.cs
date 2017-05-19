using System.Collections.Generic; 
 public class MonsterTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<MonsterTableObject> MonsterTable{ get; set;}
}
public class MonsterTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public string name{ get; set;}
	 public int bossid{ get; set;}
	 public int image_id{ get; set;}
	 public int skill_audio_id{ get; set;}
	 public int dead_audio_id{ get; set;}
	 public int play_group_id{ get; set;}
	 public int quality{ get; set;}
	 public int attack_type{ get; set;}
	 public int hp{ get; set;}
	 public int attack{ get; set;}
	 public int magicAttack{ get; set;}
	 public int defense{ get; set;}
	 public int magic_defense{ get; set;}
	 public int hit{ get; set;}
	 public int dodge{ get; set;}
	 public int crit{ get; set;}
	 public int kang_bao{ get; set;}
	 public int add_hurt{ get; set;}
	 public int dec_hurt{ get; set;}
	 public int anger{ get; set;}
	 public int anger_reset{ get; set;}
	 public int attack_id{ get; set;}
	 public int skill_id{ get; set;}
	 public int total_skill_id{ get; set;}
	 public int immune_dec_anger{ get; set;}
	 public int immune_vertigo{ get; set;}
}
