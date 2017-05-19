using System.Collections.Generic; 
 public class NewGuideProperty
{
	public TableHeadInfo TResHeadAll;
	public List<NewGuideObject> NewGuide{ get; set;}
}
public class NewGuideObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public int beginmode{ get; set;}
	 public int storyid{ get; set;}
	 public int musicid{ get; set;}
	 public int laterid{ get; set;}
	 public int resetid{ get; set;}
	 public int jumpid{ get; set;}
	 public string pos{ get; set;}
	 public string size{ get; set;}
	 public string viewname{ get; set;}
	 public string buttonname{ get; set;}
	 public string text_pos_x{ get; set;}
	 public string text_pos_y{ get; set;}
	 public string text{ get; set;}
	 public int levelTrigger{ get; set;}
	 public int triggertype1{ get; set;}
	 public int triggervalue1{ get; set;}
	 public int triggertype2{ get; set;}
	 public int triggervalue2{ get; set;}
	 public int delayTime{ get; set;}
	 public int canDrag{ get; set;}
	 public int otherArgs{ get; set;}
	 public int levelJump{ get; set;}
}
