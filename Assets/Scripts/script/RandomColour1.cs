using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColour : MonoBehaviour {

	public Color[] colours;

	private float timer;

	public float timeOut;

	private Material thisMaterial; 

	void Start(){
		thisMaterial = GetComponent<Renderer> ().material;
	}

	void Update(){
		timer += Time.deltaTime;
		int x = Random.Range (0, colours.Length);
		if (timer >= timeOut) {
			
			thisMaterial.color = colours [x];
			timer = 0;
		}
			
	}

}
