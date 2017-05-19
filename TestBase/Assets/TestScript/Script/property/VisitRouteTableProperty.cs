using System.Collections.Generic; 
 public class VisitRouteTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<VisitRouteTableObject> VisitRouteTable{ get; set;}
}
public class VisitRouteTableObject{
	 public AttributeInfo @attributes;
	 public int id{ get; set;}
	 public string name{ get; set;}
	 public string content{ get; set;}
	 public string icon1{ get; set;}
	 public string icon2{ get; set;}
	 public string icon3{ get; set;}
	 public int power{ get; set;}
	 public int level{ get; set;}
	 public int event_num{ get; set;}
	 public int station_id1{ get; set;}
	 public int station_id2{ get; set;}
	 public int station_id3{ get; set;}
	 public int station_id4{ get; set;}
	 public int event_group{ get; set;}
}
