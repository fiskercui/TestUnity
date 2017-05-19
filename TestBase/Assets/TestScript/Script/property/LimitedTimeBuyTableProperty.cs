using System.Collections.Generic; 
 public class LimitedTimeBuyTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<LimitedTimeBuyTableObject> LimitedTimeBuyTable{ get; set;}
}
public class LimitedTimeBuyTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public int cond{ get; set;}
	 public int cond_val1{ get; set;}
	 public int cond_val2{ get; set;}
	 public int min_level{ get; set;}
	 public int max_level{ get; set;}
	 public int buy_cd{ get; set;}
	 public int buy_type{ get; set;}
	 public int buy_type_val{ get; set;}
}
