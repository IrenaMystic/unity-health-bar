using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMovement : MonoBehaviour
{
	public Transform body;

	public float speed = 5f;

	void Start ()
	{
		
	}

	public void LookAt(Vector3 lookAtPosition) {
		Vector3 targetPostition = new Vector3 (lookAtPosition.x, transform.position.y, lookAtPosition.z);
		body.LookAt (targetPostition, Vector3.up);
	}
}
