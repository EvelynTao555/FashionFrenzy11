using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShoot : MonoBehaviour {

	public Transform thisCamera; //main character
	public Transform bullet; // the bullet prefab
	public GameObject spawnPt; // holds the spawn point object
	public float interval = 0.2f;
	public float nextShot = 0.0f;

	void FixedUpdate(){   
		if((Input.GetMouseButton(0) && (Time.time >= nextShot))){ 
			nextShot = Time.time + interval;// only do anything when the button is pressed:
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit, Mathf.Infinity)){
				Debug.DrawLine (thisCamera.position, hit.point);
				Transform projectile = Instantiate(bullet, spawnPt.transform.position, Quaternion.identity); 
				// turn the projectile to hit.point
				projectile.transform.LookAt(hit.point); 
				// accelerate it
				projectile.GetComponent<Rigidbody>().linearVelocity = projectile.transform.forward * 30;
			}
		}

	}
}