using System.Collections.Generic; 
 public class ResSceneProperty
{
	public TableHeadInfo TResHeadAll;
	public List<ResSceneObject> ResScene{ get; set;}
}
public class ResSceneObject{
	 public AttributeInfo @attributes;
	 public int sceneID{ get; set;}
	 public int sceneType{ get; set;}
	 public string scenePic{ get; set;}
	 public string skin{ get; set;}
	 public string skeleton{ get; set;}
	 public string action{ get; set;}
	 public int times{ get; set;}
	 public string stagePos{ get; set;}
	 public string boxPos{ get; set;}
	 public string range{ get; set;}
	 public int sceneEffect{ get; set;}
	 public string upEffects{ get; set;}
	 public string downEffects{ get; set;}
}
