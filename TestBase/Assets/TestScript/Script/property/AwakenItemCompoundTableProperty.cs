using System.Collections.Generic; 
 public class AwakenItemCompoundTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<AwakenItemCompoundTableObject> AwakenItemCompoundTable{ get; set;}
}
public class AwakenItemCompoundTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public int compoundItem{ get; set;}
	 public string name{ get; set;}
	 public int needItem1{ get; set;}
	 public int needItemNum1{ get; set;}
	 public int needItem2{ get; set;}
	 public int needItemNum2{ get; set;}
	 public int needItem3{ get; set;}
	 public int needItemNum3{ get; set;}
	 public int needItem4{ get; set;}
	 public int needItemNum4{ get; set;}
	 public int cost{ get; set;}
}
