using System.Collections.Generic; 
 public class CSPointsRaceWinAwardTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<CSPointsRaceWinAwardTableObject> CSPointsRaceWinAwardTable{ get; set;}
}
public class CSPointsRaceWinAwardTableObject{
	 public AttributeInfo @attributes;
	 public int win_times{ get; set;}
	 public int award_num{ get; set;}
}
