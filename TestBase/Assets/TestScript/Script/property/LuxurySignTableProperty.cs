using System.Collections.Generic; 
 public class LuxurySignTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<LuxurySignTableObject> LuxurySignTable{ get; set;}
}
public class LuxurySignTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public int app_id{ get; set;}
	 public int channel_id{ get; set;}
	 public int day{ get; set;}
	 public int size{ get; set;}
	 public int item_type1{ get; set;}
	 public int item_id1{ get; set;}
	 public int item_num1{ get; set;}
	 public int item_type2{ get; set;}
	 public int item_id2{ get; set;}
	 public int item_num2{ get; set;}
	 public int item_type3{ get; set;}
	 public int item_id3{ get; set;}
	 public int item_num3{ get; set;}
	 public int item_type4{ get; set;}
	 public int item_id4{ get; set;}
	 public int item_num4{ get; set;}
	 public int item_type5{ get; set;}
	 public int item_id5{ get; set;}
	 public int item_num5{ get; set;}
}
