using System.Collections.Generic; 
 public class EquipStrengthenMasterTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<EquipStrengthenMasterTableObject> EquipStrengthenMasterTable{ get; set;}
}
public class EquipStrengthenMasterTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public int activeType{ get; set;}
	 public int value{ get; set;}
	 public int addAttrType1{ get; set;}
	 public int addAttrValue1{ get; set;}
	 public int addAttrType2{ get; set;}
	 public int addAttrValue2{ get; set;}
	 public int addAttrType3{ get; set;}
	 public int addAttrValue3{ get; set;}
	 public int addAttrType4{ get; set;}
	 public int addAttrValue4{ get; set;}
}
