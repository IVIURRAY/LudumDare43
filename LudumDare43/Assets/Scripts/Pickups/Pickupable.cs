using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupable : MonoBehaviour {

	private Dictionary<string, Pickupable> pickupScripts = new Dictionary<string, Pickupable>();
	public GameObject player;

	private void Awake()
	{
		// Get a ref to the player
		player = GameObject.FindWithTag("Player");

		// Populate the pickup scripts dict
		PickupTourch p_touch = (PickupTourch)FindObjectOfType(typeof(PickupTourch));
		pickupScripts.Add("Tourch", p_touch);
		PickupTHC p_THC = (PickupTHC)FindObjectOfType(typeof(PickupTHC));
		pickupScripts.Add("THC", p_THC);
		PickupCoke p_Coke = (PickupCoke)FindObjectOfType(typeof(PickupCoke));
		pickupScripts.Add("Coke", p_Coke);
	}


	public void Pickup(string name)
	{
		Pickupable pickupScript = pickupScripts[name];
		pickupScript.Run();
	}

	public virtual void Run()
	{
		Debug.Log("You need to override Run. In base class.");
	}

}
