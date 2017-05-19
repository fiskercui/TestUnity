using System.Collections.Generic; 
 public class GallantQualityTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<GallantQualityTableObject> GallantQualityTable{ get; set;}
}
public class GallantQualityTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public string name{ get; set;}
	 public string icon{ get; set;}
	 public int compound_num{ get; set;}
	 public int decompose_num{ get; set;}
}
