using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleControl : MonoBehaviour
{
	public float movmentTime;
	public float rotationTime;
	public float delayTime;
	public Vector3 targetRotation;
	private List<Transform> obstacles = new List<Transform>();
	public List<Transform> placeholders = new List<Transform>();
	private int i;

	public IEnumerator MoveToPoint(Vector3 newPos,float time,GameObject cube)
	{

		float elapsedTime = 0;
		Vector3 startingPos = cube.transform.position;
		while(elapsedTime < time) {
			cube.transform.position = Vector3.Lerp(startingPos,newPos,(elapsedTime / time));
			elapsedTime += Time.deltaTime;
			yield return null;
		}
	}

	public IEnumerator RotateToAngle(Vector3 targetAngle,float time,GameObject seg)
	{
		float elapsedTime = 0;
		Quaternion targetRotation = Quaternion.Euler(targetAngle);
		while(elapsedTime < time) {
			seg.transform.rotation = Quaternion.Lerp(seg.transform.rotation,targetRotation,(elapsedTime / time));
			elapsedTime += Time.deltaTime;
			yield return null;
		}
	}
	private void functionWrapper()
	{
		StartCoroutine(MoveToPoint(placeholders[i].transform.position,movmentTime,obstacles[i].gameObject));
	}
	#region UnityBuildIns
	private void Awake()
	{
		var temp = GetComponentInChildren<Transform>();
		foreach(Transform item in temp) {
			if(item.tag == "LiftedPlaceholders") { placeholders.Add(item); }
			else { obstacles.Add(item); }
		}

	}
	// Use this for initialization
	void Start()
	{
		if(TraceGenerate.segsPlaced >= TraceGenerate.segsObstacleLess) {
			i = Random.Range(0,obstacles.Count);
			StartCoroutine(RotateToAngle(targetRotation,rotationTime,this.transform.parent.gameObject));
			Invoke("functionWrapper",delayTime);
		}
	}

	// Update is called once per frame
	void Update()
	{

	}
	#endregion
}