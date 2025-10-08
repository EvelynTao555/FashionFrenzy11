using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HappyCatController : MonoBehaviour
{
    public Animator objectToAnimate;
    public string[] animationBooleans;   // Sequence of animation triggers (booleans in Animator)
    private int currentStep = 0;         // Which step we’re currently on

    public bool isLocked;
    public float interactiveDistance = 5;

    public bool hasBeenInteractedWith;

    [Header("Particles")]
    public ParticleSystem[] particleSystems;

    [Header("Turn On / Off Objects")]
    public GameObject[] objectsToTurnOff;
    public GameObject[] objectsToTurnOn;
    public bool turnOffSelf;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip[] sounds; // multiple sounds for each step

    private void OnMouseDown()
    {
        if (isLocked) return;

        if (Vector3.Distance(Camera.main.transform.position, transform.position) > interactiveDistance)
            return;

        if (currentStep < animationBooleans.Length)
        {
            // Trigger the next animation
            string animBool = animationBooleans[currentStep];
            if (objectToAnimate != null && !string.IsNullOrEmpty(animBool))
            {
                objectToAnimate.SetBool(animBool, true);
                Debug.Log("Played animation: " + animBool);
            }

            // Play sound for this step (if exists)
            if (audioSource != null && currentStep < sounds.Length && sounds[currentStep] != null)
            {
                audioSource.PlayOneShot(sounds[currentStep]);
                Debug.Log("Played sound: " + sounds[currentStep].name);
            }

            // Play particle effect for this step (if exists)
            if (particleSystems != null && currentStep < particleSystems.Length && particleSystems[currentStep] != null)
            {
                particleSystems[currentStep].Play();
                Debug.Log("Played particles: " + particleSystems[currentStep].name);
            }

            currentStep++; // Move to next step
        }
        else
        {
            // Sequence finished ?turn on/off objects
            if (objectsToTurnOff != null)
            {
                foreach (GameObject obj in objectsToTurnOff)
                    if (obj != null) obj.SetActive(false);
            }

            if (objectsToTurnOn != null)
            {
                foreach (GameObject obj in objectsToTurnOn)
                    if (obj != null) obj.SetActive(true);
            }

            if (turnOffSelf)
                gameObject.SetActive(false);

            hasBeenInteractedWith = true;
            Debug.Log("Sequence complete.");
        }
    }

    private void OnMouseOver()
    {
        if (!isLocked && !hasBeenInteractedWith &&
            Vector3.Distance(Camera.main.transform.position, transform.position) < interactiveDistance)
        {
            Interactive.overObject = true;
        }
    }
}
