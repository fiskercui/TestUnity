using System.Collections.Generic; 
 public class GallantRaidTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<GallantRaidTableObject> GallantRaidTable{ get; set;}
}
public class GallantRaidTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public string name{ get; set;}
	 public int image{ get; set;}
	 public int quality{ get; set;}
	 public string bubble{ get; set;}
	 public int group_id{ get; set;}
	 public int level_lower_bound{ get; set;}
	 public int level_upper_bound{ get; set;}
	 public int weight{ get; set;}
	 public int drop_id{ get; set;}
}
