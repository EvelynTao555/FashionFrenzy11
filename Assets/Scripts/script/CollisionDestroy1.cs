using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDestroy : MonoBehaviour {

	// Use this for initialization
	void OnCollisionEnter (Collision other){
		if (other.gameObject.tag == "Blob") {
			Debug.Log ("YES");
			Destroy (other.gameObject);
		}
	}
}
