using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour {

	// Use this for initialization
	void Start()
	{
		StartCoroutine("Restart");
	}

	IEnumerator Restart()
	{
		yield return new WaitForSeconds(2f);
		SceneManager.LoadScene(0);
	}
	

}
