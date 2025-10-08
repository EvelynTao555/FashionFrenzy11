using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateFromOther : MonoBehaviour {
    
    public float rotateamountx;
    public float rotateamounty;
    public float rotateamountz;

	public void RotateCube (){
		transform.Rotate (rotateamountx, rotateamounty, rotateamountz);
	}
}
