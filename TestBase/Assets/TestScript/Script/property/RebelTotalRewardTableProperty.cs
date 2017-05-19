using System.Collections.Generic; 
 public class RebelTotalRewardTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<RebelTotalRewardTableObject> RebelTotalRewardTable{ get; set;}
}
public class RebelTotalRewardTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public int exploit_type{ get; set;}
	 public int exploit{ get; set;}
	 public int rewards_type{ get; set;}
	 public int rewards_value{ get; set;}
	 public int rewards_num{ get; set;}
}
