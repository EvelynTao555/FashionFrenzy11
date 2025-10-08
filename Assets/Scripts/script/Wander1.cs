using UnityEngine;
using System.Collections;
[RequireComponent(typeof(AudioSource))]

/// <summary>
/// Creates wandering behaviour for a CharacterController.
/// </summary>
[RequireComponent(typeof(CharacterController))]
public class Wander : MonoBehaviour
{
	public float speed = 5;
	public float directionChangeInterval = 1;
	public float maxHeadingChange = 30;

	protected Animator animator;

	int state = 0; //0-idle, 1-run, 2-eat

	CharacterController controller;
	float heading;
	Vector3 targetRotation;

	AudioSource audioz;

	float t=1;
	float currentT=0;

	float t2=1;
	float currentT2=0;

	float t3=3;
	float currentT3=0;

	
	void Awake ()
	{
		state = Random.Range (0, 2);
		t2 = Random.Range (1,3);

		controller = GetComponent<CharacterController>();

		audioz = GetComponent<AudioSource>();

		animator = GetComponent<Animator>();

		// Set random initial rotation
		heading = Random.Range(0, 360);
		transform.eulerAngles = new Vector3(0, heading, 0);
		controller.Move(Vector3.down * speed*10);

		}
	
	void Update ()
	{
		if (state == 2) { //eat
				animator.SetInteger ("State", 2);
			if (currentT2/2 > t2) state = Random.Range (0, 2);
			currentT2 += Time.deltaTime;
		} else if (state == 1) { //run
			animator.SetInteger ("State", 1);

			if (currentT2 > t2) NewHeadingRoutine ();

			transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, targetRotation, Time.deltaTime * directionChangeInterval);
			var forward = transform.TransformDirection(Vector3.forward);
			controller.SimpleMove(forward * speed);

			if (currentT3 > t3) {
				state = 0;
				currentT3 = 0;
			}

			currentT2 += Time.deltaTime;
			currentT3 += Time.deltaTime;

		} else { //idle
				animator.SetInteger ("State", 0);
			if (currentT2/2 > t2) state = 1;
				currentT2 += Time.deltaTime;
		}

		currentT += Time.deltaTime;
		controller.Move(Vector3.down * speed);


	}

	void NewHeadingRoutine ()
	{
		var floor = Mathf.Clamp(heading - maxHeadingChange, 0, 360);
		var ceil  = Mathf.Clamp(heading + maxHeadingChange, 0, 360);
		heading = Random.Range(floor, ceil);
		targetRotation = new Vector3(0, heading, 0);
		currentT2 = 0;
	}

	void OnTriggerEnter (Collider other) {  //this is da sensor
		if (other.tag == "Block") {
			//print ("miam");
			transform.LookAt(new Vector3(other.transform.position.x, transform.position.y, other.transform.position.z));
			state = 2;

				}
		else if (currentT > t) {
						//print ("miam");
			audioz.pitch= Time.timeScale* Random.Range(0.8f,1.2f);
						audioz.Play ();
						//var floor = Mathf.Clamp(heading - maxHeadingChange, 0, 360);
						//var ceil  = Mathf.Clamp(heading + maxHeadingChange, 0, 360);
						//heading = Random.Range(floor, ceil);
						heading = heading + 120;
			if (heading>360) heading -= 360;
						targetRotation = new Vector3 (0, heading, 0);
			currentT = 0;
				}
		}
}