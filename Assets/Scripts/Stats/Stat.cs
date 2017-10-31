using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Stat : MonoBehaviour
{
	public float maxValue;

	public float currentValue { 
		get { 
			return _currentValue;
		}
		set {
			_currentValue = Mathf.Clamp (value, 0, maxValue);	
		} 
	}

	public float regenRate = 20;

	private float _currentValue;

	public virtual void Awake ()
	{
		currentValue = maxValue;
	}

	void Update ()
	{
		currentValue += regenRate * Time.deltaTime;
	}

	public void Consume (float consumeValue)
	{
		currentValue -= consumeValue;
	}
}
