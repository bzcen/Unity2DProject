using UnityEngine;
using System.Collections;

public class Gun_Fire : MonoBehaviour {
	

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	float spawn_distance = 2.0f;
	
		if (Input.GetMouseButtonDown (0)) {

			GameObject.Instantiate ((GameObject)Resources.Load("TestBullet"), transform.position + spawn_distance * transform.right, transform.rotation);
		}
	}
}
