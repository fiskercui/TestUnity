using System.Collections.Generic; 
 public class HeroAwakenTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<HeroAwakenTableObject> HeroAwakenTable{ get; set;}
}
public class HeroAwakenTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public int code{ get; set;}
	 public int scala{ get; set;}
	 public int nextScalaLvLmt{ get; set;}
	 public int slot{ get; set;}
	 public int prop1{ get; set;}
	 public int prop2{ get; set;}
	 public int prop3{ get; set;}
	 public int prop4{ get; set;}
	 public int needType1{ get; set;}
	 public int needVal1{ get; set;}
	 public int needNum1{ get; set;}
	 public int needType2{ get; set;}
	 public int needVal2{ get; set;}
	 public int needNum2{ get; set;}
	 public int needSilver{ get; set;}
	 public int talentId{ get; set;}
	 public int showTalentId{ get; set;}
	 public int addAttrType1{ get; set;}
	 public int addAttrVal1{ get; set;}
	 public int addAttrType2{ get; set;}
	 public int addAttrVal2{ get; set;}
	 public int addAttrType3{ get; set;}
	 public int addAttrVal3{ get; set;}
	 public int addAttrType4{ get; set;}
	 public int addAttrVal4{ get; set;}
	 public int nextId{ get; set;}
	 public int returnGodSoul{ get; set;}
	 public int returnSilver{ get; set;}
	 public string title{ get; set;}
	 public string content{ get; set;}
	 public int burst{ get; set;}
}
