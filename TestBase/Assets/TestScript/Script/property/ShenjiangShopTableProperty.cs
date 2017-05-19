using System.Collections.Generic; 
 public class ShenjiangShopTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<ShenjiangShopTableObject> ShenjiangShopTable{ get; set;}
}
public class ShenjiangShopTableObject{
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
