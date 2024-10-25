using System.Security;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class PlayerController : UnitController, PlayerInputActionSetting.IPlayerActions
{
	[SerializeField] private PlayerInputActionSetting _inputActions;
	[SerializeField] private LayerMask layerMask;

	private bool _firstTabSuccess = false;
	private bool _isRunning = false;

	private ItemObject _tempItem = null;

	private void Awake()
	{
		_inputActions = new PlayerInputActionSetting();
		_inputActions.Player.SetCallbacks(this);
		_inputActions.Player.Enable();
	}

	private void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
	}

	private void Update()
	{
		DetectInteractObject();
	}

	public void ToggleCursor(bool toggle)
	{
		Cursor.lockState = toggle? CursorLockMode.None : CursorLockMode.Locked;
	}

	public void OnInteraction(InputAction.CallbackContext context)
	{
		Debug.Log("InteractionButton");
	}

	public void OnJump(InputAction.CallbackContext context)
	{
		if(context.performed)
			OnJumping();
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
		if (_isRunning)
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

	public void DetectInteractObject()
	{
		Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);
		Ray ray = Camera.main.ScreenPointToRay(screenCenter);
		Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward);
		if (Physics.Raycast(ray, out RaycastHit hit, 10f, layerMask))
		{
			if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Item"))
			{
				

				if (_tempItem == null)
				{
					Debug.Log(hit.collider.gameObject.name);
					UIItemInteractPopup ui = UIManager.Instance.OpenPopup<UIItemInteractPopup>(PopupUIType.ItemInfoPopup);
					_tempItem = hit.collider.gameObject.GetComponentInParent<ItemObject>();
					Debug.Log(_tempItem);
					ui.Init(_tempItem.GetItemInfoString());
				}
			}
			else
			{
				if (_tempItem != null)
					_tempItem = null;
			}
		}
	}
}
