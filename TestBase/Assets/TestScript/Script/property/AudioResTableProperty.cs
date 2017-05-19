using System.Collections.Generic; 
 public class AudioResTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<AudioResTableObject> AudioResTable{ get; set;}
}
public class AudioResTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public string name{ get; set;}
	 public string desc{ get; set;}
	 public string path{ get; set;}
	 public int loop{ get; set;}
}
