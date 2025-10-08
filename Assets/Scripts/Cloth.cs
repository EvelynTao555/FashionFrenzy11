using UnityEngine;

public enum ClothType
{
    Puffer,
    Pans
}

public class Cloth : MonoBehaviour
{
    public ClothType type;

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
