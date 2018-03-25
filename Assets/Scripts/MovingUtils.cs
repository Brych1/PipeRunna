using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MovingUtils:ScriptableObject
{
	public IEnumerator MoveToPoint(Vector3 newPos, float time, GameObject cube)
	{
		float elapsedTime = 0;
		Vector3 startingPos = cube.transform.position;
		while (elapsedTime < time)
		{
			cube.transform.position = Vector3.Lerp(startingPos, newPos, elapsedTime / time);
			elapsedTime += Time.deltaTime;
			yield return null;
		}
	}

	public IEnumerator RotateToAngle(Vector3 targetAngle, float time, GameObject seg)
	{
		float elapsedTime = 0;
		Quaternion targetRotation = Quaternion.Euler(targetAngle);
		while (elapsedTime < time)
		{
			seg.transform.rotation = Quaternion.Lerp(seg.transform.rotation, targetRotation, (elapsedTime / time));
			elapsedTime += Time.deltaTime;
			yield return null;
		}
	}
}
