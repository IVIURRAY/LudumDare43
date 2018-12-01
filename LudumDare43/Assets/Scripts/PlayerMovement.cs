using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour {

	
	private Vector3 velocity = Vector3.zero;
	private Vector3 rotation = Vector3.zero;
	private Vector3 cameraRotation = Vector3.zero;
	private Camera cam;

	private Rigidbody rb;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
		cam = GetComponentInChildren<Camera>();
	}

	// Gets the movement vector
	public void Move(Vector3 inputVelocity)
	{
		velocity = inputVelocity;
	}

	// Gets the rotation vector
	public void Rotate(Vector3 inputRotation)
	{
		rotation = inputRotation;
	}

	// Gets the camera rotation vector
	public void RotateCamera(Vector3 inputCameraRotation)
	{
		cameraRotation = inputCameraRotation;
	}

	private void FixedUpdate()
	{
		PerformMovement();
		PerformRotation();
	}

	private void PerformMovement()
	{
		if (velocity != Vector3.zero)
		{
			rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
		}
	}

	private void PerformRotation()
	{
		rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
		if (cam != null)
		{
			cam.transform.Rotate(-cameraRotation);
		}
	}

}
