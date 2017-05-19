using System.Collections.Generic; 
 public class CrusadeFortressActivityTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<CrusadeFortressActivityTableObject> CrusadeFortressActivityTable{ get; set;}
}
public class CrusadeFortressActivityTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public int min_lv{ get; set;}
	 public int max_lv{ get; set;}
	 public int progress_limit{ get; set;}
	 public int progress1{ get; set;}
	 public int progress2{ get; set;}
	 public int progress3{ get; set;}
	 public int progress4{ get; set;}
	 public int progress5{ get; set;}
	 public int reward1{ get; set;}
	 public int reward2{ get; set;}
	 public int reward3{ get; set;}
	 public int reward4{ get; set;}
	 public int reward5{ get; set;}
}
