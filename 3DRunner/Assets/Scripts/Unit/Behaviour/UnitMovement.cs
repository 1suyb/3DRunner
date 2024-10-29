using UnityEngine;

public class UnitMovement : MonoBehaviour
{
	public enum State
	{
		Walk,
		Run,
		Climb,
		OutofControl
	}
	private UnitStat _stat;
	private State _state;

	public State MoveState
	{
		get { return _state; }
	}



	[SerializeField] private int _jumpSpendStamina;
	[SerializeField] private int _runSpendStamina;

	public int RunSpendStamina => _runSpendStamina;

	private Vector3 _moveDir;
	private PlayerController _controller;
	private Rigidbody _rigidbody;
	private UnitStatHandler _statHandler;

	public bool IsRun => MoveState==State.Run;
	public bool IsClimb => MoveState==State.Climb;
	public bool IsOutofControl => MoveState==State.OutofControl;


	private void Awake()
	{
		_controller = GetComponent<PlayerController>();
		_rigidbody = GetComponent<Rigidbody>();
		_statHandler = GetComponent<UnitStatHandler>();

	}

	private void Start()
	{
		_stat = _statHandler.CurrentStat;
		_controller.Moving += SetMoveDir;
		_controller.Jumping += Jump;
		_controller.Running += Run;
		_controller.StopRunning += StopRun;
		_controller.OnChangeMoveStateEvent += SetMovementState;

	}

	private void FixedUpdate()
	{
		if (!IsOutofControl)
		{
			Move();
		}
		else
		{
			if (transform.IsGround())
			{
				TakeControl();
			}
		}
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
			_rigidbody.velocity = transform.up * (_moveDir.z * _stat.WalkSpeed * 0.5f)
	+ transform.right * (_moveDir.x * _stat.WalkSpeed * 0.5f);
			_rigidbody.useGravity = false;
		}
	}
	private void Move()
	{
		if (IsClimb)
		{
			Climbing();
		}
		else
		{
			_rigidbody.useGravity = true;
			float speed = IsRun && _moveDir.z > 0 ? _stat.RunSpeed : _stat.WalkSpeed;
			_rigidbody.velocity = transform.forward * (_moveDir.z * speed)
				+ transform.right * (_moveDir.x * speed)
				+ (transform.up * _rigidbody.velocity.y);
		}

	}
	private void Jump()
	{
		if (GetComponent<ConditionHandler>().GetStamina.IsRemain(_jumpSpendStamina))
		{
			_rigidbody.AddForce(transform.up * _stat.JumpForce, ForceMode.Impulse);
			GetComponent<ConditionHandler>().GetStamina.Subtract(_jumpSpendStamina);
		}

	}

	public void SetMovementState()
	{
		if (IsContactWall())
		{
			if (IsClimb)
			{
				
				this.transform.position += this.transform.forward * 0.5f +
					this.transform.up * 1.45f;
				_state = State.Walk;
			}
			else
			{
				_state = State.Climb;
				_rigidbody.useGravity = false;
			}
		}
		else
		{
			_state |= State.Walk;
			_rigidbody.useGravity = true;
		}
	}

	private void Run()
	{
		_state = State.Run;
	}
	private void StopRun()
	{
		_state = State.Walk;
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

	public void LoseControl()
	{
		_state = State.OutofControl;
	}
	public void TakeControl()
	{
		_state = State.Walk;
	}

}
