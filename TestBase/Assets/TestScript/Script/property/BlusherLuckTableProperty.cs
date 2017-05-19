using System.Collections.Generic; 
 public class BlusherLuckTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<BlusherLuckTableObject> BlusherLuckTable{ get; set;}
}
public class BlusherLuckTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public string name{ get; set;}
	 public string desc{ get; set;}
	 public int timelen{ get; set;}
	 public int week{ get; set;}
	 public string time{ get; set;}
	 public string openLv{ get; set;}
	 public string openSkill{ get; set;}
	 public int eventType{ get; set;}
	 public int eventParam{ get; set;}
	 public int subEventType{ get; set;}
	 public int subEventParam{ get; set;}
	 public int weight{ get; set;}
	 public int drop{ get; set;}
	 public int artGrop{ get; set;}
	 public string text{ get; set;}
	 public string audio{ get; set;}
}
