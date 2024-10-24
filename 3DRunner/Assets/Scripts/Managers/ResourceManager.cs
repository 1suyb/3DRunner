using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager
{
	public static T Load<T> (string path) where T : Object
	{
		return Resources.Load<T>(path);
	}

	public static GameObject Instantiate(string path, Transform parent=null)
	{
		return GameObject.Instantiate(Load<GameObject>($"Prefabs/{path}"), parent);
	}

}
