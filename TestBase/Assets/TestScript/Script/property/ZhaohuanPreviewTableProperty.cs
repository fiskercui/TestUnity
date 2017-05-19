using System.Collections.Generic; 
 public class ZhaohuanPreviewTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<ZhaohuanPreviewTableObject> ZhaohuanPreviewTable{ get; set;}
}
public class ZhaohuanPreviewTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public int type{ get; set;}
	 public int cardId{ get; set;}
	 public string desc{ get; set;}
	 public int quality{ get; set;}
	 public string dialog{ get; set;}
}
