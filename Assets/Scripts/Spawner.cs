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
			Debug.LogError("You've forgotten to assign spawnObject parameter to Spawner script");
		} else if (spawnPrefab.GetComponent<SpawnableObject>() == null) {
			Debug.LogError("spawnPrefab should have a component that implement SpawnableObject");
		}

		spawnTimer = Timer.AddAsComponent(gameObject, SpawnPrefab);
	}

	public void StartSpawn () {
		foreach(Transform child in transform) {
    		Destroy(child.gameObject);
		}
		
		SpawnPrefab();
	}

	public void StopSpawn() {
		spawnTimer.StopTimer();
	}

	public void SpawnPrefab() {
		GameObject go = Instantiate(spawnPrefab);
		SpawnableObject so = go.GetComponent<SpawnableObject>();
		so.Init();

		go.transform.position = so.CalculatePosition();
		go.transform.parent = gameObject.transform;

		spawnTimer.StartTimer( GetRandomTime() );
	}

	private float GetRandomTime() {
		return Random.Range(minSpawnTime, maxSpawnTime);
	}
}