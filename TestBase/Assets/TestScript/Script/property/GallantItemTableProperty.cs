using System.Collections.Generic; 
 public class GallantItemTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<GallantItemTableObject> GallantItemTable{ get; set;}
}
public class GallantItemTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public string name{ get; set;}
	 public string icon{ get; set;}
	 public int quality{ get; set;}
	 public string desc{ get; set;}
	 public int stack{ get; set;}
	 public int can_decompose{ get; set;}
	 public int can_drop{ get; set;}
	 public int can_extract{ get; set;}
	 public int can_buy{ get; set;}
	 public int can_compound{ get; set;}
	 public int resID{ get; set;}
}
