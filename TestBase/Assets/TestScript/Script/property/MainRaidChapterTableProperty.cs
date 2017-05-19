using System.Collections.Generic; 
 public class MainRaidChapterTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<MainRaidChapterTableObject> MainRaidChapterTable{ get; set;}
}
public class MainRaidChapterTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public string name{ get; set;}
	 public int pre_id{ get; set;}
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
	 public int chest2_pos{ get; set;}
	 public int chest3_pos{ get; set;}
	 public string chest1_drop_id{ get; set;}
	 public string chest2_drop_id{ get; set;}
	 public string chest3_drop_id{ get; set;}
	 public string icon{ get; set;}
	 public int map_id{ get; set;}
	 public string sub{ get; set;}
	 public int chapternum{ get; set;}
	 public int plot{ get; set;}
	 public int music{ get; set;}
}
