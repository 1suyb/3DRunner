using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
	[SerializeField] private int _id;

	private ItemData _itemData;

	private void Start()
	{
		_itemData = DataManager.Instance.ItemDB[_id];
	}

	public List<string> GetItemInfoString()
	{
		List<string> info = new List<string>();
		info.Add(_itemData.Name);
		info.Add(_itemData.Description);
		info.Add(((ItemType)_itemData.Type).ToString());
		info.Add(_itemData.MaxHealth.ToString());
		info.Add(_itemData.MaxHealth.ToString());
		info.Add(_itemData.MaxStamina.ToString());
		info.Add(_itemData.WalkSpeed.ToString());
		info.Add(_itemData.RunSpeed.ToString());
		info.Add(_itemData.JumpForce.ToString());
		info.Add(_itemData.Health.ToString());
		info.Add(_itemData.Hunger.ToString());
		info.Add(_itemData.Stamina.ToString());
		return info;
	}

	public void Use(out UnitStat stat, out int health, out int hunger, out int stamina)
	{
		stat = new UnitStatBuilder()
			.Type((StatsChangeType)_itemData.Type)
			.Health(_itemData.MaxHealth)
			.Hunger(_itemData.MaxHunger)
			.Stamina(_itemData.MaxStamina)
			.WalkSpeed(_itemData.WalkSpeed)
			.RunSpeed(_itemData.RunSpeed)
			.JumpForce(_itemData.JumpForce)
			.Build();
		health = _itemData.Health;
		hunger = _itemData.Hunger;
		stamina = _itemData.Stamina;
	}
}
