using System.Collections.Generic; 
 public class ResGroupProperty
{
	public TableHeadInfo TResHeadAll;
	public List<ResGroupObject> ResGroup{ get; set;}
}
public class ResGroupObject{
	 public AttributeInfo @attributes;
	 public int groupId{ get; set;}
	 public int skillType{ get; set;}
	 public int skillId{ get; set;}
	 public string groupName{ get; set;}
	 public int moveId{ get; set;}
	 public int start_pos{ get; set;}
	 public int start_x{ get; set;}
	 public int start_y{ get; set;}
	 public string event_group{ get; set;}
	 public string effect_group{ get; set;}
	 public string shake_group{ get; set;}
	 public string camera_group{ get; set;}
	 public string flash_frame_group{ get; set;}
	 public string flash_group{ get; set;}
	 public string hurt_percent{ get; set;}
	 public int mount{ get; set;}
	 public string mount_up_skin{ get; set;}
	 public string mount_up_skel{ get; set;}
	 public string mount_up_action{ get; set;}
	 public string mount_skin{ get; set;}
	 public string mount_skel{ get; set;}
	 public string mount_action{ get; set;}
	 public string hide_group{ get; set;}
	 public string aid_group{ get; set;}
	 public string effect{ get; set;}
}
