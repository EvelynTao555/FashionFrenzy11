using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadSpawner : MonoBehaviour {

	public GameObject headToSpawn;

	public Transform placeToSpawn;

	public KeyCode keyToPress;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp (keyToPress) == true) {
			Instantiate (headToSpawn, placeToSpawn.position, placeToSpawn.rotation);  
		}
	}
}
