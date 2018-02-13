using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	[SerializeField]
	private GameObject spawnPrefab;
	[SerializeField]
	private float minSpawnTime = 0.3F;
	[SerializeField]
	private float maxSpawnTime = 1F;

	private Timer spawnTimer;

	private void Awake() {
		if (!spawnPrefab) {
			Debug.LogError("You've forgotten to assign spawnPrefab parameter to Spawner script");
		}
	}

	private void Start() {
		spawnTimer = Timer.AddAsComponent(gameObject, SpawnPrefab);
	}

	public void StartSpawn () {
		SpawnPrefab();
	}

	public void StopSpawn() {
		spawnTimer.StopTimer();
	}

	public void SpawnPrefab() {
		Vector2 position = Camera.main.ScreenToWorldPoint( new Vector2(Random.Range(0, Screen.width), 0) );

		GameObject go = Instantiate(spawnPrefab, position, Quaternion.identity);
		go.transform.parent = gameObject.transform;

		SpawnableObject so = go.GetComponent<SpawnableObject>();
		if (so == null) {
			Debug.LogError("spawnPrefab should have a component inherited from SpawnableObject");
			return;
		}
		so.Init();

		spawnTimer.StartTimer( GetRandomTime() );
	}

	private float GetRandomTime() {
		return Random.Range(minSpawnTime, maxSpawnTime);
	}
}