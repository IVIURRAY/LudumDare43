using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupCoke : Pickupable
{

	PlayerController controller;

	private bool IsActive = false;
	private float originalMoveSpeed;
	private float originalLookSensativity;

	// Use this for initialization
	void Start () {
		
		controller = GameObject.FindObjectOfType<PlayerController>(); 
		originalLookSensativity = controller.lookSensativity;
		originalMoveSpeed = controller.moveSpeed;
	}

	private void Update()
	{
		if (IsActive)
		{
			// TODO - slow the player back to noraml after a while.
		}
	}

	public override void Run()
	{
		IsActive = true;
		Debug.Log("Im cocaine.");

		controller.moveSpeed = controller.moveSpeed * 4;
		controller.lookSensativity = controller.lookSensativity * 4;

	}

}
