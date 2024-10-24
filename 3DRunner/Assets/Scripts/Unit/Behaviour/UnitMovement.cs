using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class UnitMovement : MonoBehaviour
{
	private float _runSpeed;
	private float _walkSpeed;
	private float _jump;

	private Vector3 _moveDir;
	private UnitController _controller;
	private Rigidbody _rigidbody;
	private UnitStatHandler _statHandler;
	private bool _isRun;


	private void Awake()
	{
		_controller = GetComponent<UnitController>();
		_rigidbody = GetComponent<Rigidbody>();
		_statHandler = GetComponent<UnitStatHandler>();
	}

	private void Start()
	{
		_controller.Moving += SetMoveDir;
		_controller.Jumping += Jump;
		_controller.Running += Run;
		_controller.StopRunning += StopRun;
		SetStat(_statHandler.CurrentStat);
		_statHandler.OnchangeStat += SetStat;

	}

	private void FixedUpdate()
	{
		Move();
	}

	public void SetStat(UnitStat stat)
	{
		_runSpeed = stat.RunSpeed;
		_walkSpeed = stat.WalkSpeed;
		_jump = stat.JumpForce;
	}

	public void SetMoveDir(Vector2 moveDir)
	{
		_moveDir = new Vector3(moveDir.x, 0, moveDir.y);
	}

	private void Move()
	{
		float speed = _isRun && _moveDir.z>0 ? _runSpeed : _walkSpeed;
		_rigidbody.velocity = transform.forward * (_moveDir.z * speed)
			+ transform.right * (_moveDir.x * speed)
			+ (transform.up * _rigidbody.velocity.y);
	}
	private void Jump()
	{
		_rigidbody.AddForce(transform.up * _jump, ForceMode.Impulse);
	}

	private void Run()
	{
		_isRun = true;
	}
	private void StopRun()
	{
		_isRun = false;
	}
}
