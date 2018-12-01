using UnityEngine.PostProcessing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupLSD : Pickupable {

	public float effectDuration = 10f;
	private PostProcessingProfile postProcessing;

	// Use this for initialization
	void Start () {
		postProcessing = FindObjectOfType<PostProcessingBehaviour>().profile;
		postProcessing.motionBlur.enabled = false;
	}

	public override void Run()
	{
		Debug.Log("Im LSD");
		postProcessing.motionBlur.enabled = true;
	}

	public override IEnumerator Revert()
	{
		yield return new WaitForSeconds(effectDuration);
		postProcessing.motionBlur.enabled = false;
		Debug.Log("Reverting camera effects.");
		Destroy(gameObject);
	}

}
