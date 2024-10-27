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
	private Dictionary<PopupUIType, GameObject> _cache = new Dictionary<PopupUIType, GameObject>();

	private List<GameObject> _currentSceneUI = new List<GameObject>();

	private int _sortOrder = 10;

	public T OpenPopup<T>(PopupUIType popupType, Transform parent = null) where T : UIPopup
	{
		GameObject popup = null;
		if (!_cache.TryGetValue(popupType, out popup))
		{
			popup = ResourceManager.Instantiate($"UI/Popup/{popupType.ToString()}", parent);
			_cache.Add(popupType, popup);
		}
		popup.SetActive(true);
		_popup.Add(popup);
		SetCanvas(popup);
		return popup.GetComponent<T>();
	}
	public void ClosePopup(GameObject popup)
	{
		_popup.Remove(popup);
		popup.GetComponent<UI>().Close();	
	}
	public void ClosePopup(PopupUIType popup)
	{
		ClosePopup(_cache[popup]);
	}

	public List<T> OpenScene<T>(SceneName sceneName, Transform parent = null) where T : UI
	{
		List<T> uis = new List<T>();
		GameObject[] sceneUIs =  ResourceManager.InstantiateAll($"{sceneName.ToString()}/UI", parent);
		_currentSceneUI = sceneUIs.ToList<GameObject>();
		Debug.Log(sceneUIs.Length);
		for (int i = 0; i < sceneUIs.Length; i++)
		{
			uis.Add(sceneUIs[i].GetComponent<T>());
		}
		return uis;
	}

	public void SetCanvas(GameObject go)
	{
		Canvas canvas = go.GetComponent<Canvas>();
		canvas.sortingOrder = _sortOrder++;
	}


	public void Clear()
	{
		_popup.Clear();
		_cache.Clear();
		_currentSceneUI.Clear();
	}
}
