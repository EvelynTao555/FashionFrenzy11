using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScript : MonoBehaviour
{
    public GameObject player;
    public Transform holdPos;

    public float throwForce = 500f;
    public float interactiveDistance = 5f;
    public float pickUpRange = 5f;
    private float rotationSensitivity = 1f;

    private GameObject heldObj;
    private Rigidbody heldObjRb;
    private bool canDrop = true;
    public bool hasBeenInteractedWith;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip pickUpSound;

    [Header("Objects to toggle")]
    public GameObject[] objectsToTurnOn;
    public GameObject[] objectsToTurnOff;

    void Update()
    {
        HandleHover();

        // Pick up or drop with LEFT mouse button
        if (Input.GetMouseButtonDown(0))
        {
            if (heldObj == null)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpRange))
                {
                    if (hit.transform.CompareTag("canPickUp") || hit.transform.CompareTag("Breakable") || hit.transform.CompareTag("Killable"))
                    {
                        PickUpObject(hit.transform.gameObject);
                    }
                }
            }
            else if (canDrop)
            {
                StopClipping();
                DropObject();
            }
        }

        // Throw with RIGHT mouse button
        if (heldObj != null && Input.GetMouseButtonDown(1) && canDrop)
        {
            StopClipping();
            ThrowObject();
        }

        if (heldObj != null)
        {
            MoveObject();
            RotateObject();
        }
    }

    void HandleHover()
    {
        // Only set hover to true; do NOT force false
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpRange))
        {
            if (hit.transform.CompareTag("canPickUp") && !hasBeenInteractedWith &&
                Vector3.Distance(player.transform.position, hit.transform.position) < interactiveDistance)
            {
                Interactive.overObject = true;
            }
        }
    }

    void PickUpObject(GameObject pickUpObj)
    {
        if (pickUpObj.GetComponent<Rigidbody>())
        {
            heldObj = pickUpObj;
            heldObjRb = pickUpObj.GetComponent<Rigidbody>();
            heldObjRb.isKinematic = true;
            heldObj.transform.parent = holdPos;

            hasBeenInteractedWith = true;

            // Play audio
            if (audioSource != null && pickUpSound != null)
                audioSource.PlayOneShot(pickUpSound);

            // Toggle objects
            foreach (var obj in objectsToTurnOff)
                if (obj != null) obj.SetActive(false);

            foreach (var obj in objectsToTurnOn)
                if (obj != null) obj.SetActive(true);
        }
    }

    void DropObject()
    {
        heldObjRb.isKinematic = false;
        heldObj.transform.parent = null;
        heldObj = null;
    }

    void MoveObject()
    {
        heldObj.transform.position = holdPos.position;
    }

    void RotateObject()
    {
        if (Input.GetKey(KeyCode.R))
        {
            canDrop = false;
            float XaxisRotation = Input.GetAxis("Mouse X") * rotationSensitivity;
            float YaxisRotation = Input.GetAxis("Mouse Y") * rotationSensitivity;

            heldObj.transform.Rotate(Vector3.down, XaxisRotation);
            heldObj.transform.Rotate(Vector3.right, YaxisRotation);
        }
        else canDrop = true;
    }

    void ThrowObject()
    {
        heldObjRb.isKinematic = false;
        heldObj.transform.parent = null;
        heldObjRb.AddForce(transform.forward * throwForce);
        heldObj = null;
    }

    void StopClipping()
    {
        float clipRange = Vector3.Distance(heldObj.transform.position, transform.position);
        RaycastHit[] hits = Physics.RaycastAll(transform.position, transform.TransformDirection(Vector3.forward), clipRange);
        if (hits.Length > 1)
            heldObj.transform.position = transform.position + new Vector3(0f, -0.5f, 0f);
    }
}
