using System.Collections.Generic; 
 public class AwakenItemTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<AwakenItemTableObject> AwakenItemTable{ get; set;}
}
public class AwakenItemTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public string name{ get; set;}
	 public string icon{ get; set;}
	 public string desc{ get; set;}
	 public int color{ get; set;}
	 public int stackLen{ get; set;}
	 public int addAttrType1{ get; set;}
	 public int addAttrValue1{ get; set;}
	 public int addAttrType2{ get; set;}
	 public int addAttrValue2{ get; set;}
	 public int addAttrType3{ get; set;}
	 public int addAttrValue3{ get; set;}
	 public int compoundId{ get; set;}
	 public int sellType{ get; set;}
	 public int sellValue{ get; set;}
	 public int canDrop{ get; set;}
	 public int returnNum{ get; set;}
}
