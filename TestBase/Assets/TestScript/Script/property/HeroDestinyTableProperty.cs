using System.Collections.Generic; 
 public class HeroDestinyTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<HeroDestinyTableObject> HeroDestinyTable{ get; set;}
}
public class HeroDestinyTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public string name{ get; set;}
	 public int addAttack{ get; set;}
	 public int addHp{ get; set;}
	 public int addPhyDefense{ get; set;}
	 public int addMagicDefense{ get; set;}
	 public int upGrow{ get; set;}
	 public int need{ get; set;}
	 public int baseGrow{ get; set;}
	 public int critProb{ get; set;}
	 public int critGrow{ get; set;}
	 public int lProbExp{ get; set;}
	 public int mProbExp{ get; set;}
	 public int hProbExp{ get; set;}
	 public int bestProbExp{ get; set;}
	 public int upExp{ get; set;}
}
