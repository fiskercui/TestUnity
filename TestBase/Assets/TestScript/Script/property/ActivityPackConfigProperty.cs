using System.Collections.Generic; 
 public class ActivityPackConfigProperty
{
	public TableHeadInfo TResHeadAll;
	public List<ActivityPackConfigObject> ActivityPackConfig{ get; set;}
}
public class ActivityPackConfigObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public string name{ get; set;}
	 public int group{ get; set;}
	 public int type{ get; set;}
	 public int sortId{ get; set;}
	 public int open_level{ get; set;}
	 public string start_time{ get; set;}
	 public string end_time{ get; set;}
	 public string tasks{ get; set;}
	 public string image{ get; set;}
	 public string icon{ get; set;}
	 public int cycle{ get; set;}
}
