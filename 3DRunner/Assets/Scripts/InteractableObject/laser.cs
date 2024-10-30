using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour
{
	[SerializeField] private GameObject _springBoard;
	private Ray _ray;
	private bool _isActivated;

	private void Awake()
	{
		_ray = new Ray(this.transform.position,this.transform.forward);
		StartCoroutine(DetectCoroutine());
	}
	private void Detect()
	{
		if (Physics.Raycast(_ray, 10f, 1 << 6))
		{
			_springBoard.SetActive(true);
			_isActivated = true;
		}
	}
	private IEnumerator DetectCoroutine()
	{
		while (!_isActivated)
		{
			Detect();
			yield return new WaitForFixedUpdate();
		}
	}
}
