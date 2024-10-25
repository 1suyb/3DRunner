using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
	private ItemDataDB _itemDB;
	public ItemDataDB ItemDB => _itemDB;

	private void Awake()
	{
		_itemDB = ResourceManager.Load<ItemDataDB>("Data/ItemDataDB");
	}
}
