using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
	private ItemDataDB _itemDB;
	public Dictionary<int,ItemData>ItemDB = new Dictionary<int,ItemData>();

	protected override void Awake()
	{
		_itemDB = ResourceManager.Load<ItemDataDB>("Data/ItemDataDB");
		foreach(var item in _itemDB.Data)
		{
			ItemDB.Add(item.ID, item);
		}
	}
}
