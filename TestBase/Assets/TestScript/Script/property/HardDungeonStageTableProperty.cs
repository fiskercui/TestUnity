using System.Collections.Generic; 
 public class HardDungeonStageTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<HardDungeonStageTableObject> HardDungeonStageTable{ get; set;}
}
public class HardDungeonStageTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public string name{ get; set;}
	 public int cost{ get; set;}
	 public int time_limit{ get; set;}
	 public string monster_team_id{ get; set;}
	 public int win_type{ get; set;}
	 public int star1_type{ get; set;}
	 public int star2_type{ get; set;}
	 public int star3_type{ get; set;}
	 public string reward_drop_id{ get; set;}
	 public string desc{ get; set;}
	 public string icon{ get; set;}
	 public int color{ get; set;}
	 public string map_id{ get; set;}
	 public int pos{ get; set;}
	 public int plot_enum_1{ get; set;}
	 public int plot_id_1{ get; set;}
	 public int plot_enum_2{ get; set;}
	 public int plot_id_2{ get; set;}
}
