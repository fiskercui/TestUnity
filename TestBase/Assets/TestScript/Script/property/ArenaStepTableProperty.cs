using System.Collections.Generic; 
 public class ArenaStepTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<ArenaStepTableObject> ArenaStepTable{ get; set;}
}
public class ArenaStepTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public int limitId{ get; set;}
	 public int type{ get; set;}
	 public int val{ get; set;}
}
