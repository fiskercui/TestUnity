using System.Collections.Generic; 
 public class RoleAudioTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<RoleAudioTableObject> RoleAudioTable{ get; set;}
}
public class RoleAudioTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public string desc{ get; set;}
	 public int idle1{ get; set;}
	 public int idle2{ get; set;}
	 public int getnew{ get; set;}
	 public int ultimate{ get; set;}
	 public int punch{ get; set;}
	 public int persuit{ get; set;}
}
