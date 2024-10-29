using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour
{
	public event Action<Vector2> Moving;
	public event Action Jumping;
	public event Action<Vector2> Looking;

	public event Action Running;
	public event Action StopRunning;
	
	public void OnMoveing(Vector2 dir)
	{
		Moving?.Invoke(dir);
	}
	public void OnJumping()
	{
		Jumping?.Invoke();
	}
	public void OnLooking(Vector2 dir)
	{
		Looking?.Invoke(dir);
	}

	public void OnRunning()
	{
		Running?.Invoke();
	}
	public void OnStopRunning()
	{
		StopRunning?.Invoke();
	}
}
