using System.Collections.Generic; 
 public class FenjieHeroTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<FenjieHeroTableObject> FenjieHeroTable{ get; set;}
}
public class FenjieHeroTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public int type_param{ get; set;}
	 public int type_value{ get; set;}
	 public int jianghun_num{ get; set;}
	 public int hero_num{ get; set;}
	 public int item_id{ get; set;}
	 public int item_num{ get; set;}
}
