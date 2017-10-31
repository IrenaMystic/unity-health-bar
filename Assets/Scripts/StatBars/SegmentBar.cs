using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentBar : MonoBehaviour
{
	public HealthShieldBar healthBar;

	public GameObject segment;

	public float segmentAmount = 50;

	private List<GameObject> segments = new List<GameObject> ();

	private int numSegments;

	void Update ()
	{
		float sumStat = healthBar.currentHealth + healthBar.currentHealthDamage + healthBar.currentShield + healthBar.currentShieldDamage;
		numSegments = (int)(Mathf.Max (healthBar.health.maxValue, sumStat) / segmentAmount);

		for (int i = 0; i < numSegments - 1; i++) {
			if (i < segments.Count) {
				segments [i].SetActive (true);
			} else {
				GameObject newSegment = Instantiate (segment) as GameObject;
				newSegment.transform.SetParent (transform, false);
				newSegment.transform.SetAsFirstSibling ();
				segments.Add (newSegment);
			}
		}

		for (int i = numSegments; i < segments.Count; i++) {
			segments [i].SetActive (false);
		}
	}
}
