using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedSpawner : MonoBehaviour {

	public GameObject headToSpawn;

	public Transform placeToSpawn;

	public float timer;

	public float timeOut;

	// Update is called once per frame
	void Update () {

		timer += Time.deltaTime;

		if (timer >= timeOut) {
			Instantiate (headToSpawn, placeToSpawn.position, placeToSpawn.rotation);
			timer = 0;
		}

	}
}
