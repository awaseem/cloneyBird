using UnityEngine;
using System.Collections;

public class BGLopper : MonoBehaviour {

	int numBGPanels = 6;

	float pipeMax = 0.7339585f;
	
	float pipeMin = 0.22421f;

	void OnTriggerEnter2D(Collider2D other){
			
		float widthOfBGObject = ((BoxCollider2D)other).size.x;

		Vector3 pos = other.transform.position;

		pos.x += widthOfBGObject * numBGPanels - widthOfBGObject/1f;

		if(other.tag == "Pipe"){
			pos.y = Random.Range(pipeMin, pipeMax);
		}

		other.transform.position = pos;

	}

}
