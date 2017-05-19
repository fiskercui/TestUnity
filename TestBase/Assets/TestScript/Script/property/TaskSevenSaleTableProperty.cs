using System.Collections.Generic; 
 public class TaskSevenSaleTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<TaskSevenSaleTableObject> TaskSevenSaleTable{ get; set;}
}
public class TaskSevenSaleTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public string desc{ get; set;}
	 public int openTime{ get; set;}
	 public int itemType{ get; set;}
	 public int itemId{ get; set;}
	 public int itemNum{ get; set;}
	 public int currencyType{ get; set;}
	 public int originalRrice{ get; set;}
	 public int price{ get; set;}
	 public int limitCnt{ get; set;}
}
