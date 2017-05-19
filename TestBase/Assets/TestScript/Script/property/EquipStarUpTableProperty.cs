using System.Collections.Generic; 
 public class EquipStarUpTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<EquipStarUpTableObject> EquipStarUpTable{ get; set;}
}
public class EquipStarUpTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public int stars{ get; set;}
	 public int shengJieMa{ get; set;}
	 public int luckValue{ get; set;}
	 public int baseSuccess{ get; set;}
	 public int maxSuccess{ get; set;}
	 public int totalExp{ get; set;}
	 public int baseExpStep1{ get; set;}
	 public int baseExpStep2{ get; set;}
	 public int baseExpStep3{ get; set;}
	 public int criticalProbability1{ get; set;}
	 public int criticalTimes1{ get; set;}
	 public int criticalProbability2{ get; set;}
	 public int criticalTimes2{ get; set;}
	 public int addAttrType{ get; set;}
	 public int addAttrValue1{ get; set;}
	 public int addAttrValue2{ get; set;}
	 public int addAttrValue3{ get; set;}
	 public int extraAddValue{ get; set;}
	 public int addLimit{ get; set;}
	 public int costSilver{ get; set;}
	 public int costGold{ get; set;}
	 public int costFragment{ get; set;}
	 public int fragmentId{ get; set;}
}
