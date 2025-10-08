using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEffect : MonoBehaviour
{
    [SerializeField] ParticleSystem particle;

    GameObject lastObject;

    bool over;
    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if(Physics.Raycast(this.transform.position, this.transform.forward, out hit, 4f))
        {
            if(over == true && hit.collider.gameObject != lastObject && Input.GetMouseButton(0))
            {
                lastObject = hit.collider.gameObject;
                particle.transform.position = hit.point;
                particle.transform.forward = hit.normal;
                particle.Play();
            }
            

        }

        over = Interactive.overObject;
    }
}
