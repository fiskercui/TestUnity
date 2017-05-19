using System.Collections.Generic; 
 public class CSPointsRaceKValueTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<CSPointsRaceKValueTableObject> CSPointsRaceKValueTable{ get; set;}
}
public class CSPointsRaceKValueTableObject{
	 public AttributeInfo @attributes;
	 public int points{ get; set;}
	 public int k_value{ get; set;}
}
