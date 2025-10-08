using System.Collections;
using UnityEngine;

class DragTransform : MonoBehaviour
{
	public Color mouseOverColor = Color.blue;
	public Color originalColor = Color.yellow;
	public bool dragging = false;
	private float distance;
	private Material thisMaterial;


	void Start(){
		thisMaterial = gameObject.GetComponent<Renderer> ().material;
	}

	void OnMouseEnter()
	{
		thisMaterial.color = mouseOverColor;
	}

	void OnMouseExit()
	{
		thisMaterial.color = originalColor;
	}

	void OnMouseDown()
	{
		distance = Vector3.Distance(transform.position, Camera.main.transform.position);
		dragging = true;
	}

	void OnMouseUp()
	{
		dragging = false;
	}

	void Update()
	{
		if (dragging)
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			Vector3 rayPoint = ray.GetPoint(distance);
			transform.position = rayPoint;
		}
	}
}