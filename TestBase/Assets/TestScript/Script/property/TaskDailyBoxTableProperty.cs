using System.Collections.Generic; 
 public class TaskDailyBoxTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<TaskDailyBoxTableObject> TaskDailyBoxTable{ get; set;}
}
public class TaskDailyBoxTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public int score{ get; set;}
	 public int lvLmtLow{ get; set;}
	 public int lvLmtUp{ get; set;}
	 public int type1{ get; set;}
	 public int id1{ get; set;}
	 public int num1{ get; set;}
	 public int type2{ get; set;}
	 public int id2{ get; set;}
	 public int num2{ get; set;}
	 public int type3{ get; set;}
	 public int id3{ get; set;}
	 public int num3{ get; set;}
	 public int type4{ get; set;}
	 public int id4{ get; set;}
	 public int num4{ get; set;}
	 public int valid{ get; set;}
}
