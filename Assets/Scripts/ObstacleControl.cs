using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

public class ObstacleControl : MonoBehaviour
{
	public float delayTime;
	public float movmentTime;
	public float rotationTime;
	private List<GameObject> children = new List<GameObject>();
	private MovingUtils ObstacleMove = new MovingUtils();
	private Random rng = new Random();

	

	#region UnityAPI
	private void Awake()
	{
		List<MeshCollider> tempList = GetComponentsInChildren<MeshCollider>().Where(x => x.gameObject.transform.parent != transform.parent).ToList();
		foreach (MeshCollider child in tempList)
		{
			children.Add(child.gameObject);
		}
		int i = rng.Next(0, children.Count);
		Debug.Log(i);
		//ObstacleMove.MoveToPoint(children[i].transform.GetChild(0).position, movmentTime, children[i]));
		StartCoroutine(ObstacleMove.MoveToPoint(children[i].transform.GetChild(0).position,movmentTime,children[i]));
	}

	private void Start()
	{ }

	private void Update()
	{ }
	#endregion
}
