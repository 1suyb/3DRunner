using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAnimationController : MonoBehaviour
{
	private Animator _animator;
	private Rigidbody _rigidbody;
	private UnitController _controller;

	private int _isJump = Animator.StringToHash("IsJump");
	private int _jumpType = Animator.StringToHash("JumpType");

	private int _isWalk = Animator.StringToHash("IsWalk");
	private int _walkDir = Animator.StringToHash("WalkDir");

	private int _isRun = Animator.StringToHash("IsRun");

	private void Awake()
	{
		_animator = GetComponentInChildren<Animator>();
		_rigidbody = GetComponent<Rigidbody>();
		_controller = GetComponent<UnitController>();
	}
	private void Start()
	{
		_controller.Jumping += Jumping;
		_controller.Moving += Moving;
		_controller.Running += Run;
		_controller.StopRunning += StopRun;
	}

	private void Jumping()
	{
		_animator.SetTrigger(_isJump);
	}
	private void Moving(Vector2 dir)
	{
		if(dir.y > 0)
		{
			_animator.SetInteger(_walkDir, 1);
		}
		else
		{
			_animator.SetInteger(_walkDir, -1);
		}
		if(dir.magnitude > 0)
		{
			_animator.SetBool(_isWalk, true);
		}
		else
		{
			_animator.SetBool(_isWalk,false);
		}
	}
	private void Run()
	{
		_animator.SetBool(_isRun, true);
	}
	private void StopRun()
	{
		_animator.SetBool(_isRun,false);
	}
}
