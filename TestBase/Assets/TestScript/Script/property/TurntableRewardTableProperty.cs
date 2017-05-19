using System.Collections.Generic; 
 public class TurntableRewardTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<TurntableRewardTableObject> TurntableRewardTable{ get; set;}
}
public class TurntableRewardTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public int gid{ get; set;}
	 public int item_type{ get; set;}
	 public int item_id{ get; set;}
	 public int item_num{ get; set;}
	 public int weight{ get; set;}
	 public int recommend{ get; set;}
}
