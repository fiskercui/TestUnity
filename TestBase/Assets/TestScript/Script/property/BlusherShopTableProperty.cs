using System.Collections.Generic; 
 public class BlusherShopTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<BlusherShopTableObject> BlusherShopTable{ get; set;}
}
public class BlusherShopTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public int lv{ get; set;}
	 public int type{ get; set;}
	 public int itemType{ get; set;}
	 public int itemId{ get; set;}
	 public int itemNum{ get; set;}
	 public int currencyType{ get; set;}
	 public int currencyId{ get; set;}
	 public int needNum{ get; set;}
	 public int prob{ get; set;}
	 public int recommend{ get; set;}
	 public int valid{ get; set;}
}
