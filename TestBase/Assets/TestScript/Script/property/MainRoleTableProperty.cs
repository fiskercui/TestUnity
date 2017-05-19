using System.Collections.Generic; 
 public class MainRoleTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<MainRoleTableObject> MainRoleTable{ get; set;}
}
public class MainRoleTableObject{
	 public AttributeInfo @attributes;
	 public int rolelvl{ get; set;}
	 public int expnext{ get; set;}
	 public int zhengrong{ get; set;}
	 public int yuanjun{ get; set;}
	 public int friendcnt{ get; set;}
	 public int shizhuangcnt{ get; set;}
	 public int equiplvlmax{ get; set;}
	 public int petcntclient{ get; set;}
	 public int petcnt{ get; set;}
	 public int bagcntclient{ get; set;}
	 public int bagcnt{ get; set;}
	 public int cardcntclient{ get; set;}
	 public int cardcnt{ get; set;}
	 public int baowucntclient{ get; set;}
	 public int baowucnt{ get; set;}
	 public int gallantcntclient{ get; set;}
	 public int gallantcnt{ get; set;}
	 public int jingliup{ get; set;}
	 public int tiliup{ get; set;}
	 public int panjuntype{ get; set;}
	 public int panjunlvlmin{ get; set;}
	 public int panjunlvlmax{ get; set;}
	 public int panjungxtype{ get; set;}
	 public int pveexp{ get; set;}
	 public int pveyinliang{ get; set;}
	 public int panjunboss{ get; set;}
	 public int pvpexp{ get; set;}
	 public int pvpgold{ get; set;}
	 public int jjccard{ get; set;}
	 public int dbcard{ get; set;}
}
