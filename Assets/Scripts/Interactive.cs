using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactive : MonoBehaviour
{
    public GameObject exclaimSprite;
    public static bool overObject = false;

    // Update is called once per frame
    void Update()
    {
        //checks if looking at an interactable object
        if (overObject == true)
        {
            exclaimSprite.SetActive(true);
        }
        else
        {
            exclaimSprite.SetActive(false);
        }
        
    }

    private void LateUpdate()
    {
        //resets if looking at interactable object
        overObject = false;
    }
}
