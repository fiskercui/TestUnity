using System.Collections.Generic; 
 public class RecommendBattleArrayTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<RecommendBattleArrayTableObject> RecommendBattleArrayTable{ get; set;}
}
public class RecommendBattleArrayTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public string name{ get; set;}
	 public string array{ get; set;}
	 public string desc{ get; set;}
	 public int group{ get; set;}
	 public int type{ get; set;}
}
