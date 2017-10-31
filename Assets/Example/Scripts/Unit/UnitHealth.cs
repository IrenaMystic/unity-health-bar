using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Health))]
[RequireComponent (typeof(Shield))]
[RequireComponent (typeof(Rigidbody))]
public class UnitHealth : MonoBehaviour
{
	private Health health;

	private Shield shield;

	void Start ()
	{
		health = GetComponent<Health> ();
		shield = GetComponent<Shield> ();
	}

	void OnCollisionEnter (Collision col)
	{
		Bullet bullet = col.gameObject.GetComponent<Bullet> ();
		if (bullet != null) {
			float healthDamage = shield.currentValue - bullet.BulletDamage;
			shield.Consume (bullet.BulletDamage);
			if (healthDamage < 0) {
				health.Consume (Mathf.Abs (healthDamage));
			}
		}
	}
}
