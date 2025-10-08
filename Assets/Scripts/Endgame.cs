using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endgame : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator downStairsDoor;
    public string downStairsDoorBoolean;
    public float endGameTime;
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //triggers the end game coroutine
        StartCoroutine(endgame(endGameTime));
    }

    IEnumerator endgame(float time)
    {
        //triggers the door closing
        downStairsDoor.SetBool(downStairsDoorBoolean, true);
        //waits for a set time
        yield return new WaitForSeconds(time);
        //quiting
        Application.Quit();
    }
}
