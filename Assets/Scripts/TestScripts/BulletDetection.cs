using UnityEngine;
using System.Collections;

public class BulletDetection : MonoBehaviour {

	public void OnCollisionEnter(Collision other){
		if (other.gameObject.name == "TestBullet(Clone)") {
			Destroy (this.gameObject);
		} else if (other.gameObject.name == "TestCharacter") {
			Debug.Log("player is touching an enemy");
		}
	}

}
