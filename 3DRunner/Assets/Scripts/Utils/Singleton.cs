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
			Init();
			return _instance;
		}
	}
	private static void Init()
	{
		if (_instance == null)
		{
			_instance = (T)FindObjectOfType(typeof(T));
			if (_instance == null)
			{
				_instance = new GameObject(typeof(T).ToString()).AddComponent<T>();
				
			}
		}
	}
	protected virtual void Awake()
	{
		if (_instance == null)
		{
			_instance = this as T;
			DontDestroyOnLoad(_instance);
		}
	}
}

