using UnityEngine;

public class PlayerLook : MonoBehaviour
{
	[SerializeField] private Transform _camContainer;
	[SerializeField] private float _lookXSensitivity;
	[SerializeField] private float _lookYSensitivity;
	[SerializeField] private float minXLook;
	[SerializeField] private float maxXLook;

	[SerializeField] private LayerMask layerMask;

	private PlayerController _controller;
	private Vector2 _mouseDelta;
	private float _cameraCurrentXRot;

	private bool _isLookInteractableObject = false;
	private IInteractable _tempInteractable = null;



	private void Awake()
	{
		_controller = GetComponent<PlayerController>();
	}
	private void Start()
	{
		_controller.Looking += Look;
		_controller.OnInteractionEvent += Interact;
	}

	private void Interact()
	{
		_tempInteractable.Interact();
	}

	private void Update()
	{
		DetectInteractObject();
	}

	private void LateUpdate()
	{
		PlayerRotate();
		CameraRotate();
	}
	public void Look(Vector2 delta)
	{
		_mouseDelta = delta;
	}
	private void PlayerRotate()
	{
		transform.eulerAngles += new Vector3(0, _mouseDelta.x * _lookYSensitivity, 0);
	}
	private void CameraRotate()
	{
		_cameraCurrentXRot += _mouseDelta.y * _lookXSensitivity;
		_cameraCurrentXRot = Mathf.Clamp(_cameraCurrentXRot, -minXLook, -maxXLook);
		_camContainer.eulerAngles = new Vector3(-_cameraCurrentXRot, transform.eulerAngles.y, _camContainer.eulerAngles.z);
	}
	public void DetectInteractObject()
	{
		Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);
		Ray ray = Camera.main.ScreenPointToRay(screenCenter);
		Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward);
		if (Physics.Raycast(ray, out RaycastHit hit, 10f, layerMask))
		{
			if (!_isLookInteractableObject)
			{
				_isLookInteractableObject = true;
				_tempInteractable = hit.collider.gameObject.GetComponentInParent<IInteractable>();
				_tempInteractable.ShowInformation();
			}
		}
		else
		{
			if (_isLookInteractableObject)
			{
				_isLookInteractableObject = false;
				_tempInteractable.CloseInformation();
			}
		}
	}

}
