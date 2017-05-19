using System.Collections.Generic; 
 public class BuffTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<BuffTableObject> BuffTable{ get; set;}
}
public class BuffTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public string name{ get; set;}
	 public int buff_type{ get; set;}
	 public int buff_subtype{ get; set;}
	 public int buff_effect_type{ get; set;}
	 public int formula{ get; set;}
	 public int value_1{ get; set;}
	 public int value_2{ get; set;}
	 public string res_skel{ get; set;}
	 public string res_skin{ get; set;}
	 public string res_action{ get; set;}
	 public int res_group{ get; set;}
	 public string text_id{ get; set;}
	 public string text_id2{ get; set;}
	 public string text_animation_id{ get; set;}
	 public string desc{ get; set;}
	 public int bufer_perf_type{ get; set;}
	 public int res_anim{ get; set;}
	 public int repeat_code{ get; set;}
}
