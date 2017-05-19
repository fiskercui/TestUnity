using System.Collections.Generic; 
 public class VipWelfareTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<VipWelfareTableObject> VipWelfareTable{ get; set;}
}
public class VipWelfareTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public int level{ get; set;}
	 public string desc{ get; set;}
	 public string dropId{ get; set;}
}
