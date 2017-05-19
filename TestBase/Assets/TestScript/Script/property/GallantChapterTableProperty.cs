using System.Collections.Generic; 
 public class GallantChapterTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<GallantChapterTableObject> GallantChapterTable{ get; set;}
}
public class GallantChapterTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public string chapter{ get; set;}
	 public string name{ get; set;}
	 public int image{ get; set;}
	 public int open_main_raid{ get; set;}
	 public int open_level{ get; set;}
	 public int type_1{ get; set;}
	 public int value_1{ get; set;}
	 public int type_2{ get; set;}
	 public int value_2{ get; set;}
	 public int type_3{ get; set;}
	 public int value_3{ get; set;}
	 public int type_4{ get; set;}
	 public int value_4{ get; set;}
}
