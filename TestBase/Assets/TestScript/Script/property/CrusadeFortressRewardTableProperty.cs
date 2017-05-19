using System.Collections.Generic; 
 public class CrusadeFortressRewardTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<CrusadeFortressRewardTableObject> CrusadeFortressRewardTable{ get; set;}
}
public class CrusadeFortressRewardTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public int fortress_id{ get; set;}
	 public int min_lv{ get; set;}
	 public int max_lv{ get; set;}
	 public int reward_interval{ get; set;}
	 public int reward{ get; set;}
}
