using System.Collections.Generic; 
 public class HardDungeonChapterTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<HardDungeonChapterTableObject> HardDungeonChapterTable{ get; set;}
}
public class HardDungeonChapterTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public string name{ get; set;}
	 public int pre_hard_id{ get; set;}
	 public int pre_story_id{ get; set;}
	 public int level{ get; set;}
	 public string stage_id{ get; set;}
	 public int total_stars{ get; set;}
	 public int starchest1_stars{ get; set;}
	 public int starchest2_stars{ get; set;}
	 public int starchest3_stars{ get; set;}
	 public string starchest1_drop_id{ get; set;}
	 public string starchest2_drop_id{ get; set;}
	 public string starchest3_drop_id{ get; set;}
	 public int chest1_pos{ get; set;}
	 public string chest1_drop_id{ get; set;}
	 public string icon{ get; set;}
	 public int map_id{ get; set;}
	 public int chapternum{ get; set;}
	 public int plot{ get; set;}
	 public int music{ get; set;}
}
