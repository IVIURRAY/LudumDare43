using UnityEngine.PostProcessing;
using UnityEngine;

public class PickupLSD : Pickupable {

	private PostProcessingProfile postProcessing;

	// Use this for initialization
	void Start () {
		postProcessing = FindObjectOfType<PostProcessingBehaviour>().profile;
		postProcessing.motionBlur.enabled = false;
	}

	// Update is called once per frame
	void Update () {
		
	}

	public override void Run()
	{
		Debug.Log("Im LSD");

		postProcessing.motionBlur.enabled = true; // .settings.frameBlending

	}

}
