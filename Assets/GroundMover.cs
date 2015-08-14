using UnityEngine;
using System.Collections;

public class GroundMover : MonoBehaviour {

	Rigidbody2D player;
	
	void Start () {
		GameObject player_go = GameObject.FindGameObjectWithTag ("Player");
		
		player = player_go.rigidbody2D;
		
	}
	
	// Use this for initialization
	void FixedUpdate(){
		float veloctiy = player.velocity.x * 0.9f;
		
		transform.position = transform.position + Vector3.right * veloctiy * Time.deltaTime;
	}
}
