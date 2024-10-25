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
		return Instantiate(Load<GameObject>($"Prefabs/{path}"), parent);
	}

	public static GameObject Instantiate(GameObject gameObject, Transform parent=null)
	{
		return GameObject.Instantiate<GameObject>(gameObject, parent);
	}

	public static T[] LoadAll<T> (string path) where T : Object
	{
		return Resources.LoadAll<T>($"Prefabs/{path}");
	}

	public static GameObject[] InstantiateAll(string path, Transform parent = null)
	{
		GameObject[] sources = LoadAll<GameObject>(path);
		GameObject[] objects = new GameObject[sources.Length];
		for(int i = 0; i < sources.Length; i++)
		{
			objects[i] = Instantiate(sources[i], parent);
		}
		return objects;
	}

}
