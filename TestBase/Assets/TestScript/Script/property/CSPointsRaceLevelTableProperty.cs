using System.Collections.Generic; 
 public class CSPointsRaceLevelTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<CSPointsRaceLevelTableObject> CSPointsRaceLevelTable{ get; set;}
}
public class CSPointsRaceLevelTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public string name{ get; set;}
	 public string section_name{ get; set;}
	 public int points_lower_limit{ get; set;}
	 public int rank_type{ get; set;}
	 public int rank_lower_limit{ get; set;}
	 public int icon{ get; set;}
	 public int star{ get; set;}
	 public int win_points{ get; set;}
	 public int lose_points{ get; set;}
	 public int drop_id{ get; set;}
	 public int reset_points{ get; set;}
	 public string skel{ get; set;}
	 public string skin{ get; set;}
}
