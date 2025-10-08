using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickColor : MonoBehaviour {

	public Color colourToChangeTo;

	private Color originalColour;

	private Material thisMaterial; 

	//public Rigidbody rigidbody;

	void Start (){
		thisMaterial = GetComponent<Renderer> ().material;
		originalColour = GetComponent<Renderer> ().material.color;
		//rigidbody.useGravity = false;
	}

	void OnMouseOver(){
		thisMaterial.color = colourToChangeTo;
		//rigidbody.useGravity = true;
	}

	void OnMouseExit(){
		thisMaterial.color = originalColour;
	}
		
}
