using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupTHC : Pickupable
{
	public float slowdownFactor = 0.05f;
	public float slowdownLength = 5f;
	
	// Update is called once per frame
	void Update () {
		Time.timeScale += (1f / slowdownLength) * Time.unscaledDeltaTime;
		Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
	}

	public override void Run()
	{
		Debug.Log("Im a THC");

		// Slow down time
		Time.timeScale = slowdownFactor;
		Time.fixedDeltaTime = Time.timeScale * 0.02f;
	}
}
