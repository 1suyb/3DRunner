using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class PlayerController : UnitController, PlayerInputActionSetting.IPlayerActions
{
	[SerializeField] private PlayerInputActionSetting _inputActions;

	public event Action OnInteractionEvent;
	public event Action OnChangeMoveStateEvent;

	private bool _firstTabSuccess = false;
	private bool _isRunning = false;

	


	private void Awake()
	{
		_inputActions = new PlayerInputActionSetting();
		_inputActions.Player.SetCallbacks(this);
		_inputActions.Player.Enable();

	}
	public void EnableInput()
	{
		_inputActions.Player.Enable();

	}
	public void DisableInput()
	{
		_inputActions.Player.Disable();

	}


	private void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
	}
	public void ToggleCursor(bool toggle)
	{
		Cursor.lockState = toggle? CursorLockMode.None : CursorLockMode.Locked;
	}

	public void OnInteraction(InputAction.CallbackContext context)
	{
		if(context.performed)
		{
			OnInteractionEvent?.Invoke();
		}
	}

	public void OnJump(InputAction.CallbackContext context)
	{
		if (context.performed)
		{
			if(transform.IsGround())
			{
				OnJumping();
			}
			OnChangeMoveStateEvent?.Invoke();
		}
	}

	public void OnLook(InputAction.CallbackContext context)
	{
		OnLooking(context.ReadValue<Vector2>());
	}

	public void OnMenu(InputAction.CallbackContext context)
	{
		Debug.Log("MenuButton");
	}

	public void OnMove(InputAction.CallbackContext context)
	{
		OnMoveing(context.ReadValue<Vector2>());

		if (context.canceled && _isRunning)
		{
			_firstTabSuccess = false;
			_isRunning = false;
			OnStopRunning();
		}
	}

	public void OnRun(InputAction.CallbackContext context)
	{
		if(context.interaction is MultiTapInteraction)
		{
			if (context.performed)
			{
				_firstTabSuccess = true;
			}
			if (context.canceled)
			{
				if (_firstTabSuccess)
				{
					OnRunning();
					_isRunning = true;
				}
			}
		}
		else
		{
			if (context.performed)
			{
				OnRunning();
			}
			if (context.canceled)
			{
				OnStopRunning();
			}
		}

	}
	
}
