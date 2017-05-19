using System.Collections.Generic; 
 public class VipWeekPackConfigProperty
{
	public TableHeadInfo TResHeadAll;
	public List<VipWeekPackConfigObject> VipWeekPackConfig{ get; set;}
}
public class VipWeekPackConfigObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public string desc{ get; set;}
	 public int level{ get; set;}
	 public string taskId{ get; set;}
	 public string image{ get; set;}
	 public int cycle{ get; set;}
}
