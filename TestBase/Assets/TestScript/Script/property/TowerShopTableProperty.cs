using System.Collections.Generic; 
 public class TowerShopTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<TowerShopTableObject> TowerShopTable{ get; set;}
}
public class TowerShopTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public string name{ get; set;}
	 public int rewardType{ get; set;}
	 public int starLimit{ get; set;}
	 public int levelLimit{ get; set;}
	 public int quotaType{ get; set;}
	 public int quotaTime{ get; set;}
	 public int itemType{ get; set;}
	 public int itemId{ get; set;}
	 public int itemNum{ get; set;}
	 public int currency1Type{ get; set;}
	 public int currency1Num{ get; set;}
	 public int currency2Type{ get; set;}
	 public int currency2Num{ get; set;}
	 public string saleTips{ get; set;}
}
