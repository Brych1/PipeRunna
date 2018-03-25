using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private ObstacleControl currentPipeSeg;
	public TraceGenerate nextPipeSeg;
	//public List<GameObject> segsSpawned = new List<GameObject>();
	private int currentPipeSegIndex=2;
	private bool inPlace = false;
	private bool posChange = false;
	private Vector3 targetRotation=new Vector3(0,0,0);
	private int currentPlaceholderIndex = 0;
	private void CheckPos()
	{
		foreach(Transform placeholder in currentPipeSeg.placeholders) {
			if(transform.position == placeholder.position) {
				inPlace = true;
			}
		}
	}
	public IEnumerator RotateToAngle(Vector3 targetAngle,float time,Transform seg)
	{
		float elapsedTime = 0;
		Quaternion targetRotation = Quaternion.Euler(targetAngle);
		while(elapsedTime < time) {
			seg.transform.rotation = Quaternion.Lerp(seg.transform.rotation,targetRotation,(elapsedTime / time));
			elapsedTime += Time.deltaTime;
			yield return null;
		}
	}
	private void FunctionWrapperRight()
	{
		if(targetRotation == new Vector3(360,0,0)|| targetRotation == new Vector3(-360,0,0)) { targetRotation = new Vector3(0,0,0); }
		
		targetRotation += new Vector3(60,0,0);
		StartCoroutine(RotateToAngle(targetRotation,0.3f,this.transform));
	}
	private void FunctionWrapperLeft()
	{
		if(targetRotation == new Vector3(360,0,0) || targetRotation == new Vector3(-360,0,0)) { targetRotation = new Vector3(0,0,0); }

		targetRotation -= new Vector3(60,0,0);
		StartCoroutine(RotateToAngle(targetRotation,0.3f,this.transform));
	}
	private void GetNextSeg()
	{
		nextPipeSeg = GameObject.Find("TraceConrol").GetComponent<TraceGenerate>();
	}
	#region UnityBuildIns
	private void Awake()
	{
		//Debug.Log(TraceGenerate.segsSpawned[currentPipeSegIndex + 1]);
		
	}
	// Use this for initialization
	void Start()
	{
		//segsSpawned = TraceGenerate.segsSpawned;
		Invoke("GetNextSeg",1);		
		//Debug.Log(TraceGenerate.segsSpawned[currentPipeSegIndex + 1]);
	}

	// Update is called once per frame
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) {
			try {
				
				StartCoroutine(currentPipeSeg.MoveToPoint(currentPipeSeg.placeholders[currentPlaceholderIndex].transform.position,0.1f,gameObject));
				Invoke("functionWrapperLeft",0.1f);
				currentPlaceholderIndex -= 1;
			}
			catch(System.ArgumentOutOfRangeException) {
				currentPlaceholderIndex = currentPipeSeg.placeholders.Count - 1;
				StartCoroutine(currentPipeSeg.MoveToPoint(currentPipeSeg.placeholders[currentPlaceholderIndex].transform.position,0.1f,gameObject));
				Invoke("functionWrapperLeft",0.1f);
			}


		}


		if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) {
			try {
				
				StartCoroutine(currentPipeSeg.MoveToPoint(currentPipeSeg.placeholders[currentPlaceholderIndex].transform.position,0.1f,gameObject));
				Invoke("functionWrapperRight",0.1f);
				currentPlaceholderIndex += 1;
			}
			catch(System.ArgumentOutOfRangeException) {
				currentPlaceholderIndex = 0;
				StartCoroutine(currentPipeSeg.MoveToPoint(currentPipeSeg.placeholders[currentPlaceholderIndex].transform.position,0.1f,gameObject));
				Invoke("functionWrapperRight",0.1f);
			}
		}
		if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) 
			{			
			//StartCoroutine(nextPipeSeg.MoveToPoint(nextPipeSeg.placeholders[currentPlaceholderIndex].transform.position,0.1f,gameObject));
			currentPipeSegIndex += 1;
		}
	}
	private void LateUpdate()
	{
		CheckPos();
	}
	private void OnTriggerStay(Collider other)
	{
		if(other.gameObject.tag == "Segment") {
			currentPipeSeg = other.gameObject.GetComponent<ObstacleControl>();			
		}

		if(!inPlace) {
			transform.position = currentPipeSeg.placeholders[currentPlaceholderIndex].transform.position;
			transform.rotation = currentPipeSeg.placeholders[currentPlaceholderIndex].transform.rotation;
		}
	}
	#endregion
}
