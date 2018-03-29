using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class ObstacleDanger : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			//endgame here
			Debug.Log("player dead");
		}
	}
}
