using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour {

	public float power;

	public float radius;

	void Update () {
		if (Input.GetMouseButtonDown(0)){
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out hit, 100)) {
				Debug.Log (hit.transform.name);
				hit.transform.gameObject.GetComponent<Rigidbody> ().AddExplosionForce (power, hit.transform.position, radius);
			}
		}
	}
}
