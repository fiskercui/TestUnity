using System.Collections.Generic; 
 public class VisitHeroEventTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<VisitHeroEventTableObject> VisitHeroEventTable{ get; set;}
}
public class VisitHeroEventTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public string name{ get; set;}
	 public int item_id1{ get; set;}
	 public string item_name1{ get; set;}
	 public int low_item_num1{ get; set;}
	 public int mid_item_num1{ get; set;}
	 public int high_item_num1{ get; set;}
	 public string content1{ get; set;}
	 public int item_id2{ get; set;}
	 public string item_name2{ get; set;}
	 public int low_item_num2{ get; set;}
	 public int mid_item_num2{ get; set;}
	 public int high_item_num2{ get; set;}
	 public string content2{ get; set;}
	 public int item_id3{ get; set;}
	 public string item_name3{ get; set;}
	 public int low_item_num3{ get; set;}
	 public int mid_item_num3{ get; set;}
	 public int high_item_num3{ get; set;}
	 public string content3{ get; set;}
}
