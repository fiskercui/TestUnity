using System.Collections.Generic; 
 public class FashionStrengthenConsumeTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<FashionStrengthenConsumeTableObject> FashionStrengthenConsumeTable{ get; set;}
}
public class FashionStrengthenConsumeTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public int quality{ get; set;}
	 public int level{ get; set;}
	 public int level_limit{ get; set;}
	 public int consume_num{ get; set;}
	 public int type1{ get; set;}
	 public int id1{ get; set;}
	 public int num1{ get; set;}
	 public int type2{ get; set;}
	 public int id2{ get; set;}
	 public int num2{ get; set;}
	 public int type3{ get; set;}
	 public int id3{ get; set;}
	 public int num3{ get; set;}
}
