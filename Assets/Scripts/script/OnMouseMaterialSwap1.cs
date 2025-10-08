using UnityEngine;
using System.Collections;

public class OnMouseMaterialSwap : MonoBehaviour {

	public Material highlightMat;
	Material startMat;

	// Use this for initialization
	void Start () {

		startMat = this.GetComponent<Renderer> ().material;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseOver () {

		this.GetComponent<Renderer> ().material = highlightMat;

	}

	void OnMouseExit ()
	{
		this.GetComponent<Renderer> ().material = startMat;
	}
}
