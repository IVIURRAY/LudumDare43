using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsideAudio : MonoBehaviour {

	AudioController music;

	private void Start()
	{
		music = GameObject.FindObjectOfType<AudioController>();
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			Debug.Log("player has entered");
			music.EnteredHouse();
			Destroy(gameObject);
		}
	}

}
