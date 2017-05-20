using System;
using System.Collections.Generic;

public class AvatarScroll :Avatar
{
	private int amount;
	public int Amount
	{
		get { return amount; }
		set { amount = value; }
	}

	public AvatarScroll()
	{
		this.Guid = "";
	}
}
