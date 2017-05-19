using System.Collections.Generic; 
 public class ResHejiProperty
{
	public TableHeadInfo TResHeadAll;
	public List<ResHejiObject> ResHeji{ get; set;}
}
public class ResHejiObject{
	 public AttributeInfo @attributes;
	 public int playID{ get; set;}
	 public int skillid{ get; set;}
	 public string name{ get; set;}
	 public string background_skin{ get; set;}
	 public string background_skel{ get; set;}
	 public string background_action{ get; set;}
	 public string virtual_acition_skin{ get; set;}
	 public string virtual_acition_skel{ get; set;}
	 public string virtual_acition_action{ get; set;}
	 public string middle_skin{ get; set;}
	 public string middle_skel{ get; set;}
	 public string middle_action{ get; set;}
	 public string lizi_skin{ get; set;}
	 public string lizi_skel{ get; set;}
	 public string lizi_action{ get; set;}
	 public string text_skin{ get; set;}
	 public string text_skel{ get; set;}
	 public string text_action{ get; set;}
	 public string user1{ get; set;}
	 public string user2{ get; set;}
	 public string action1{ get; set;}
	 public string action2{ get; set;}
	 public int play1{ get; set;}
	 public int play2{ get; set;}
	 public string user1_pic{ get; set;}
	 public string user2_pic{ get; set;}
	 public string environment_effect_skin{ get; set;}
	 public string environment_effect_skel{ get; set;}
	 public int start_time{ get; set;}
	 public int end_time{ get; set;}
	 public string weapon_effect{ get; set;}
	 public string weapon_dir{ get; set;}
	 public string weapon_velocity{ get; set;}
	 public int voice{ get; set;}
}
