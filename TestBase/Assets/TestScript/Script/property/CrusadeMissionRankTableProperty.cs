using System.Collections.Generic; 
 public class CrusadeMissionRankTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<CrusadeMissionRankTableObject> CrusadeMissionRankTable{ get; set;}
}
public class CrusadeMissionRankTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public int type{ get; set;}
	 public int from_rank{ get; set;}
	 public int to_rank{ get; set;}
	 public int reward{ get; set;}
	 public int mail_id{ get; set;}
}
