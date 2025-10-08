using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapdoorTrigger : MonoBehaviour
{
    public GameObject trapdoor;
    public GameObject Lamp_2;
    public ParticleSystem trapdoorDust;
    public AudioSource trapdoorSound;
    public Animator trapdoorAnimationCurve;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        //turns on physics for the trap door
       
        trapdoorDust.Play();
        trapdoorSound.Play();
        trapdoorAnimationCurve.SetBool("trapdoor", true);
        Destroy(gameObject);
    }
}
