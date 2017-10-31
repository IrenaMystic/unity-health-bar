using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
	public Energy energy;

	public RectTransform[] energyStages;

	public float speedAnimation;

	private RectTransform rectTransform;

	private float currentEnergy;

	private float targetEnergy;

	void Start ()
	{
		rectTransform = GetComponent<RectTransform> ();
		currentEnergy = energy.currentValue;
	}

	void Update ()
	{
		targetEnergy = energy.currentValue;

		if (!Mathf.Approximately (targetEnergy, currentEnergy)) {
			float pointSize = rectTransform.rect.width * energyStages.Length / energy.maxValue;
			float energyStageAmount = energy.maxValue / energyStages.Length;

			float sign = Mathf.Sign (targetEnergy - currentEnergy);
			if (sign > 0) {
				currentEnergy = Mathf.Min(currentEnergy + sign * speedAnimation, targetEnergy);
			} else {
				currentEnergy = Mathf.Max(currentEnergy + sign * speedAnimation, targetEnergy);
			}

			for (int i = 0; i < energyStages.Length; i++) {
				Vector2 sizeDelta = energyStages [i].sizeDelta;
				sizeDelta.x = Mathf.Clamp(((currentEnergy / energyStageAmount) - i),0 ,1) * energyStageAmount * pointSize;
				energyStages[i].sizeDelta = sizeDelta;
			}
		}
	}
}
