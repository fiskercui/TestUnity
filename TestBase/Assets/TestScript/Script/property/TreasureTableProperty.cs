using System.Collections.Generic; 
 public class TreasureTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<TreasureTableObject> TreasureTable{ get; set;}
}
public class TreasureTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public string name{ get; set;}
	 public int type{ get; set;}
	 public int potentiality{ get; set;}
	 public int openLevel{ get; set;}
	 public int quality{ get; set;}
	 public int dressLevel{ get; set;}
	 public int canGrow{ get; set;}
	 public int resident{ get; set;}
	 public int fragmentId{ get; set;}
	 public string skills{ get; set;}
	 public int forgeTreasure{ get; set;}
	 public int strengthenType1{ get; set;}
	 public int strengthenValue1{ get; set;}
	 public int strengthenGrow1{ get; set;}
	 public int strengthenType2{ get; set;}
	 public int strengthenValue2{ get; set;}
	 public int strengthenGrow2{ get; set;}
	 public int baseCostExp{ get; set;}
	 public int growCostExp{ get; set;}
	 public int offerExp{ get; set;}
	 public int refiningType1{ get; set;}
	 public int refiningValue1{ get; set;}
	 public int refiningGrow1{ get; set;}
	 public int refiningType2{ get; set;}
	 public int refiningValue2{ get; set;}
	 public int refiningGrow2{ get; set;}
	 public string icon{ get; set;}
	 public string desc{ get; set;}
	 public int gm{ get; set;}
	 public int canSell{ get; set;}
	 public int sellType{ get; set;}
	 public int sellValue{ get; set;}
}
