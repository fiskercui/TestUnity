using System.Collections.Generic; 
 public class GallantChoukaResTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<GallantChoukaResTableObject> GallantChoukaResTable{ get; set;}
}
public class GallantChoukaResTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public string name{ get; set;}
	 public int card_id{ get; set;}
	 public int frame_id{ get; set;}
	 public string board_path{ get; set;}
}
