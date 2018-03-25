using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraceDestroy : MonoBehaviour
{
	private GameObject traceDestructPoint;

	// Use this for initialization
	void Start()
	{
		traceDestructPoint = GameObject.Find("DestructionPoint");

	}

	// Update is called once per frame
	void Update()
	{
		if(transform.position.x < traceDestructPoint.transform.position.x) {
			Destroy(gameObject);
		}

	}
}
