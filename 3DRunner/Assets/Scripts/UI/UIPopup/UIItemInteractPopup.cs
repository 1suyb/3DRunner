using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIItemInteractPopup : UIPopup
{
	enum SlotType
	{
		Health = 0,
		Hunger,
		Stamina,
		MaxHealth,
		MaxHunger,
		MaxStamina,
		WalkSpeed,
		RunSpeed,
		JumpForce,
		End,
	}

	private void Awake()
	{
	}
	public void Init(List<string> itemInfo)
	{
		base.Init(itemInfo[0], itemInfo[1]);
	}

}
