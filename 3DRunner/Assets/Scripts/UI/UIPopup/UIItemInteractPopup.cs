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

	[SerializeField] private ItemEffectSlot[] _slots;

	private void Awake()
	{
	}
	public void Init(List<string> itemInfo)
	{
		base.Init(itemInfo[0], itemInfo[1]);
		_slots[0].Init(itemInfo[3]);
		_slots[1].Init(itemInfo[4]);
		_slots[2].Init(itemInfo[5]);

		_slots[3].Init(itemInfo[9]);
		_slots[4].Init(itemInfo[10]);
		_slots[5].Init(itemInfo[12]);
	}

}
