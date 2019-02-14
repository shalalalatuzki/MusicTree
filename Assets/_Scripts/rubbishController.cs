using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rubbishController: MonoBehaviour
{
	//随机位置表产生使用的参数
	public float[] positionArray;
	
	public GameObject rubbishPrefab;

	public Vector3 randomLimit;
	
	private Vector3  rainPosition=Vector3.zero;

	private Quaternion rainRotation;
	
	// Use this for initialization
	IEnumerator RubbishCreator ()
	{
		//rainPosition.position= new Vector3(Random.Range(-randomLimit.x, randomLimit.x),randomLimit.y,this.transform.position .z);
		//产生与水滴不重叠的随机数
		while(true)
		{
			yield return new WaitForSeconds(2);
			//生成随机索引
			int index = Random.Range(0, positionArray.Length);
			//print(index);
			//print("rubbish"+positionArray[index]);
			randomLimit.x = positionArray[index];
			rainPosition.x = randomLimit.x;
			rainPosition.y = randomLimit.y;
			rainRotation = Quaternion.identity;
			Instantiate(rubbishPrefab, rainPosition, rainRotation);
		}

	}

	// Update is called once per frame
	void Start ()
	{
		StartCoroutine(RubbishCreator());
	}
}
