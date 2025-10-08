using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanLamp : MonoBehaviour
{
    //public Animator objectToAnimate;
    //public string openBooleanName;
    public bool isLock;
    public float interactiveDistance = 5;

    public bool hasBeenInteractedWith;
    private void OnMouseDown()
    {
        //Plays the door opening animation when door is locked, and distance to OBJECT is less than interactive distance
        if(isLock == false && Vector3.Distance(Camera.main.transform.position, this.transform.position) < interactiveDistance)
        {
            //objectToAnimate.SetBool(openBooleanName, true);
            Destroy(gameObject);
            hasBeenInteractedWith = true;
        }
    }

    private void OnMouseOver()
    {
        //Changes the hover icon if object cna be interacted with
        if (isLock == false && hasBeenInteractedWith == false && Vector3.Distance(Camera.main.transform.position, this.transform.position) < interactiveDistance)
        {
            Interactive.overObject = true;
        }        
    }
}
