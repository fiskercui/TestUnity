using System.Collections.Generic; 
 public class MoneyTreeProperty
{
	public TableHeadInfo TResHeadAll;
	public List<MoneyTreeObject> MoneyTree{ get; set;}
}
public class MoneyTreeObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public int level{ get; set;}
	 public int index{ get; set;}
	 public int award_high{ get; set;}
	 public int award_low{ get; set;}
	 public int award_type{ get; set;}
	 public int award_value{ get; set;}
	 public int award_num{ get; set;}
}
