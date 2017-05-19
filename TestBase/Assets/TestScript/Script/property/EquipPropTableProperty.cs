using System.Collections.Generic; 
 public class EquipPropTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<EquipPropTableObject> EquipPropTable{ get; set;}
}
public class EquipPropTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public string name{ get; set;}
	 public string icon{ get; set;}
	 public string icon_big{ get; set;}
	 public int equip_type{ get; set;}
	 public int starlvl{ get; set;}
	 public int quality{ get; set;}
	 public int potentiality{ get; set;}
	 public int wear_level{ get; set;}
	 public int suit_id{ get; set;}
	 public int return_well{ get; set;}
	 public int return_item_id{ get; set;}
	 public int return_item_num{ get; set;}
	 public int strength_type{ get; set;}
	 public int strength_value{ get; set;}
	 public int strength_growth{ get; set;}
	 public int strength_crit{ get; set;}
	 public int strength_money{ get; set;}
	 public int is_sold{ get; set;}
	 public int price_type{ get; set;}
	 public int price{ get; set;}
	 public int refining_type_1{ get; set;}
	 public int refining_value_1{ get; set;}
	 public int refining_growth_1{ get; set;}
	 public int refining_type_2{ get; set;}
	 public int refining_value_2{ get; set;}
	 public int refining_growth_2{ get; set;}
	 public int refining_exp{ get; set;}
	 public string equipment_skill{ get; set;}
	 public int equip_star_id{ get; set;}
	 public int canDrop{ get; set;}
	 public int gm{ get; set;}
	 public int fragment_id{ get; set;}
	 public string descriptions{ get; set;}
}
