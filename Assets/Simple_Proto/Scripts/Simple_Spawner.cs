using UnityEngine;
using System.Collections;

public class Simple_Spawner : MonoBehaviour {

	[Tooltip("Place the game object here to be spawned")]
	public GameObject itemToSpawn;
	[Tooltip("How many should be spawned?")]
	public int numberToSpawn;
	[Tooltip("Delay between spawn waves, 0 is no waves.")]
	public float spawnWaveDelay;
	float spawnWaveTimer;

	// Use this for initialization
	void Start () {
		SpawnBatch ();
		spawnWaveTimer = spawnWaveDelay;
	}
	
	// Update is called once per frame
	void Update () {
		if (spawnWaveDelay > 0) 
		{
			spawnWaveTimer -= Time.deltaTime;
			if (spawnWaveTimer <= 0) 
			{
				SpawnBatch ();
				spawnWaveTimer = spawnWaveDelay;
			}
		}

		if (transform.childCount < numberToSpawn) {
			for (int i = 0; i < (numberToSpawn - transform.childCount); i++) {
				GameObject newObject = Instantiate (itemToSpawn, transform.position, Quaternion.identity, this.transform) as GameObject;
			}
		}

	}

	void SpawnBatch()
	{
		for (int i = 0; i < numberToSpawn; i++) {
			GameObject newObject = Instantiate (itemToSpawn, transform.position, Quaternion.identity, this.transform) as GameObject;
		}
	}
}
