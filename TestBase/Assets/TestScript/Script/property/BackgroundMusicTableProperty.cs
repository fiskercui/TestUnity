using System.Collections.Generic; 
 public class BackgroundMusicTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<BackgroundMusicTableObject> BackgroundMusicTable{ get; set;}
}
public class BackgroundMusicTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public string desc{ get; set;}
	 public int music{ get; set;}
	 public int volume{ get; set;}
}
