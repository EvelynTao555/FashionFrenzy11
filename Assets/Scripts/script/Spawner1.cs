using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public Transform spawnPoint;

    public GameObject objectToSpawn;

    private float timer;

    public float timeOut;


	// Use this for initialization
	void Start () {
        timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        if (timer >= timeOut){
            Instantiate(objectToSpawn, spawnPoint.position, spawnPoint.rotation);
            timer = 0;
        }
		
	}
}
