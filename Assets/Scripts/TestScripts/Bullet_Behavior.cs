using UnityEngine;
using System.Collections;

public class Bullet_Behavior : MonoBehaviour {

	private float force = 2000.0f;
	// Use this for initialization
	void Start () {
		rigidbody2D.AddForce (transform.right * force);
		Debug.Log ("Bullet Shot");
	}
	
	// Update is called once per frame
	void Update () {
		//gameObject.transform.position += (Time.deltaTime * speed * transform.forward);
	}

	void OnCollisionEnter2D(Collision2D other){
		Destroy (gameObject);
		if (other.gameObject.tag == "Enemy") {
						EnemyStats script = (EnemyStats)other.gameObject.GetComponent (typeof(EnemyStats));
						script.decreaseHealth (1);
				}
	}
}
