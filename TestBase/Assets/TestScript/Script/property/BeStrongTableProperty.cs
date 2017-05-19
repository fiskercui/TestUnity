using System.Collections.Generic; 
 public class BeStrongTableProperty
{
	public TableHeadInfo TResHeadAll;
	public List<BeStrongTableObject> BeStrongTable{ get; set;}
}
public class BeStrongTableObject{
	 public AttributeInfo @attributes;
	 public int level{ get; set;}
	 public int fullFc{ get; set;}
	 public int recommendFc{ get; set;}
	 public int maxEquipIncrease{ get; set;}
	 public int maxEquipRefining{ get; set;}
	 public int maxEquipStarUp{ get; set;}
	 public int maxCardLevelUp{ get; set;}
	 public int maxCardStepUp{ get; set;}
	 public int maxCardGrow{ get; set;}
	 public int maxCardWake{ get; set;}
	 public int maxCardFate{ get; set;}
	 public int maxTreasureIncrease{ get; set;}
	 public int maxTreasureRefining{ get; set;}
	 public string equipIncWeights{ get; set;}
	 public string equipRefiningWeights{ get; set;}
	 public string equipStarUpWeights{ get; set;}
	 public string cardLevelUpWeights{ get; set;}
	 public string cardStepUpWeights{ get; set;}
	 public string cardGrowWeights{ get; set;}
	 public string cardWakeWeights{ get; set;}
	 public string cardFateWeights{ get; set;}
	 public string treasureIncWeights{ get; set;}
	 public string treasureRefiningWeights{ get; set;}
}
