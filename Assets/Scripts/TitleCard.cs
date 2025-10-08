using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleCard : MonoBehaviour
{
    public Animator titleCardAnimator;

    public string titleCardBoolean;
    public AudioSource bgMusic;
    private void OnTriggerEnter(Collider other)
    {
        //plays the animation attached to the title - uses on trigger
        titleCardAnimator.SetBool(titleCardBoolean, true);
        if(bgMusic.isPlaying == false)
        {
            bgMusic.Play();
        }
        
    }

}


