using UnityEngine;

public class Trapdoor : MonoBehaviour
{
    public GameObject trapdoor;
    public ParticleSystem dusParticles;
    public AudioSource breakSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        trapdoor.SetActive(false);
        dusParticles.Play(); 
        breakSound.Play();
        Destroy(gameObject);

        Debug.Log("Entered Trigger");

    }
}
