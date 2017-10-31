using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
	public GameObject[] units;

	private Gun currentUnitGun;

	private UnitMovement currentUnitMovement;

	void Start ()
	{
		SetCurrentPlayer (0);
	}

	void Update ()
	{
		for (int i = 0; i < units.Length; i++) {
			if (Input.GetKeyDown ((i + 1).ToString())) {
				SetCurrentPlayer (i);
			}
		}

		if (Input.GetMouseButtonDown (0)) {
			currentUnitGun.Fire ();
		}

		Vector3 mouseScreenPosition = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z);
		Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint (mouseScreenPosition);
		currentUnitMovement.LookAt (mouseWorldPosition);
	}

	private void SetCurrentPlayer (int idx)
	{
		currentUnitGun = units [idx].GetComponent<Gun> ();
		currentUnitMovement = units [idx].GetComponent<UnitMovement> ();

	}
}
