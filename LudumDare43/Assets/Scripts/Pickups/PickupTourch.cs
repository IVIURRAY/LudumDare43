using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupTourch : Pickupable {

	

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void Run()
	{
		Debug.Log("i am tourch");

		// GameObject tourch = player.transform.Find("TourchModel").gameObject;
		GameObject.FindWithTag("TourchModel").GetComponent<MeshRenderer>().enabled = true;
		
		

		// Debug.Log(tourch);

		Destroy(gameObject);
	}
}
