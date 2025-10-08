using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLocation : MonoBehaviour {

	public Transform[] locations;
    
    public KeyCode keyToPress;
    
    void Update(){
        if (Input.GetKeyUp (keyToPress) == true) {
			ChangeLocation(); 
        }
    }

	public void ChangeLocation(){

		int x = Random.Range (0, locations.Length);

		transform.position = locations [x].position;

	}

}