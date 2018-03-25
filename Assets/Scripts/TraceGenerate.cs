using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraceGenerate : MonoBehaviour
{
	
	public  List<GameObject> segsSpawned = new List<GameObject>();
	public GameObject segToSpawn;
	public Transform generationPoint;
	private float distanceBetween = 5f;
	public int segCount = 0;
	public int obstacleLessSegs;
	public static int segsPlaced;
	public static int segsObstacleLess;
	#region UnityBuildIns
	// Use this for initialization
	void Start()
	{
		segsPlaced = segCount;
		segsObstacleLess = obstacleLessSegs;
	//	segsSpawned.Add(GameObject.Find("StartSeg"));
	//	segsSpawned.Add(GameObject.Find("SecSeg"));
		//segsSpawned.Add(GameObject.Find("ThirdSeg"));
	}

	// Update is called once per frame
	void Update()
	{
		segsPlaced = segCount;
		segsObstacleLess = obstacleLessSegs;
		if(transform.position.x < generationPoint.position.x) 
			{
				transform.position = new Vector3(transform.position.x + distanceBetween, 0, 0);
				segsSpawned.Add(Instantiate(segToSpawn,transform.position,transform.rotation));
				++segCount;
				Debug.Log(segCount);
			}
	}
}
#endregion

