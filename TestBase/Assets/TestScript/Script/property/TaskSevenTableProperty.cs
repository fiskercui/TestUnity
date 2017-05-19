using System.Collections.Generic; 
 public class TaskSevenTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<TaskSevenTableObject> TaskSevenTable{ get; set;}
}
public class TaskSevenTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public string desc{ get; set;}
	 public int tag{ get; set;}
	 public int openTime{ get; set;}
	 public int jmp{ get; set;}
	 public int condType{ get; set;}
	 public int condVal1{ get; set;}
	 public int condVal2{ get; set;}
	 public int progress{ get; set;}
	 public int chipNum{ get; set;}
	 public int itemType1{ get; set;}
	 public int itemId1{ get; set;}
	 public int itemNum1{ get; set;}
	 public int itemType2{ get; set;}
	 public int itemId2{ get; set;}
	 public int itemNum2{ get; set;}
	 public int itemType3{ get; set;}
	 public int itemId3{ get; set;}
	 public int itemNum3{ get; set;}
	 public int itemType4{ get; set;}
	 public int itemId4{ get; set;}
	 public int itemNum4{ get; set;}
	 public int valid{ get; set;}
	 public int weight{ get; set;}
}
