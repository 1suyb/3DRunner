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

		// ���� Ŭ�������� Ž���Ͽ� ��θ� �����մϴ�.
		while (type != null && type != typeof(object))
		{
			// MonoBehaviour�� �����մϴ�.
			if (type == typeof(UnityEngine.MonoBehaviour))
			{
				break;
			}

			// ���� Ÿ���� ��ο� �߰��մϴ�.
			pathSegments.Add(type.Name);
			type = type.BaseType;
		}

		// ��θ� �������� ������ �����մϴ�.
		pathSegments.Reverse();
		return string.Join("/", pathSegments);
	}
}
