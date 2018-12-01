using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupable : MonoBehaviour {

	private Dictionary<string, Pickupable> pickupScripts = new Dictionary<string, Pickupable>();

	private void Start()
	{
		PickupTourch p_touch = (PickupTourch)FindObjectOfType(typeof(PickupTourch));
		
		pickupScripts.Add("Tourch", p_touch);
		
	}


	public void Pickup(string name)
	{
		Pickupable pickupScript = pickupScripts[name];
		pickupScript.Run();
	}

	public void Run()
	{
		Debug.Log("You need to override Run. In base class.");
	}

}
