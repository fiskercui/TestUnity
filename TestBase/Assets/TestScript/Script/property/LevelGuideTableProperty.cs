using System.Collections.Generic; 
 public class LevelGuideTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<LevelGuideTableObject> LevelGuideTable{ get; set;}
}
public class LevelGuideTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public int level{ get; set;}
	 public int guide1{ get; set;}
	 public int guide2{ get; set;}
	 public int guide3{ get; set;}
}
