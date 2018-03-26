using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

public class ObstacleControl : MonoBehaviour
{
	public float DelayTime;
	public float ObstacleMovmentTime;
	public float RotationTime;
	public Vector3 TargetRotation;
	public Transform DestructionTransform;
	public float SegMovementSpeed;
	private List<GameObject> children = new List<GameObject>();
	private int obstacleIndex;
	private MovingUtils ObstacleMove = new MovingUtils();
	private Random rng = new Random();

	private void ObstacleWrapper()
	{
		StartCoroutine(ObstacleMove.MoveToPoint(children[obstacleIndex].transform.GetChild(0).position, ObstacleMovmentTime, children[obstacleIndex]));
	}

	#region UnityAPI
	private void Awake()
	{
		List<MeshCollider> tempList = GetComponentsInChildren<MeshCollider>().Where(x => x.gameObject.transform.parent != transform.parent).ToList();
		foreach (MeshCollider child in tempList)
		{
			children.Add(child.gameObject);
		}
		obstacleIndex = rng.Next(0, children.Count);
	}

	private void Start()
	{
		StartCoroutine(ObstacleMove.RotateToAngle(TargetRotation, RotationTime, gameObject));
		Invoke("ObstacleWrapper", DelayTime);
	}

	private void Update()
	{
		float step = SegMovementSpeed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position,DestructionTransform.position,step);
	}
	#endregion
}
