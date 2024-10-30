using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using UnityEditor;
using UnityEditor.Rendering;
using UnityEngine;

public enum PopupUIType
{
	Popup,
	MenuPopup,
	OptionPopup,
	InteractiveInfoPopup,
	ItemInfoPopup,
}

public class UIManager : Singleton<UIManager> 
{
	private List<GameObject> _popup = new List<GameObject>();
	private Dictionary<string, GameObject> _cache = new Dictionary<string, GameObject>();

	private List<GameObject> _currentSceneUI = new List<GameObject>();

	private int _sortOrder = 10;

	public T OpenUI<T>(Transform parent = null,bool isPopup=true)
	{
		GameObject ui = null;
		string path = Utils.GetPath<T>();
		if (!_cache.TryGetValue(path, out ui))
		{
			ui = ResourceManager.Instantiate(path, parent);
			_cache.Add(path, ui);
		}
		ui.SetActive(true);
		if(isPopup)
			_popup.Add(ui);
		SetCanvas(ui, isPopup);
		return ui.GetComponent<T>();
	}

	public void CloseUI(GameObject uiObject)
	{
		_popup.Remove(uiObject);
		_sortOrder--;

		uiObject.GetComponent<UI>().Close();	
	}
	public void CloseUI<T>()
	{
		string path = Utils.GetPath<T>();
		CloseUI(_cache[path]);
	}


	public void SetCanvas(GameObject go, bool sorting=true)
	{
		Canvas canvas = go.GetComponent<Canvas>();
		canvas.sortingOrder = sorting ? _sortOrder++ : canvas.sortingOrder;
	}


	public void Clear()
	{
		_popup.Clear();
		_cache.Clear();
		_currentSceneUI.Clear();
	}
}
