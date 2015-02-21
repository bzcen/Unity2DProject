using UnityEngine;
using System.Collections;

public class Bullet_Behavior : MonoBehaviour {

	private float force = 2000.0f;
	// Use this for initialization
	void Start () {
		rigidbody.AddForce (transform.right * force);
		Debug.Log ("Bullet Shot");
	}
	
	// Update is called once per frame
	void Update () {
		//gameObject.transform.position += (Time.deltaTime * speed * transform.forward);
	}

	void OnCollisionEnter(){
		Destroy (gameObject);
	}
}
