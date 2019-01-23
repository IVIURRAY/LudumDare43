using UnityEngine.PostProcessing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupWavey : Pickupable {

	public float effectDuration = 10f;
	private PostProcessingProfile postProcessing;

	// Use this for initialization
	void Start () {
		postProcessing = FindObjectOfType<PostProcessingBehaviour>().profile;
		postProcessing.motionBlur.enabled = false;
		postProcessing.colorGrading.enabled = true;
	}

	public override void Run()
	{
		postProcessing.motionBlur.enabled = true;
		postProcessing.colorGrading.enabled = false;
	}

	public override IEnumerator Revert()
	{
		yield return new WaitForSeconds(effectDuration);
		postProcessing.motionBlur.enabled = false;
		postProcessing.colorGrading.enabled = true;
		Debug.Log("Reverting camera effects.");
		Destroy(gameObject);
	}

}
