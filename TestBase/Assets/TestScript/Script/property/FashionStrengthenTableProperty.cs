using System.Collections.Generic; 
 public class FashionStrengthenTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<FashionStrengthenTableObject> FashionStrengthenTable{ get; set;}
}
public class FashionStrengthenTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public int unlock1{ get; set;}
	 public int attr_type1{ get; set;}
	 public int base_value1{ get; set;}
	 public int value1{ get; set;}
	 public int unlock2{ get; set;}
	 public int attr_type2{ get; set;}
	 public int base_value2{ get; set;}
	 public int value2{ get; set;}
	 public int unlock3{ get; set;}
	 public int attr_type3{ get; set;}
	 public int base_value3{ get; set;}
	 public int value3{ get; set;}
	 public int unlock4{ get; set;}
	 public int attr_type4{ get; set;}
	 public int base_value4{ get; set;}
	 public int value4{ get; set;}
}
