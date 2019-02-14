using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SonicBloom.Koreo;

public class rainController : MonoBehaviour
{
	//生成rain的个数
	//public int count=10;
	//监听音乐生成水滴
	[EventID]
	public string eventID;
	public int  delayTime = 3;
	//随机位置表
	public float[] positionArray;
	
	public GameObject rainPrefb;

	public Vector3 randomLimit;

	private Vector3  rainPosition=Vector3.zero;

	private Quaternion rainRotation;

	// Use this for initialization
	void RainCreator (KoreographyEvent evt)
	{
			//yield return new WaitForSeconds(delayTime);
			//生成随机索引
			int index = Random.Range(0, positionArray.Length);
			//print(index);
			//print("rain"+positionArray[index]);
			randomLimit.x = positionArray[index];
			rainPosition.x = randomLimit.x;
			rainPosition.y = randomLimit.y;
			rainRotation = Quaternion.identity; //不进行旋转
			Instantiate(rainPrefb, rainPosition, rainRotation);
	}
	// Update is called once per frame
	void Start ()
	{
		Koreographer.Instance.RegisterForEvents(eventID, RainCreator);
	}
	void OnDestroy()
	{
		//防止预设好的koreography不小心被删，保存删之前的evenID
		if (Koreographer.Instance != null)
		{
			Koreographer.Instance.UnregisterForAllEvents(this);
		}
	}
}
