using System.Collections.Generic; 
 public class PlotTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<PlotTableObject> PlotTable{ get; set;}
}
public class PlotTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public int index{ get; set;}
	 public int module{ get; set;}
	 public string arg1{ get; set;}
	 public string arg2{ get; set;}
	 public string arg3{ get; set;}
	 public string arg4{ get; set;}
	 public string arg5{ get; set;}
	 public string name{ get; set;}
	 public int frameType{ get; set;}
	 public int trans_type{ get; set;}
	 public int relation{ get; set;}
	 public int trans_form{ get; set;}
	 public int trans_arg{ get; set;}
	 public string imgbg{ get; set;}
	 public int can_repeat{ get; set;}
}
