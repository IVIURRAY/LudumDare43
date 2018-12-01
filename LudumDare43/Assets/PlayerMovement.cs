using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour {

	private Vector3 velocity = Vector3.zero;

	private Rigidbody rb;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	// Gets the movement vector
	public void Move(Vector3 inputVelocity)
	{
		velocity = inputVelocity;
	}

	// Run every physics iteration
	private void FixedUpdate()
	{
		PerformMovement();
	}

	private void PerformMovement()
	{
		if (velocity != Vector3.zero)
		{
			rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
		}
	}

}
