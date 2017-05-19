using System.Collections.Generic; 
 public class CrusadeMissionFightNumTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<CrusadeMissionFightNumTableObject> CrusadeMissionFightNumTable{ get; set;}
}
public class CrusadeMissionFightNumTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public int type{ get; set;}
	 public int num{ get; set;}
	 public int moneyType{ get; set;}
	 public string addVipNum{ get; set;}
	 public string cost{ get; set;}
}
