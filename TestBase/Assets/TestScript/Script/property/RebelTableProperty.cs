using System.Collections.Generic; 
 public class RebelTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<RebelTableObject> RebelTable{ get; set;}
}
public class RebelTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public string name{ get; set;}
	 public int prob{ get; set;}
	 public int type{ get; set;}
	 public int timelen{ get; set;}
	 public string monsterId{ get; set;}
	 public string discoveryDrop{ get; set;}
	 public string killDrop{ get; set;}
	 public string hurtDrop{ get; set;}
	 public string image{ get; set;}
	 public int quality{ get; set;}
	 public string attackDrop{ get; set;}
}
