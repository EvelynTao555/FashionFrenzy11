using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollow : MonoBehaviour {

	//public Camera camera;

	void Update(){
		Vector3 screenPoint = Input.mousePosition;
		screenPoint.z = 1;
		transform.position = Camera.main.ScreenToWorldPoint (screenPoint);
	}
}
