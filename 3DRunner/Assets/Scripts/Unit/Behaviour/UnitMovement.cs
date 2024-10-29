using UnityEngine;

public class UnitMovement : MonoBehaviour
{
	private float _runSpeed;
	private float _walkSpeed;
	private float _jump;

	[SerializeField] private int _jumpSpendStamina;
	[SerializeField] private int _runSpendStamina;

	public int RunSpendStamina => _runSpendStamina;

	private Vector3 _moveDir;
	private PlayerController _controller;
	private Rigidbody _rigidbody;
	private UnitStatHandler _statHandler;
	private bool _isRun;
	private bool _isClimbing;

	public bool IsRun => _isRun;


	private void Awake()
	{
		_controller = GetComponent<PlayerController>();
		_rigidbody = GetComponent<Rigidbody>();
		_statHandler = GetComponent<UnitStatHandler>();
	}

	private void Start()
	{
		_controller.Moving += SetMoveDir;
		_controller.Jumping += Jump;
		_controller.Running += Run;
		_controller.StopRunning += StopRun;
		_controller.OnChangeMoveStateEvent += SetMovementState;
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
	private void Climbing()
	{
		if (!IsEndWall())
		{
			_rigidbody.velocity = Vector3.zero;
		}
		else
		{
			_rigidbody.velocity = transform.up * (_moveDir.z * _walkSpeed * 0.5f)
	+ transform.right * (_moveDir.x * _walkSpeed * 0.5f);
			_rigidbody.useGravity = false;
		}
	}
	private void Move()
	{
		if (_isClimbing)
		{
			Climbing();
		}
		else
		{
			_rigidbody.useGravity = true;
			float speed = _isRun && _moveDir.z > 0 ? _runSpeed : _walkSpeed;
			_rigidbody.velocity = transform.forward * (_moveDir.z * speed)
				+ transform.right * (_moveDir.x * speed)
				+ (transform.up * _rigidbody.velocity.y);
		}

	}
	private void Jump()
	{
		if (GetComponent<ConditionHandler>().GetStamina.IsRemain(_jumpSpendStamina))
		{
			_rigidbody.AddForce(transform.up * _jump, ForceMode.Impulse);
			GetComponent<ConditionHandler>().GetStamina.Subtract(_jumpSpendStamina);
		}

	}

	public void SetMovementState()
	{
		if (IsContactWall())
		{
			if (_isClimbing)
			{
				_isClimbing = false;
				this.transform.position += this.transform.forward * 0.5f +
					this.transform.up * 1.45f;
			}
			else
			{
				_isClimbing = true;
			}
		}
	}

	private void Run()
	{
		_isRun = true;
	}
	private void StopRun()
	{
		_isRun = false;
	}

	private bool IsEndWall()
	{
		Ray ray = new Ray(transform.position + new Vector3(0, 1.5f, 0), transform.forward);
		if (Physics.Raycast(ray, 0.25f, 1 << 10))
		{
			return true;
		}
		return false;
	}

	private bool IsContactWall()
	{
		Ray ray = new Ray(transform.position + new Vector3(0, 1.4f, 0), transform.forward);
		if (Physics.Raycast(ray, 0.25f, 1 << 10))
		{
			return true;
		}
		return false;
	}

}
