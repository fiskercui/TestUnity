using System.Collections.Generic; 
 public class TreasureRefiningTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<TreasureRefiningTableObject> TreasureRefiningTable{ get; set;}
}
public class TreasureRefiningTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public int level{ get; set;}
	 public int costType1{ get; set;}
	 public int costValue1{ get; set;}
	 public int costNum1{ get; set;}
	 public int costType2{ get; set;}
	 public int costValue2{ get; set;}
	 public int costNum2{ get; set;}
	 public int costType3{ get; set;}
	 public int costValue3{ get; set;}
	 public int costNum3{ get; set;}
	 public int returnSilver{ get; set;}
	 public int returnStone{ get; set;}
	 public int returnTreasure{ get; set;}
}
