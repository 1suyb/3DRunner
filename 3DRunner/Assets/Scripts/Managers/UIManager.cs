using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
	private int sort = 0;
	public GameObject OpenUI(string path)
	{
		GameObject go =  ResourceManager.Instantiate($"UI/{path}");
		SetCanvas(go);	
		return go;
	}
	public void SetCanvas(GameObject go)
	{
		Canvas canvas = go.GetComponent<Canvas>();
		canvas.sortingOrder = sort++;
	}
}
