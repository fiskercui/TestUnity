using System.Collections.Generic; 
 public class EquipSkillTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<EquipSkillTableObject> EquipSkillTable{ get; set;}
}
public class EquipSkillTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public string name{ get; set;}
	 public int activeType{ get; set;}
	 public int activeValue{ get; set;}
	 public int trigProbability{ get; set;}
	 public int attrType1{ get; set;}
	 public int attrValue1{ get; set;}
	 public int attrType2{ get; set;}
	 public int attrValue2{ get; set;}
	 public int addAttrType{ get; set;}
	 public int addAttrValue{ get; set;}
	 public string desc{ get; set;}
}
