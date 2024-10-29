using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Cannon : MonoBehaviour, PlayerInputActionSetting.ICannonActions
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
			Debug.Log(dir);
			Debug.DrawRay(this.transform.position, _power*dir,Color.red,1f);
			_target.AddForce(dir*_power, ForceMode.Impulse);
			_inputActions.Cannon.Disable();
			_target.gameObject.GetComponent<PlayerController>().EnableInput();
			_target.gameObject.GetComponent<UnitMovement>().LoseControl();
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			_target = collision.gameObject.GetComponent<Rigidbody>();
			_target.gameObject.GetComponent<PlayerController>().DisableInput();
			_inputActions.Cannon.Enable();

		}
	}
}
