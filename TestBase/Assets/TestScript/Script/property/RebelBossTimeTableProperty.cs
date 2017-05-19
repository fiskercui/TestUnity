using System.Collections.Generic; 
 public class RebelBossTimeTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<RebelBossTimeTableObject> RebelBossTimeTable{ get; set;}
}
public class RebelBossTimeTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public int week{ get; set;}
	 public string start_time{ get; set;}
	 public string end_time{ get; set;}
}
