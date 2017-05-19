using System.Collections.Generic; 
 public class MailTempleteTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<MailTempleteTableObject> MailTempleteTable{ get; set;}
}
public class MailTempleteTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public string tips{ get; set;}
	 public int type{ get; set;}
	 public int system{ get; set;}
	 public string title{ get; set;}
	 public string desc{ get; set;}
	 public int label{ get; set;}
}
