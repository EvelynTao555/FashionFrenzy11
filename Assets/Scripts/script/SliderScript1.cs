using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour {

	public Slider scaleSlider;
	
	// Update is called once per frame
	void Update () {
		transform.localScale = new Vector3 ((scaleSlider.value + 1) * 3, (scaleSlider.value + 1) * 3, (scaleSlider.value + 1) *3);
	}
}
