using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
	public static bool IsGround(this Transform transform)
	{
		Ray ray = new Ray(transform.position + transform.up * 0.1f, Vector3.down);
		if (Physics.Raycast(ray, 
			0.15f, 
			~(1 << LayerMask.NameToLayer("Player") | 1<<LayerMask.NameToLayer("InteractableObject"))))
		{
			return true;
		}
		return false;
	}

	public static string GetPath<T>()
	{
		Type type = typeof(T);
		List<string> pathSegments = new List<string>();

		// 상위 클래스들을 탐색하여 경로를 생성합니다.
		while (type != null && type != typeof(object))
		{
			// MonoBehaviour는 무시합니다.
			if (type == typeof(UnityEngine.MonoBehaviour))
			{
				break;
			}

			// 현재 타입을 경로에 추가합니다.
			pathSegments.Add(type.Name);
			type = type.BaseType;
		}

		// 경로를 상위에서 하위로 구성합니다.
		pathSegments.Reverse();
		return string.Join("/", pathSegments);
	}
}
