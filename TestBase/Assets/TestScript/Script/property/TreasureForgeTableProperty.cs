using System.Collections.Generic; 
 public class TreasureForgeTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<TreasureForgeTableObject> TreasureForgeTable{ get; set;}
}
public class TreasureForgeTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public int level{ get; set;}
	 public int gold{ get; set;}
}
