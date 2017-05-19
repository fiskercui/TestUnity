using System.Collections.Generic; 
 public class ZhaohuanLuckPackageTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<ZhaohuanLuckPackageTableObject> ZhaohuanLuckPackageTable{ get; set;}
}
public class ZhaohuanLuckPackageTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public int packageId{ get; set;}
	 public int luck{ get; set;}
	 public int dropId{ get; set;}
}
