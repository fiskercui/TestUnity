using System.Collections.Generic; 
 public class VisitStationEventTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<VisitStationEventTableObject> VisitStationEventTable{ get; set;}
}
public class VisitStationEventTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public int event_group{ get; set;}
	 public int weight{ get; set;}
	 public int item_type{ get; set;}
	 public int item_id{ get; set;}
	 public int low_item_num{ get; set;}
	 public int mid_item_num{ get; set;}
	 public int high_item_num{ get; set;}
	 public string content{ get; set;}
	 public int display{ get; set;}
}
