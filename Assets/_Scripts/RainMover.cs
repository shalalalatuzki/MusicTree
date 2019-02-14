using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainMover : MonoBehaviour
{
	//下界
	public float lowerBound;
	//rain下落速度
	public float velocity=0;
	//判断是否接到水
//	private  bool getWature;
	// Update is called once per frame
	void Update () {
		//rain 下落
		this.transform.position=new Vector3(this.transform.position.x,this.transform.position.y+velocity,
			this.transform.position.z);
		if (this.transform.position.y<lowerBound)
		{
			//游戏结束
			Time.timeScale = 0f;
			//加载游戏结束画面
			/*-----------------*/
		}
		//print(getWature);
	}
 void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag=="tree")
		{
			Destroy(gameObject);
		}
	}
}
