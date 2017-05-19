using System.Collections.Generic; 
 public class RaidVictoryStarTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<RaidVictoryStarTableObject> RaidVictoryStarTable{ get; set;}
}
public class RaidVictoryStarTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public int cond{ get; set;}
	 public int val{ get; set;}
}
