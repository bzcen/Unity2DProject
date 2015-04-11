using UnityEngine;
using System.Collections;

public class P2_EnemyPath : EnemyAI {

	public GameObject p1;
	public GameObject p2;

	// waypoints

	public string rotation_dir_1_to_2;
	public string rotation_dir_2_to_1;

	// c = clock-wise
	// cc = counter-clock-wise


	private int state;
	private int max_state;
	public float speed;
	public float rspeed;

	// Use this for initialization
	public override void Start () {
		state = 1;
		max_state = 4;
		alerted = false;
	
	}
	
	// Update is called once per frame
	public override void Update () {
	
		switch(state){

		case 1:
			TurnTo (p1,rotation_dir_2_to_1);
			break;
		case 2:
			MoveTowards (p1);
			break;
		case 3:
			TurnTo (p2,rotation_dir_1_to_2);
			break;
		case 4:
			MoveTowards (p2);
			break;
		}

	}
	void MoveTowards(GameObject point){
		// calculate the length of a vector between the enemy and the waypoint position
		// can use either Vector2 or Vector3, since the z coordinate difference is always 0
		var distance = Vector3.Distance (transform.position, point.transform.position);
		if (distance <= 0.1f) {
			if (state < max_state){

				state += 1;
			} else {
				state = 1;
			}

		} else {
		
		transform.position = Vector2.MoveTowards(transform.position, point.transform.position, speed*Time.deltaTime);
		}
	}
	void TurnTo(GameObject point, string type){

		// create a 2D vector from enemy to waypoint
		// calculate the angle of the vector relative to if the object's default direction is right ->
		var offset = new Vector2 (point.transform.position.x - transform.position.x, point.transform.position.y - transform.position.y);
		var angle = Vector2.Angle (transform.right, offset);
	
		if (angle <= 5.0f){
			if (state < max_state){
				state += 1;
			} else {
				state = 1;
			}
		} else {
			if (type == "c"){
				transform.Rotate(0,0,-rspeed * Time.deltaTime);
			} else if (type == "cc"){
				transform.Rotate(0,0,rspeed * Time.deltaTime);
			}
		}
	}
	public override void ToggleAlerted(){
		Debug.Log ("alerted");
		alerted = true;
	}
}
