using System.Collections.Generic; 
 public class ErrorMsgTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<ErrorMsgTableObject> ErrorMsgTable{ get; set;}
}
public class ErrorMsgTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public string error_msg{ get; set;}
}
