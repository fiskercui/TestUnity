using System.Collections.Generic; 
 public class FashionBaseTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<FashionBaseTableObject> FashionBaseTable{ get; set;}
}
public class FashionBaseTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public string name{ get; set;}
	 public int type{ get; set;}
	 public int zhenying{ get; set;}
	 public int pinzhi{ get; set;}
	 public string res_id{ get; set;}
	 public int male_image{ get; set;}
	 public int male_pugong{ get; set;}
	 public int male_skill{ get; set;}
	 public int male_heji{ get; set;}
	 public int male_chaoheji{ get; set;}
	 public int male_jiujiheji{ get; set;}
	 public int male_voice{ get; set;}
	 public string male_bubble{ get; set;}
	 public int female_image{ get; set;}
	 public int female_pugong{ get; set;}
	 public int female_skill{ get; set;}
	 public int female_heji{ get; set;}
	 public int female_chaoheji{ get; set;}
	 public int female_jiujiheji{ get; set;}
	 public int female_voice{ get; set;}
	 public string female_bubble{ get; set;}
	 public int shengJieCode{ get; set;}
	 public int job{ get; set;}
	 public int hurtType{ get; set;}
	 public int open_lv{ get; set;}
	 public int skill_unlock{ get; set;}
	 public int heji_unlock{ get; set;}
	 public int chaoheji_unlock{ get; set;}
	 public int attr_type1{ get; set;}
	 public int attr_value1{ get; set;}
	 public int attr_type2{ get; set;}
	 public int attr_value2{ get; set;}
	 public int strengthen_id{ get; set;}
	 public int consume_id{ get; set;}
	 public string talent_lv{ get; set;}
	 public string talent{ get; set;}
	 public string yuanfen{ get; set;}
	 public string desc{ get; set;}
}
