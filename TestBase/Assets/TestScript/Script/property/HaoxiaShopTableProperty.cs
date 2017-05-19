using System.Collections.Generic; 
 public class HaoxiaShopTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<HaoxiaShopTableObject> HaoxiaShopTable{ get; set;}
}
public class HaoxiaShopTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public int openLevel{ get; set;}
	 public int itemType{ get; set;}
	 public int itemId{ get; set;}
	 public int itemCount{ get; set;}
	 public int type{ get; set;}
	 public int price{ get; set;}
	 public int rate{ get; set;}
	 public int recommend{ get; set;}
}
