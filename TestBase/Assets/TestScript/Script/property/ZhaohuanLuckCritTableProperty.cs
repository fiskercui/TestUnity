using System.Collections.Generic; 
 public class ZhaohuanLuckCritTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<ZhaohuanLuckCritTableObject> ZhaohuanLuckCritTable{ get; set;}
}
public class ZhaohuanLuckCritTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public int type{ get; set;}
	 public int luck{ get; set;}
	 public int probability{ get; set;}
	 public int critType{ get; set;}
}
