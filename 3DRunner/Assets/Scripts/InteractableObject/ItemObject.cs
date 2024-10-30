using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour, IInteractable
{
	[SerializeField] private int _id;

	private ItemData _itemData;
	private UIItemInteractPopup _popupUI;

	private void Start()
	{
		_itemData = DataManager.Instance.ItemDB[_id];
	}

	public List<string> GetItemInfoString()
	{
		List<string> info = new List<string>();
		info.Add(_itemData.Name);
		info.Add(_itemData.Description);
		info.Add(_itemData.Type.ToString());
		info.Add(_itemData.Health.ToString());
		info.Add(_itemData.Hunger.ToString());
		info.Add(_itemData.Stamina.ToString());
		info.Add(_itemData.MaxHealth.ToString());
		info.Add(_itemData.MaxHealth.ToString());
		info.Add(_itemData.MaxStamina.ToString());
		info.Add(_itemData.WalkSpeed.ToString());
		info.Add(_itemData.RunSpeed.ToString());
		info.Add(_itemData.JumpForce.ToString());
		info.Add(_itemData.Duration.ToString());

		return info;
	}

	public void Use()
	{
		Player player = GameManager.Instance.Player;
		player.GetComponent<IRecoverable>().Recovery(_itemData.Health);
		player.GetComponent<ConditionHandler>().GetHunger.Add(_itemData.Hunger);
		player.GetComponent<ConditionHandler>().GetStamina.Add(_itemData.Stamina);
		UnitStat stat = new UnitStatBuilder()
			.Type((StatsChangeType)_itemData.Type)
			.Health(_itemData.MaxHealth)
			.Hunger(_itemData.MaxHunger)
			.Stamina(_itemData.MaxStamina)
			.WalkSpeed(_itemData.WalkSpeed)
			.RunSpeed(_itemData.RunSpeed)
			.JumpForce(_itemData.JumpForce)
			.Build();
		player.GetComponent<UnitStatHandler>().AddStatModifier(stat, _itemData.Duration);
	}

    public void ShowInformation()
    {
		_popupUI = UIManager.Instance.OpenUI<UIItemInteractPopup>();
		_popupUI.Init(GetItemInfoString());
    }
	public void Interact()
	{
		Use();
	}

	public void CloseInformation()
	{
		UIManager.Instance.CloseUI(_popupUI.gameObject);
	}
}
