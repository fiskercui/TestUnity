using System.Collections.Generic; 
 public class BlusherMainTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<BlusherMainTableObject> BlusherMainTable{ get; set;}
}
public class BlusherMainTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public int group{ get; set;}
	 public string name{ get; set;}
	 public int type{ get; set;}
	 public string desc{ get; set;}
	 public int mainCond{ get; set;}
	 public int mainCondParam{ get; set;}
	 public int subCond{ get; set;}
	 public string subCondParam{ get; set;}
	 public int subCondShow{ get; set;}
	 public int lv{ get; set;}
	 public int upExp{ get; set;}
	 public int cost{ get; set;}
	 public int addExp{ get; set;}
	 public int dropId1{ get; set;}
	 public int dropId2{ get; set;}
	 public int dropId3{ get; set;}
	 public int dropId4{ get; set;}
	 public int dropId5{ get; set;}
	 public int attrid{ get; set;}
	 public int attrval{ get; set;}
	 public int rewardId{ get; set;}
	 public int rewardItemType1{ get; set;}
	 public int rewardItemId1{ get; set;}
	 public int rewardItemNum1{ get; set;}
	 public int rewardItemType2{ get; set;}
	 public int rewardItemId2{ get; set;}
	 public int rewardItemNum2{ get; set;}
	 public int rewardItemType3{ get; set;}
	 public int rewardItemId3{ get; set;}
	 public int rewardItemNum3{ get; set;}
	 public int rewardItemType4{ get; set;}
	 public int rewardItemId4{ get; set;}
	 public int rewardItemNum4{ get; set;}
	 public int luckProb{ get; set;}
	 public string luckGroup{ get; set;}
	 public int critProb{ get; set;}
	 public string critGroup{ get; set;}
	 public int maxCritProb{ get; set;}
	 public string maxCritGroup{ get; set;}
	 public string artGroup{ get; set;}
	 public string audioGroup{ get; set;}
	 public string mainAudioMsg{ get; set;}
	 public string subAudioMsg{ get; set;}
	 public int nextId{ get; set;}
	 public string strHead{ get; set;}
	 public string strDesc{ get; set;}
	 public int quyueLimit{ get; set;}
}
