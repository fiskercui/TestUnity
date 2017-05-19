using System.Collections.Generic; 
 public class VipPrivilegeTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<VipPrivilegeTableObject> VipPrivilegeTable{ get; set;}
}
public class VipPrivilegeTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public string desc{ get; set;}
	 public int type{ get; set;}
	 public int value{ get; set;}
	 public int relation{ get; set;}
	 public int openVipLevel{ get; set;}
	 public int openLevel{ get; set;}
	 public int showVipLevel{ get; set;}
	 public int showLevel{ get; set;}
	 public int upShow{ get; set;}
}
