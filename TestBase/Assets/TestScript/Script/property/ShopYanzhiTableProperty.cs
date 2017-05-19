using System.Collections.Generic; 
 public class ShopYanzhiTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<ShopYanzhiTableObject> ShopYanzhiTable{ get; set;}
}
public class ShopYanzhiTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public int openLevel{ get; set;}
	 public int itemFirstType{ get; set;}
	 public int type{ get; set;}
	 public int value{ get; set;}
	 public int num{ get; set;}
	 public int buy_type{ get; set;}
	 public int buy_value{ get; set;}
	 public int buy_num{ get; set;}
	 public int rate{ get; set;}
	 public int recommend{ get; set;}
	 public int effect{ get; set;}
}
