using System.Collections.Generic; 
 public class HeroCultureTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<HeroCultureTableObject> HeroCultureTable{ get; set;}
}
public class HeroCultureTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public int startLv{ get; set;}
	 public int endLv{ get; set;}
	 public int dstLv{ get; set;}
	 public int addRatio{ get; set;}
	 public int phyAttackLmt{ get; set;}
	 public int magicAttackLmt{ get; set;}
	 public int hpLimit{ get; set;}
	 public int phyDefenseLmt{ get; set;}
	 public int magicDefenseLmt{ get; set;}
	 public int incProb{ get; set;}
	 public int constProb{ get; set;}
	 public int decProb{ get; set;}
}
