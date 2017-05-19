using System.Collections.Generic; 
 public class ResRoleProperty
{
	public TableHeadInfo TResHeadAll;
	public List<ResRoleObject> ResRole{ get; set;}
}
public class ResRoleObject{
	 public AttributeInfo @attributes;
	 public int roleID{ get; set;}
	 public string sceneType{ get; set;}
	 public string scenePic{ get; set;}
	 public string skin{ get; set;}
	 public string skeleton{ get; set;}
	 public string role_fashion{ get; set;}
	 public string down_skin{ get; set;}
	 public string down_skeleton{ get; set;}
	 public string down_action{ get; set;}
	 public string down_fashion{ get; set;}
	 public string up_skin{ get; set;}
	 public string up_skeleton{ get; set;}
	 public string up_action{ get; set;}
	 public string up_fashion{ get; set;}
	 public string dou_skin{ get; set;}
	 public string dou_skeleton{ get; set;}
	 public string dou_action{ get; set;}
	 public string action_idle1{ get; set;}
	 public string action_idle2{ get; set;}
	 public string action_attack{ get; set;}
	 public string action_special{ get; set;}
	 public string action_move{ get; set;}
	 public string action_hurt{ get; set;}
	 public string action_evade{ get; set;}
	 public string action_block{ get; set;}
	 public string action_dead{ get; set;}
}
