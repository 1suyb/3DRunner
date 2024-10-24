using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Component
{
	private static T _instance;

	public static T Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = GameObject.FindAnyObjectByType<T>();
				if (_instance == null)
				{
					_instance = new GameObject(typeof(T).Name).AddComponent<T>();
					DontDestroyOnLoad(_instance.gameObject);
				}
			}
			return _instance;
		}
	}
}
