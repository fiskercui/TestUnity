using System.Collections.Generic; 
 public class DailyFuBenTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<DailyFuBenTableObject> DailyFuBenTable{ get; set;}
}
public class DailyFuBenTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public string name{ get; set;}
	 public int cost{ get; set;}
	 public int color{ get; set;}
	 public int time_limit{ get; set;}
	 public string monster_team_id{ get; set;}
	 public int win_type{ get; set;}
	 public string reward_drop_id{ get; set;}
	 public int map_id{ get; set;}
	 public string music_id{ get; set;}
}
