using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgMover : MonoBehaviour {

	// Use this for initialization
	public float velocity;
	
	// Update is called once per frame
	void Update () {
		this.transform.position=new Vector3(this.transform.position.x+velocity,this.transform.position.y,this.transform.position.z);
		if (this.transform.position.x < -35.51||Time.timeScale==0)
		{
			velocity = 0;
		}
	}
}
