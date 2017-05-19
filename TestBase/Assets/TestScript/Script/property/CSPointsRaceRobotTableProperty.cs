using System.Collections.Generic; 
 public class CSPointsRaceRobotTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<CSPointsRaceRobotTableObject> CSPointsRaceRobotTable{ get; set;}
}
public class CSPointsRaceRobotTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public int robot_id{ get; set;}
	 public int points{ get; set;}
}
