using UnityEngine;
using System.Collections;

public class UpdatedWASD_Movement : MonoBehaviour {

	public float speed = 20.0f;

	private Rigidbody2D playerRigidbody2D;

	// Use this for initialization
	void Start () {
		playerRigidbody2D  = GetComponent <Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");

		move (h, v);
		turn ();
	}

	void move(float h, float v){
		Vector3 movement = new Vector3 (h, v, 0f);
		movement = movement.normalized * speed * Time.deltaTime;
		playerRigidbody2D.MovePosition(transform.position + movement);
	}

	void turn(){
		var mouse = Input.mousePosition;
		var screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);
		var offset = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);
		var angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
		playerRigidbody2D.MoveRotation (angle);
	}

}
