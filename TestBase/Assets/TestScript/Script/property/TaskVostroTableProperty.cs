using System.Collections.Generic; 
 public class TaskVostroTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<TaskVostroTableObject> TaskVostroTable{ get; set;}
}
public class TaskVostroTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public int serial{ get; set;}
	 public string desc{ get; set;}
	 public int prevId{ get; set;}
	 public int isEnd{ get; set;}
	 public int openLv{ get; set;}
	 public int jmp{ get; set;}
	 public int condType{ get; set;}
	 public int condVal1{ get; set;}
	 public int condVal2{ get; set;}
	 public int progress{ get; set;}
	 public int rewardType1{ get; set;}
	 public int rewardId1{ get; set;}
	 public int rewardNum1{ get; set;}
	 public int rewardType2{ get; set;}
	 public int rewardId2{ get; set;}
	 public int rewardNum2{ get; set;}
	 public int rewardType3{ get; set;}
	 public int rewardId3{ get; set;}
	 public int rewardNum3{ get; set;}
	 public int valid{ get; set;}
	 public string icon{ get; set;}
}
