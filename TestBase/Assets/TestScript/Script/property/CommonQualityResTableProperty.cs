using System.Collections.Generic; 
 public class CommonQualityResTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<CommonQualityResTableObject> CommonQualityResTable{ get; set;}
}
public class CommonQualityResTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public string name{ get; set;}
	 public int type{ get; set;}
	 public string img_frame{ get; set;}
	 public string img_bg{ get; set;}
}
