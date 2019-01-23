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
		PickupSlow p_Slow = (PickupSlow)FindObjectOfType(typeof(PickupSlow));
		pickupScripts.Add("Slow", p_Slow);
		PickupSpeed p_Speed = (PickupSpeed)FindObjectOfType(typeof(PickupSpeed));
		pickupScripts.Add("Speed", p_Speed);
		PickupWavey p_Wavey = (PickupWavey)FindObjectOfType(typeof(PickupWavey));
		pickupScripts.Add("Wavey", p_Wavey);
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
