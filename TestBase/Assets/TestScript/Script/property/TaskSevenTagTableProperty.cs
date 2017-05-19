using System.Collections.Generic; 
 public class TaskSevenTagTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<TaskSevenTagTableObject> TaskSevenTagTable{ get; set;}
}
public class TaskSevenTagTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public int tag{ get; set;}
	 public string content{ get; set;}
	 public int opentime{ get; set;}
}
