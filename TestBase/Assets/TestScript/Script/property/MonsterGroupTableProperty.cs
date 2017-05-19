using System.Collections.Generic; 
 public class MonsterGroupTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<MonsterGroupTableObject> MonsterGroupTable{ get; set;}
}
public class MonsterGroupTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public int pos1_monster_id{ get; set;}
	 public int pos2_monster_id{ get; set;}
	 public int pos3_monster_id{ get; set;}
	 public int pos4_monster_id{ get; set;}
	 public int pos5_monster_id{ get; set;}
	 public int pos6_monster_id{ get; set;}
	 public int buff1{ get; set;}
	 public int buff2{ get; set;}
	 public int buff3{ get; set;}
}
