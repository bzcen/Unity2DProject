using UnityEngine;
using System.Collections;

public class FOV_Detection : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void SendSignal(){
		GameObject parent = transform.parent.gameObject;
		EnemyAI script = (EnemyAI) parent.GetComponent(typeof(EnemyAI));
		script.playerDetectedOn ();
	}
	void OnTriggerEnter2D(Collider2D other){
		// if the player enters the collision cone field
		if (other.gameObject.tag == "Player"){

			// set a raycast in the direction of the player from the beginning point of the cone
			var rayDirection = other.transform.position - transform.position;
			// fire the raycast in that direction from the beginning point position
			RaycastHit2D hit = Physics2D.Raycast(transform.position, rayDirection);

			// BIG NOTE: this only works if the object that holds the cone collision box is set to "Ignore Raycast" in "Layer", or else the raycast will immediately just hit the cone itself
			if (hit.collider != null) {
				if (hit.transform.tag == "Player") {
					Debug.Log ("Player collided");
					SendSignal();
				} else if(hit.transform.tag == "Bullet"){
					Debug.Log ("Shots Fired");
				}else{
					Debug.Log ("Something is in the way");
				}
			} else {

				Debug.Log ("Nothing hit!");
			
			}
		}

	}
}