using UnityEngine;
using System.Collections;

public class EnemySight : MonoBehaviour {

	public GameObject player;
	public float speed = 20.0f;
	private Ray sight;
	private Rigidbody enemyRigidBody;

	// Use this for initialization
	void Start () {
		enemyRigidBody = GetComponent <Rigidbody> ();
	}

	void FixedUpdate () {

		Vector3 directionFacing = new Vector3 (Mathf.Sin(transform.localEulerAngles.z*Mathf.PI/180f), -Mathf.Cos(transform.localEulerAngles.z*Mathf.PI/180f));
		sight = new Ray(transform.position, directionFacing);
		//Debug.Log (Mathf.Cos (transform.localEulerAngles.z * Mathf.PI / 180f) + " " + Mathf.Sin (transform.localEulerAngles.z * Mathf.PI / 180f));
		RaycastHit hit;
		if (Physics.Raycast (sight, out hit, 10f)) {
			if(hit.collider.tag == "Player"){
				Debug.Log("player found");
				enemyRigidBody.AddForce(directionFacing);
			}
		}
	}
}
