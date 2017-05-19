using System.Collections.Generic; 
 public class GallantRefreshTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<GallantRefreshTableObject> GallantRefreshTable{ get; set;}
}
public class GallantRefreshTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public int type1{ get; set;}
	 public int id1{ get; set;}
	 public int num1{ get; set;}
	 public int count{ get; set;}
}
