using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour {
	public float spawnTime = 15f;
	public float spawnDelay = 9f;
	public GameObject[] enemies;		

	// Use this for initialization
	void Start () {
		InvokeRepeating("E_1", spawnDelay, spawnTime);
	}

	void E_1 () {
		int enemyIndex = Random.Range(0, enemies.Length);
		Instantiate(enemies[enemyIndex], transform.position, transform.rotation);

		foreach(ParticleSystem p in GetComponentsInChildren<ParticleSystem>())
		{
			p.Play();
		}
	}
}
