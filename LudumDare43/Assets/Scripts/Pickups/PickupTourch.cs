using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupTourch : Pickupable {

	GameObject tourch;

	// Use this for initialization
	void Start () {
		tourch = GameObject.FindWithTag("TourchModel");
		tourch.GetComponent<Light>().enabled = false;
	}
	
	public override void Run()
	{
		Debug.Log("i am tourch");

		tourch.GetComponent<MeshRenderer>().enabled = true;
		tourch.GetComponent<Light>().enabled = true;		
		Destroy(gameObject);
	}
}
