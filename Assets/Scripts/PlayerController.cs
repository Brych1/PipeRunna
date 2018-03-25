using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
	public float InputDelay;
	public float MovementVelocity;
	public Rigidbody Rbody;
	private float HorizontalInput;

	private float VerticalInput;

	private void GetInput()
	{
		VerticalInput = Input.GetAxis("Vertical");
		HorizontalInput = Input.GetAxis("Horizontal");
	}

	private void Move()
	{
		if (Mathf.Abs(VerticalInput) > InputDelay)
		{
			Rbody.velocity = transform.up * VerticalInput * MovementVelocity;
		}
		else if (Mathf.Abs(HorizontalInput) > InputDelay)
		{
			Rbody.velocity = -transform.forward * HorizontalInput * MovementVelocity;
		}
		else
		{
			Rbody.velocity = Vector3.zero;
		}
	}

	#region UnityAPI
	private void Start()
	{
		if (Rbody == null)
		{
			Debug.Log("Please drag player GO into inspector");
		}
		VerticalInput = HorizontalInput = 0;
	}

	private void Update()
	{
		GetInput();
	}

	private void FixedUpdate()
	{
		Move();
	}
	#endregion
}
