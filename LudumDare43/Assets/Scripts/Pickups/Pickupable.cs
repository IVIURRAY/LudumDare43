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
		PickupLSD p_LSD = (PickupLSD)FindObjectOfType(typeof(PickupLSD));
		pickupScripts.Add("LSD", p_LSD);
	}


	public void Pickup(string name)
	{
		Pickupable pickupScript = pickupScripts[name];
		pickupScript.Run();
		Disapear();
		StartCoroutine("Revert", 3);
	}

	private void Disapear()
	{
		// We can't destory the object yet as the pickups all revert
		// their effects so need to keep them aroud until they're finsihed.
		gameObject.GetComponent<Collider>().enabled = false;
		gameObject.GetComponent<Renderer>().enabled = false;
	}

	public virtual IEnumerator Revert() {
		Debug.Log("You should override these.");
		yield return null;
	}

	public virtual void Run()
	{
		Debug.Log("You need to override Run. In base class.");
	}

}
