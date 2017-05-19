using System.Collections.Generic; 
 public class VipLevelTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<VipLevelTableObject> VipLevelTable{ get; set;}
}
public class VipLevelTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public int level{ get; set;}
	 public int lvExp{ get; set;}
	 public string privilege{ get; set;}
	 public string icon{ get; set;}
	 public string name{ get; set;}
	 public string desc{ get; set;}
	 public int saleGiftId{ get; set;}
}
