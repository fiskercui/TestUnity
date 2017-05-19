using System.Collections.Generic; 
 public class StepPriceTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<StepPriceTableObject> StepPriceTable{ get; set;}
}
public class StepPriceTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public int type{ get; set;}
	 public int buy_cnt{ get; set;}
	 public int buy_type{ get; set;}
	 public int buy_price{ get; set;}
	 public string desc{ get; set;}
}
