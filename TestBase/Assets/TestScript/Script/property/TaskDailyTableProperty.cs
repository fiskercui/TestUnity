using System.Collections.Generic; 
 public class TaskDailyTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<TaskDailyTableObject> TaskDailyTable{ get; set;}
}
public class TaskDailyTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public string desc{ get; set;}
	 public int type{ get; set;}
	 public int jmp{ get; set;}
	 public int condType{ get; set;}
	 public int condVal1{ get; set;}
	 public int condVal2{ get; set;}
	 public int progress{ get; set;}
	 public int rewardType{ get; set;}
	 public int rewardId{ get; set;}
	 public int rewardNum{ get; set;}
	 public int score{ get; set;}
	 public int lvLmtLow{ get; set;}
	 public int lvLmtUp{ get; set;}
	 public int valid{ get; set;}
	 public string icon{ get; set;}
}
