using System.Collections.Generic; 
 public class LoseFunctionGuideProperty
{
	public TableHeadInfo TResHeadAll;
	public List<LoseFunctionGuideObject> LoseFunctionGuide{ get; set;}
}
public class LoseFunctionGuideObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public int level_low{ get; set;}
	 public int level_high{ get; set;}
	 public int func_type1{ get; set;}
	 public string func_icon1{ get; set;}
	 public int func_type2{ get; set;}
	 public string func_icon2{ get; set;}
	 public int func_type3{ get; set;}
	 public string func_icon3{ get; set;}
}
