using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Cannon : MonoBehaviour, PlayerInputActionSetting.ICannonActions, IInteractable
{
	[SerializeField] private PlayerInputActionSetting _inputActions;
	[SerializeField] private float _angleWeight;
	[SerializeField] private float _power;

	private Rigidbody _target;
	private float rotZ;

	private void Awake()
	{
		_inputActions = new PlayerInputActionSetting();
		_inputActions.Cannon.SetCallbacks(this);
	}

	public void OnAngle(InputAction.CallbackContext context)
	{
		if (context.performed)
		{
			rotZ += context.ReadValue<float>() * _angleWeight;
		}
	}

	public void OnShoot(InputAction.CallbackContext context)
	{
		if (context.performed)
		{
			Vector3 dir = Quaternion.Euler(rotZ, 0, 0) * Vector3.up;
			dir = dir.normalized;
			_target.AddForce(dir*_power, ForceMode.Impulse);
			_inputActions.Cannon.Disable();
			_target.gameObject.GetComponent<PlayerController>().EnableInput();
			_target.gameObject.GetComponent<UnitMovement>().LoseControl();
		}
	}

	public void ShowInformation()
	{
		UIInteractable ui = UIManager.Instance.OpenUI<UIInteractable>();
		ui.Init("대포", "F키를 눌러 탑승하세요");
	}

	public void Interact()
	{
		_target = GameManager.Instance.Player.GetComponent<Rigidbody>();
		_target.GetComponent<PlayerController>().DisableInput();
		_target.transform.position = this.transform.position;
		_inputActions.Cannon.Enable();
	}

	public void CloseInformation()
	{
		UIManager.Instance.CloseUI<UIInteractable>();
	}
}
