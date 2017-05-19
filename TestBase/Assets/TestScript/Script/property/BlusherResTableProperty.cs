using System.Collections.Generic; 
 public class BlusherResTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<BlusherResTableObject> BlusherResTable{ get; set;}
}
public class BlusherResTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public string name{ get; set;}
	 public string desc{ get; set;}
	 public string icon{ get; set;}
	 public string skin{ get; set;}
	 public string bones{ get; set;}
	 public string area1{ get; set;}
	 public string area2{ get; set;}
	 public string area3{ get; set;}
	 public string action1{ get; set;}
	 public string action2{ get; set;}
	 public string action3{ get; set;}
	 public string idleWords{ get; set;}
	 public string updateWords{ get; set;}
	 public string bigShyWords{ get; set;}
	 public int shyAudio{ get; set;}
	 public int bigShyAudio{ get; set;}
	 public int quyueAudio{ get; set;}
	 public int quyueTenAudio{ get; set;}
	 public int updateAudio{ get; set;}
	 public string text1{ get; set;}
	 public string text2{ get; set;}
	 public string cutSkin{ get; set;}
	 public string cutBones{ get; set;}
	 public string path{ get; set;}
	 public int rate{ get; set;}
	 public string pathAction{ get; set;}
}
