using UnityEngine;

public class TVController : MonoBehaviour
{
    public float interactiveDistance = 5;
    public MeshRenderer screenMesh;

    public Material[] screenMaterials;

    private bool canInteractive = false;

    private void OnMouseOver()
    {
        //Changes the hover icon if object cna be interacted with
        if (Vector3.Distance(Camera.main.transform.position, this.transform.position) < interactiveDistance)
        {
            Interactive.overObject = true;
            canInteractive = true;
        }
    }

    int index = 0;
    private void OnMouseDown()
    {
        if (canInteractive)
        {
            screenMesh.material = screenMaterials[index = (index + 1) % screenMaterials.Length];
        }
    }

    private void OnMouseExit()
    {
        canInteractive = false;
    }
}
