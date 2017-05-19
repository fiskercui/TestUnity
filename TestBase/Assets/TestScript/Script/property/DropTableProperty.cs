using System.Collections.Generic; 
 public class DropTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<DropTableObject> DropTable{ get; set;}
}
public class DropTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public int cfg_id{ get; set;}
	 public int group_id{ get; set;}
	 public string desc{ get; set;}
	 public int type{ get; set;}
	 public int weight{ get; set;}
	 public int item_type{ get; set;}
	 public int item_id{ get; set;}
	 public int min_num{ get; set;}
	 public int max_num{ get; set;}
}
