using System.Collections.Generic; 
 public class TowerPropTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<TowerPropTableObject> TowerPropTable{ get; set;}
}
public class TowerPropTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public int minStars{ get; set;}
	 public int maxStars{ get; set;}
	 public int prob{ get; set;}
	 public int itemType{ get; set;}
	 public int itemId{ get; set;}
	 public int itemNum{ get; set;}
	 public int currencyType{ get; set;}
	 public int currencyNum{ get; set;}
	 public int originalPrice{ get; set;}
}
