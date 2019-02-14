using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameMusicContoller : MonoBehaviour {

	// Use this for initialization
	
	
	// Update is called once per frame
	void Update () {
		if (Time.timeScale == 0)
		{
			GetComponent<AudioSource>().Stop();
		}

		if (!GetComponent<AudioSource>().isPlaying)
		{
			Time.timeScale = 0;
		}
	}
}
