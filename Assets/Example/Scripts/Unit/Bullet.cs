using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
	public float BulletDamage { get; set; }

	void OnCollisionEnter (Collision col)
	{
		Destroy (gameObject);
	}
}
