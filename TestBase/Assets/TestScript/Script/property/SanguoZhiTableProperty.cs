using System.Collections.Generic; 
 public class SanguoZhiTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<SanguoZhiTableObject> SanguoZhiTable{ get; set;}
}
public class SanguoZhiTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public string name{ get; set;}
	 public int desc_type{ get; set;}
	 public string desc{ get; set;}
	 public int page{ get; set;}
	 public string icon{ get; set;}
	 public string layout{ get; set;}
	 public int prepose_id{ get; set;}
	 public int cost_num{ get; set;}
	 public int function_type{ get; set;}
	 public int attribute_type{ get; set;}
	 public int attribute_value{ get; set;}
	 public int reward_type{ get; set;}
	 public int type_1{ get; set;}
	 public int value_1{ get; set;}
	 public int size_1{ get; set;}
	 public int type_2{ get; set;}
	 public int value_2{ get; set;}
	 public int size_2{ get; set;}
	 public int type_3{ get; set;}
	 public int value_3{ get; set;}
	 public int size_3{ get; set;}
	 public int type_4{ get; set;}
	 public int value_4{ get; set;}
	 public int size_4{ get; set;}
	 public string image_off{ get; set;}
	 public string image_on{ get; set;}
	 public string text_off{ get; set;}
	 public string text_on{ get; set;}
}
