using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporaryObject : MonoBehaviour {

	public float destroyTime;

	void Start () {
		Invoke ("DestroyObject", destroyTime);
	}

	private void DestroyObject() {
		DestroyImmediate (gameObject);
	}
}
