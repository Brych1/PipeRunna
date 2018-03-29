using UnityEngine;

public class CleanPipeControl : MonoBehaviour
{
	public Transform DestructionTransform;
	public float RotationTime;
	public float SegMovementSpeed;
	public Vector3 TargetRotation;
	private MovingUtils ObstacleMove = new MovingUtils();
	private float step;

	#region UnityAPi
	// Use this for initialization

	private void Start()
	{
		StartCoroutine(ObstacleMove.RotateToAngle(TargetRotation, RotationTime, gameObject));
	}

	// Update is called once per frame
	private void Update()
	{
		step = SegMovementSpeed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, DestructionTransform.position, step);
	}
	#endregion
}
