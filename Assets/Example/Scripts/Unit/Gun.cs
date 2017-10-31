using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Energy))]
public class Gun : MonoBehaviour
{
	public Rigidbody bullet;

	public Transform muzzle;

	public float bulletSpeed = 50f;

	public float bulletDamage = 60;

	public float bulletEnergyCost = 20;

	private Energy unitEnergy;

	void Awake ()
	{
		unitEnergy = GetComponent<Energy> ();
	}

	public void Fire() {
		if (unitEnergy.currentValue >= bulletEnergyCost) {
			Rigidbody instance = Instantiate (bullet, muzzle.position + muzzle.forward * 1, muzzle.rotation) as Rigidbody;

			instance.velocity = muzzle.forward * bulletSpeed;

			instance.GetComponent<Bullet> ().BulletDamage = bulletDamage;

			unitEnergy.Consume (bulletEnergyCost);
		}
	}
}
