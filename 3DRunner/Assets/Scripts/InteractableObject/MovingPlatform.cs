using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
	[SerializeField] private Transform[] _stopPoints;
	[SerializeField] private float _speed;

	private int _targetIndex;
	private Vector3 _targetPosition;
	private Vector3 _dirVec;

	private void Start()
	{
		_targetIndex = 0;
		_targetPosition = _stopPoints[_targetIndex].position;
	}

	private void FixedUpdate()
	{
		Move();
	}

	private void Move()
	{
		transform.position = Vector3.MoveTowards(this.transform.position, _targetPosition, _speed * Time.fixedDeltaTime); ;
		if(Vector3.Distance(transform.position, _targetPosition) < 0.1f)
		{
			_targetIndex = (_targetIndex + 1)%_stopPoints.Length;
			_targetPosition = _stopPoints[_targetIndex].position;
			SetDir();
		}
	}
	private void SetDir()
	{
		_dirVec = _targetPosition - transform.position;
		_dirVec = _dirVec.normalized;
	}
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			collision.transform.parent = transform;
		}
	}

	private void OnCollisionExit(Collision collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			collision.transform.parent = null;
		}
	}

}
