using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpeed : Pickupable
{
	PlayerController controller;

	public float effectDuration = 10f;
	private float originalMoveSpeed;
	private float originalLookSensativity;

	// Use this for initialization
	void Start () {
		
		controller = GameObject.FindObjectOfType<PlayerController>(); 
		originalLookSensativity = controller.lookSensativity;
		originalMoveSpeed = controller.moveSpeed;
	}

	public override void Run()
	{
		controller.moveSpeed = controller.moveSpeed * 4;
		controller.lookSensativity = controller.lookSensativity * 4;

	}

	public override IEnumerator Revert()
	{
		yield return new WaitForSeconds(effectDuration);
		controller.moveSpeed = originalMoveSpeed;
		controller.lookSensativity = originalLookSensativity;
		Destroy(gameObject);
	}
	

}
