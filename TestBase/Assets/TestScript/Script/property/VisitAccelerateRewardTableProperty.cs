using System.Collections.Generic; 
 public class VisitAccelerateRewardTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<VisitAccelerateRewardTableObject> VisitAccelerateRewardTable{ get; set;}
}
public class VisitAccelerateRewardTableObject{
	 public AttributeInfo @attributes;
	 public int level{ get; set;}
	 public int type1{ get; set;}
	 public int id1{ get; set;}
	 public int chance1{ get; set;}
	 public int num1{ get; set;}
	 public int type2{ get; set;}
	 public int id2{ get; set;}
	 public int chance2{ get; set;}
	 public int num2{ get; set;}
}
