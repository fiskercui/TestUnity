using System.Collections.Generic; 
 public class OpenSrvRankActivityTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<OpenSrvRankActivityTableObject> OpenSrvRankActivityTable{ get; set;}
}
public class OpenSrvRankActivityTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public int type{ get; set;}
	 public int rank{ get; set;}
	 public int min_value{ get; set;}
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
	 public int rank_end{ get; set;}
}
