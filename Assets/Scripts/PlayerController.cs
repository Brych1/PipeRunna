using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
	public float InputDelay;
	public float MovementVelocity;
	private float horizontalInput;
	private float verticalInput;
	public Rigidbody Rbody;

	private void GetInput()
	{
		verticalInput = Input.GetAxis("Vertical");
		horizontalInput = Input.GetAxis("Horizontal");
	}

	private void Move()
	{
		if (Mathf.Abs(verticalInput) > InputDelay)
		{
			Rbody.velocity = transform.up * verticalInput * MovementVelocity;
		}
		else if (Mathf.Abs(horizontalInput) > InputDelay)
		{
			Rbody.velocity = -transform.forward * horizontalInput * MovementVelocity;
		}
		else
		{
			Rbody.velocity = Vector3.zero;
		}
	}

	#region UnityAPI
	private void Start()
	{
		Rbody = GetComponent<Rigidbody>();
		verticalInput = horizontalInput = 0;
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
