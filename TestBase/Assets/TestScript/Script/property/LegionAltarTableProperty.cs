using System.Collections.Generic; 
 public class LegionAltarTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<LegionAltarTableObject> LegionAltarTable{ get; set;}
}
public class LegionAltarTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public string name{ get; set;}
	 public int vip{ get; set;}
	 public int price_type{ get; set;}
	 public int price{ get; set;}
	 public int worship_value{ get; set;}
	 public int corps_integral{ get; set;}
	 public int corps_exp{ get; set;}
	 public int crit_chance{ get; set;}
	 public int crit_multiplier{ get; set;}
}
