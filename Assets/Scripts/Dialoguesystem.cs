using System.Collections;
using TMPro;
using UnityEngine;

public class Dialoguesystem : MonoBehaviour
{
    public Animator dialogueanimator;
    public TextMeshProUGUI dialogueObject;
    public string dialogueText;
    public bool hasBeenInteractedWith = false;
    public bool CanBeTriggered = false;
    public Dialoguesystem nextDialogueSystem;

    // Update is called once per frame
    private void OnMouseDown()
    {
        InteractWithTrigger();
    }
    private void OnTriggerEnter(Collider other)
    {
        InteractWithTrigger();
    }

    void InteractWithTrigger()
    {
        if (hasBeenInteractedWith == false && CanBeTriggered == true)
        {
            dialogueanimator.SetBool("Display", true);
            dialogueObject.text = dialogueText;
            StartCoroutine(WaitforPopDown());
            hasBeenInteractedWith=true;
            nextDialogueSystem.CanBeTriggered = true;
        }
        //dialogueanimator.SetBool("DisplayText",true);
       // dialogueObject.text = dialogueText;
        //Debug.Log("Dialogue Trigger");
        //Invoke("WaitToPopDown", 3);
    }
   private void OnTriggerEnterr(Collider other)
    {
        if (hasBeenInteractedWith == false && CanBeTriggered == true)
        {
            dialogueanimator.SetBool("Display", true);
            dialogueObject.text = dialogueText;
            StartCoroutine(WaitforPopDown());
            hasBeenInteractedWith = true;
            nextDialogueSystem.CanBeTriggered = true;
        }
     
    }
    void WaitToPopDown()

    {
        dialogueanimator.SetBool("DisplaText", false);
    }
    IEnumerator WaitforPopDown()
    {
        //Debug.Log("Start waiting");
        yield return new WaitForSeconds(3);
        //Debug.Log("End Waiting");
        dialogueanimator.SetBool("Display", false);
    }
}
