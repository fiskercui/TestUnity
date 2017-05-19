using System.Collections.Generic; 
 public class CrusadeMissionRobotTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<CrusadeMissionRobotTableObject> CrusadeMissionRobotTable{ get; set;}
}
public class CrusadeMissionRobotTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public int gate{ get; set;}
	 public int robot_id{ get; set;}
	 public int fight_power{ get; set;}
}
