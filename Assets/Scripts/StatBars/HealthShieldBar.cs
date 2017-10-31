using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthShieldBar : MonoBehaviour
{
	public Health health;

	public Shield shield;

	public LayoutElement healthElement;

	public LayoutElement healthDamageElement;

	public LayoutElement shieldElement;

	public LayoutElement shieldDamageElement;

	public float animationSpeed;

	[HideInInspector]
	public float currentHealth;

	[HideInInspector]
	public float currentHealthDamage;

	[HideInInspector]
	public float currentShield;

	[HideInInspector]
	public float currentShieldDamage;

	private RectTransform rectTransform;

	private float pointSize;

	void Start ()
	{
		rectTransform = GetComponent<RectTransform> ();
		currentHealth = health.currentValue;
		currentHealthDamage = 0;
		currentShield = shield.currentValue;
		currentShieldDamage = 0;
	}

	void Update ()
	{
		pointSize = rectTransform.rect.width / health.maxValue;

		float healthDiff = health.currentValue - currentHealth;
		currentHealth = health.currentValue;
		if (healthDiff < 0) {
			currentHealthDamage += Mathf.Abs (healthDiff);
		}

		float shieldDiff = shield.currentValue - currentShield;
		currentShield = shield.currentValue;
		if (shieldDiff < 0) {
			currentShieldDamage += Mathf.Abs (shieldDiff);
		}

		if (currentShieldDamage > 0) {
			currentShieldDamage = Mathf.Max (0, currentShieldDamage - animationSpeed * Time.deltaTime);
		} else if (currentHealthDamage > 0) {
			currentHealthDamage = Mathf.Max (0, currentHealthDamage - animationSpeed * Time.deltaTime);
		}

		healthElement.preferredWidth = pointSize * currentHealth;
		healthDamageElement.preferredWidth = pointSize * currentHealthDamage;
		shieldElement.preferredWidth = pointSize * currentShield;
		shieldDamageElement.preferredWidth = pointSize * currentShieldDamage;
	}
}
