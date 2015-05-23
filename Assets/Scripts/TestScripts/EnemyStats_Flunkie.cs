using UnityEngine;
using System.Collections;

public class EnemyStats_Flunkie : EnemyStats {

	// Use this for initialization
	public override void Start () {
		health = 3;
	
	}
	
	// Update is called once per frame
	public override void Update () {
		if (health <= 0) {
			Destroy (gameObject);
		}
	
	}
	public override void decreaseHealth(int x){
		health -= x;
		Debug.Log (health);
	}
}
