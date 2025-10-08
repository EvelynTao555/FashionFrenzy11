using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

	public float speedx;
    public float speedy;
    public float speedz;




    void Update () {

		transform.Rotate (speedx * Time.deltaTime, speedy * Time.deltaTime, speedz * Time.deltaTime);
		
	}
}
