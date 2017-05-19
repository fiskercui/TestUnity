using System.Collections.Generic; 
 public class CrusadeMissionRewardTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<CrusadeMissionRewardTableObject> CrusadeMissionRewardTable{ get; set;}
}
public class CrusadeMissionRewardTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public int gate{ get; set;}
	 public int level_start{ get; set;}
	 public int level_end{ get; set;}
	 public int reward1{ get; set;}
	 public int reward2{ get; set;}
	 public int reward3{ get; set;}
	 public string item_list{ get; set;}
	 public string item_prop{ get; set;}
}
