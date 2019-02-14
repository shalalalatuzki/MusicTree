using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubbishMover : MonoBehaviour {

	//三种垃圾随机贴图
	public Sprite[] rubbishTextures;
	private int index;
	//下落速度
	public float velocity=0;
	//生命时间
	public int lifetime;
	void Start()
	{
		//产生随机垃圾
		if (Random.Range(0.0f,1.0f) < 0.2)
		{
			index = 0;
		}
		else if(Random.Range(0.0f,1.0f)<0.7)
		{
			index = 1;
		}
		else
		{
			index = 2;
		}
	}

	// Update is called once per frame
	void Update () {
		//垃圾下落动作
		this.transform.position=new Vector3(this.transform.position.x,this.transform.position.y+velocity,
			this.transform.position.z);
		//随机渲染垃圾图片
		this.GetComponent<SpriteRenderer>().sprite = rubbishTextures[index];
		//销毁垃圾
		if (lifetime > 10)
		{
			Destroy(gameObject);
		}
	}

 void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag=="tree")
		{
			//Destroy(other.gameObject);
			Time.timeScale = 0f;
			GetComponent<AudioSource>().Play();
			//游戏结束,添加游戏结束场景和音乐
			/*----------------------------*/
		}
	}
}
