using System.Collections.Generic; 
 public class YuanFenTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<YuanFenTableObject> YuanFenTable{ get; set;}
}
public class YuanFenTableObject{
	 public AttributeInfo @attributes;
	 public int YuanFenID{ get; set;}
	 public string name{ get; set;}
	 public string desc{ get; set;}
	 public int YuanFenType{ get; set;}
	 public int Effect1{ get; set;}
	 public int Effect2{ get; set;}
	 public int ActiveID1{ get; set;}
	 public int ActiveID2{ get; set;}
	 public int ActiveID3{ get; set;}
	 public int ActiveID4{ get; set;}
	 public int ActiveID5{ get; set;}
}
