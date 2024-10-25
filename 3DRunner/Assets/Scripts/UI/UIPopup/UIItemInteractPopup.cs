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
	[SerializeField] private ItemEffectSlot[] _itemEffectSlots;

	public void Init(List<string> itemInfo)
	{
		base.Init(itemInfo[0], itemInfo[1]);
		for(int i = 0; i < (int)SlotType.End; i++)
		{
			_itemEffectSlots[i].Init(itemInfo[i+1]);
		}
	}
}
