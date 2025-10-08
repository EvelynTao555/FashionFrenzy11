using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickThisCube : MonoBehaviour {

	public RotateFromOther otherCube;

	
	// Update is called once per frame
	void OnMouseDown(){
		Debug.Log ("CLICKED");
		otherCube.RotateCube ();
	}
}
