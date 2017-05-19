using System.Collections.Generic; 
 public class CucumberTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<CucumberTableObject> CucumberTable{ get; set;}
}
public class CucumberTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public string time1{ get; set;}
	 public string time2{ get; set;}
	 public int awardpower{ get; set;}
	 public int awardgoldprob{ get; set;}
	 public int awardyuanbao{ get; set;}
	 public string str1{ get; set;}
	 public string str2{ get; set;}
	 public string str3{ get; set;}
}
