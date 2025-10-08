using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clean : MonoBehaviour
{
    public CleanLamp lampToClean;
    public bool turnOffObjects;

    bool hasBeenInteractedWith;

    private void OnMouseDown()
    {
        //sets the door to be interactable
        lampToClean.isLock = false;
        hasBeenInteractedWith = true;
        //turn off this object?
        if (turnOffObjects)
        {
            this.gameObject.SetActive(false);
        }
    }

    private void OnMouseOver()
    {
        //interact with this object
        if(hasBeenInteractedWith == false)
        {
            Interactive.overObject = true;
           
        }        
    }
}
