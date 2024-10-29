using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringBoard : MonoBehaviour
{
	[SerializeField] private float power;
	private void OnCollisionEnter(Collision collision)
	{
		Rigidbody rigidbody = collision.gameObject.GetComponent<Rigidbody>();
		if(rigidbody != null)
		{
			rigidbody.AddForce(rigidbody.gameObject.transform.up * power, ForceMode.Impulse);
		}
	}
}
