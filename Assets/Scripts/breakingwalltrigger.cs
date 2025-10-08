using UnityEngine;

public class BreakingWall : MonoBehaviour
{
    [Header("Effects")]
    public ParticleSystem breakEffect;   // Assign a prefab
    public AudioClip breakSound;         // Assign an audio clip

    [Header("Settings")]
    public string breakTriggerTag = "Breakable"; // Tag of object that can break this wall

    private bool hasBroken = false; // Prevent multiple triggers

    private void OnCollisionEnter(Collision collision)
    {
        if (hasBroken) return; // already broken, ignore
        if (!collision.gameObject.CompareTag(breakTriggerTag)) return;

        hasBroken = true;

        // Spawn and play particle effect
        if (breakEffect != null)
        {
            ParticleSystem ps = Instantiate(breakEffect, transform.position, Quaternion.identity);
            ps.Play();
            Destroy(ps.gameObject, ps.main.duration + ps.main.startLifetime.constantMax);
        }

        // Play sound at wall position
        if (breakSound != null)
        {
            AudioSource.PlayClipAtPoint(breakSound, transform.position);
        }

        // Destroy wall
        Destroy(gameObject);
    }
}
