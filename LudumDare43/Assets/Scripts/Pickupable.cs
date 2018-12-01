using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupable : MonoBehaviour {

	public void Pickup()
	{
		Destroy(gameObject);
	}

}
