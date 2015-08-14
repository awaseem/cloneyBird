using UnityEngine;
using System.Collections;

public class BirdMovement : MonoBehaviour {
	
	Vector3 velocity = Vector3.zero;
	float flapSpeed = 100f;
	float forwardSpeed = 1f;
	
	bool didFlap = false;
	public bool dead = false;
	float deathCoolDown;
	
	public bool godMode = false;
	Animator animator;
	// Use this for initialization
	void Start () {
		animator = transform.GetComponentInChildren<Animator> ();
	}
	
	// Do Graphic & Input updates here
	void Update() {
		if (dead){
			
			deathCoolDown -= Time.deltaTime;
			
			if (deathCoolDown <= 0) {
				if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) )
					Application.LoadLevel(Application.loadedLevel);
			}
		}
		else{
		 if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) ) {
		 	didFlap = true;
			}
		}
	}

	// Do physics engine updates here
	void FixedUpdate () {

		if (dead)
			return;

		rigidbody2D.AddForce (Vector2.right * forwardSpeed);
		if (didFlap) {
			animator.SetTrigger("DoFlap");
			rigidbody2D.AddForce (Vector2.up * flapSpeed);
			didFlap = false;
		}
	
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if(godMode){
			return;
		}
		animator.SetTrigger ("Death");
		dead = true;
		deathCoolDown = 0.5f;
	}
}