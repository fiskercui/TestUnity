using System.Collections.Generic; 
 public class AutoRecoverTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<AutoRecoverTableObject> AutoRecoverTable{ get; set;}
}
public class AutoRecoverTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public int type{ get; set;}
	 public int val{ get; set;}
	 public int timelen{ get; set;}
	 public int resetlimit{ get; set;}
	 public int maxlimit{ get; set;}
}
