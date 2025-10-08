using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Float : MonoBehaviour {


    public Vector3 moveDirection;
    public float moveDistance;
    public float moveSpeed;

    private Vector3 startPosition;


	// Use this for initialization
	void Start () {
        startPosition = gameObject.transform.position;

    }
	
	// Update is called once per frame
	void Update () {
        transform.position = startPosition + moveDirection * (moveDistance * Mathf.Sin(Time.time * moveSpeed));


		
	}
}
