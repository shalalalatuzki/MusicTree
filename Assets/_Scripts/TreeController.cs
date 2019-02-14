using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using  SonicBloom.Koreo;
using UnityEngine.UI;

//限制树的移动范围
[System.Serializable]//在属性面板显示
public class Boundary
{
	public float xMin, XMax;
}

public class TreeController : MonoBehaviour {

	// Update is called once per frame
	//根据音乐跳动
	[EventID]
	public string eventID;
	public float jumpSpeed;
	public float jumpHeight;
	

	//private Rigidbody2D treeJump; 
	//树移动的步长
	public float step = 10;
	//限制树的移动范围
	
	public Boundary boundary;

 void Start()
	{
		Koreographer.Instance.RegisterForEvents(eventID, AddImpulse);
		//treeJump = GetComponent<Rigidbody2D>();
	}

	void AddImpulse(KoreographyEvent evt)
	{			
	//	this.transform.position=new Vector3(this.transform.position.x,
	//		this.transform.position.y+Mathf.Sin(jumpSpeed)*jumpHeight,this.transform.position.z);
		//jumpSpeed *=Mathf.Deg2Rad;
		this.transform.localScale =new Vector3(this.transform.localScale.x,
			this.transform.localScale.y+Mathf.Sin(jumpSpeed) * jumpHeight,
		this.transform.localScale.z);
		jumpSpeed += jumpSpeed;
		if (jumpSpeed > 10000000)
		{
			jumpSpeed = 1;
		}
		print(Mathf.Sin(jumpSpeed) * jumpHeight);
	}
	void OnDestroy()
	{
		//防止不小心删除音乐监听事件，如果删除保存并使用删除之前的
		if (Koreographer.Instance != null)
		{
			Koreographer.Instance.UnregisterForAllEvents(this);
		}
	}
	void Update () {
		//左右键或“A”、“D”键控制树左右运动
		//向左
		if (Input.GetKey(KeyCode.A)||Input.GetKey 	(KeyCode.LeftArrow))
		{
			this.transform.Translate(Vector3.left*step);
			//不超过左边界
			if (this.transform.position.x < boundary.xMin)
			{
				this.transform.position = new Vector3(boundary.xMin,this.transform.position.y,this.transform.position.z);
			}
		}
		//向右
		if (Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.RightArrow))
		{
			this.transform.Translate(Vector3.right*step);
			//不超过右边界
			if (this.transform.position.x >boundary.XMax)
			{
				this.transform.position = new Vector3(boundary.XMax,this.transform.position.y,this.transform.position.z);
			}
		}

		if (Time.timeScale == 0)
		{
			step = 0;
		}
	}
}
