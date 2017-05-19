using System.Collections.Generic; 
 public class ArenaDialogueTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<ArenaDialogueTableObject> ArenaDialogueTable{ get; set;}
}
public class ArenaDialogueTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public string content{ get; set;}
	 public int position{ get; set;}
}
