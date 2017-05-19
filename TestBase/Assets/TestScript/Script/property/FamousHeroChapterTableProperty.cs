using System.Collections.Generic; 
 public class FamousHeroChapterTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<FamousHeroChapterTableObject> FamousHeroChapterTable{ get; set;}
}
public class FamousHeroChapterTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public string name{ get; set;}
	 public int chapterType{ get; set;}
	 public int prevId{ get; set;}
	 public int preStoryId{ get; set;}
	 public int lvLimit{ get; set;}
	 public int isOnce{ get; set;}
	 public string stageId{ get; set;}
	 public int chest1DropId{ get; set;}
	 public string icon{ get; set;}
	 public int mapId{ get; set;}
	 public string biography{ get; set;}
	 public string jueju{ get; set;}
	 public int chest1_pos{ get; set;}
	 public int chapternum{ get; set;}
}
