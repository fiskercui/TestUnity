using System.Collections.Generic; 
 public class FragmentTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<FragmentTableObject> FragmentTable{ get; set;}
}
public class FragmentTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public string name{ get; set;}
	 public string desc{ get; set;}
	 public string icon{ get; set;}
	 public int quality{ get; set;}
	 public int fragment_type{ get; set;}
	 public int fragment_value{ get; set;}
	 public int max_num{ get; set;}
	 public int sale_type{ get; set;}
	 public int sale_value{ get; set;}
	 public string description{ get; set;}
	 public int is_drop{ get; set;}
	 public int gm{ get; set;}
	 public int slacklen{ get; set;}
}
