using System.Collections.Generic; 
 public class FamousHeroRaidTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<FamousHeroRaidTableObject> FamousHeroRaidTable{ get; set;}
}
public class FamousHeroRaidTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public string name{ get; set;}
	 public int cost{ get; set;}
	 public string monsterTeamId{ get; set;}
	 public int winType{ get; set;}
	 public int firstMoney{ get; set;}
	 public int type1{ get; set;}
	 public int val1{ get; set;}
	 public int num1{ get; set;}
	 public int type2{ get; set;}
	 public int val2{ get; set;}
	 public int num2{ get; set;}
	 public int type3{ get; set;}
	 public int val3{ get; set;}
	 public int num3{ get; set;}
	 public int type4{ get; set;}
	 public int val4{ get; set;}
	 public int num4{ get; set;}
	 public string icon{ get; set;}
	 public int color{ get; set;}
	 public int mapId{ get; set;}
	 public string desc{ get; set;}
	 public int pos{ get; set;}
	 public int dayCount{ get; set;}
}
