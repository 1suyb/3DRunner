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
			~(1 << LayerMask.NameToLayer("Player") | 1<<LayerMask.NameToLayer("NotGround"))))
		{
			return true;
		}
		return false;
	}
}
