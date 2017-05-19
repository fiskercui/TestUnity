using System.Collections.Generic; 
 public class RecommendBattleArrayHeroTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<RecommendBattleArrayHeroTableObject> RecommendBattleArrayHeroTable{ get; set;}
}
public class RecommendBattleArrayHeroTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public string name{ get; set;}
	 public int group{ get; set;}
	 public int quality{ get; set;}
	 public string groupDesc{ get; set;}
	 public string desc{ get; set;}
	 public int type1{ get; set;}
	 public int type2{ get; set;}
	 public int type3{ get; set;}
	 public int type4{ get; set;}
	 public int type5{ get; set;}
	 public int type6{ get; set;}
	 public string getpath{ get; set;}
	 public int resID{ get; set;}
	 public int trainCode{ get; set;}
}
