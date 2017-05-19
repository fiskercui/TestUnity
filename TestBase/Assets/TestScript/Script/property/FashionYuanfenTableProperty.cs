using System.Collections.Generic; 
 public class FashionYuanfenTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<FashionYuanfenTableObject> FashionYuanfenTable{ get; set;}
}
public class FashionYuanfenTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public string name{ get; set;}
	 public int fashion1{ get; set;}
	 public int fashion2{ get; set;}
	 public int fashion3{ get; set;}
	 public int attr_type1{ get; set;}
	 public int attr_value1{ get; set;}
	 public int attr_type2{ get; set;}
	 public int attr_value2{ get; set;}
	 public int attr_type3{ get; set;}
	 public int attr_value3{ get; set;}
	 public int attr_type4{ get; set;}
	 public int attr_value4{ get; set;}
}
