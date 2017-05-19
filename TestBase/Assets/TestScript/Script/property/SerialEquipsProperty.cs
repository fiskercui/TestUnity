using System.Collections.Generic; 
 public class SerialEquipsProperty
{
	public TableHeadInfo TResHeadAll;
	public List<SerialEquipsObject> SerialEquips{ get; set;}
}
public class SerialEquipsObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public string name{ get; set;}
	 public int equip1{ get; set;}
	 public int equip2{ get; set;}
	 public int equip3{ get; set;}
	 public int equip4{ get; set;}
	 public int pro21{ get; set;}
	 public int val21{ get; set;}
	 public int pro22{ get; set;}
	 public int val22{ get; set;}
	 public int pro31{ get; set;}
	 public int val31{ get; set;}
	 public int pro32{ get; set;}
	 public int val32{ get; set;}
	 public int pro41{ get; set;}
	 public int val41{ get; set;}
	 public int pro42{ get; set;}
	 public int val42{ get; set;}
}
