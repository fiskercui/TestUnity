using System.Collections.Generic; 
 public class CrusadeMissionTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<CrusadeMissionTableObject> CrusadeMissionTable{ get; set;}
}
public class CrusadeMissionTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public string name{ get; set;}
	 public int type{ get; set;}
	 public string img{ get; set;}
	 public string pos{ get; set;}
	 public string bg{ get; set;}
	 public int buff_id{ get; set;}
	 public string buff_cost{ get; set;}
	 public string buff_desc{ get; set;}
	 public int fc{ get; set;}
	 public string robot_section{ get; set;}
	 public string arena_section{ get; set;}
	 public int opening_buff{ get; set;}
	 public int takepartin_wudi{ get; set;}
}
