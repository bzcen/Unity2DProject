﻿using UnityEngine;
using System.Collections;

public class WASD_Movement : MonoBehaviour {

public float speed = 20.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.W)) {
						transform.position += Vector3.up * speed * Time.deltaTime;
				}
		if (Input.GetKey (KeyCode.A)) {
						transform.position += Vector3.left * speed * Time.deltaTime;
				}
		if (Input.GetKey (KeyCode.D)) {
						transform.position += Vector3.right * speed * Time.deltaTime;
				}
		if (Input.GetKey (KeyCode.S)) {
						transform.position += Vector3.down * speed * Time.deltaTime;
				}


	}
}
