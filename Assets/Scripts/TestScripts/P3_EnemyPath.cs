using UnityEngine;
using System.Collections;

public class P3_EnemyPath : MonoBehaviour {

	public GameObject p1;
	public GameObject p2;
	public GameObject p3;
	
	
	private int state;
	private int max_state;
	private bool turn;
	
	public float speed;
	
	// Use this for initialization
	void Start () {
		state = 1;
		turn = false;
		max_state = 3;
		
	}
	
	// Update is called once per frame
	void Update () {
		
		switch(state){
			
		case 1:
			MoveTowards (p1);
			TurnTo(p2);
			break;
		case 2:
			MoveTowards (p2);
			TurnTo(p1);
			break;
		case 3:
			MoveTowards (p3);
			TurnTo(p1);
			break;
		}
		
	}
	void MoveTowards(GameObject point){
		var distance = Vector3.Distance (transform.position, point.transform.position);
		if (distance <= 0.1f) {
			
			if (state < max_state){
				
				state += 1;
			} else {
				state = 1;
			}
			turn = true;
			
		} else {
			transform.position = Vector2.MoveTowards(transform.position, point.transform.position, speed*Time.deltaTime);
		}
	}
	void TurnTo(GameObject point){
		if (turn) {
			var offset = new Vector2(transform.position.x - point.transform.position.x, transform.position.y - point.transform.position.y);
			var angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.Euler(0, 0, angle);
			turn = false;
		}
	}
}
