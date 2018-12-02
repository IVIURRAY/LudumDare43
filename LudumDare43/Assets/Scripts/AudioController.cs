using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {

	public AudioSource outsideAudio;
	public AudioSource insideAudio;

	private void Awake()
	{
		if (FindObjectsOfType<AudioController>().Length > 1)
			Destroy(this.gameObject);

		DontDestroyOnLoad(this.gameObject);
		
	}

	public void ExitHouse()
	{
		insideAudio.Stop();
		Debug.Log("exit house");
		outsideAudio.Play();
	}

	public void EnteredHouse()
	{
		outsideAudio.Stop();
		Debug.Log("entered house");
		insideAudio.Play();
	}

}
