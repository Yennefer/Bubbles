using UnityEngine;

public class Spawner : MonoBehaviour {

	[SerializeField]
	private GameObject bubblePrefab;
	[SerializeField]
	private float minSpawnTime = 0.3F;
	[SerializeField]
	private float maxSpawnTime = 1F;

	private Timer spawnTimer;

	private void Awake() {
		if (!bubblePrefab) {
			Debug.LogError("You've forgotten to assign bubblePrefab parameter to Spawner script");
		} else if (bubblePrefab.GetComponent<Bubble>() == null) {
			Debug.LogError("bubblePrefab should have a Bubble component");
		}

		spawnTimer = Timer.AddAsComponent(gameObject, SpawnBubble);
	}

	public void StartSpawn() {
		SpawnBubble();
	}

	public void StopSpawn() {
		spawnTimer.StopTimer();
		ClearSpawnedBubbles();
	}

	public void SpawnBubble() {
		Bubble bubble = Instantiate(bubblePrefab).GetComponent<Bubble>();
		bubble.Init();

		bubble.gameObject.transform.position = bubble.CalculatePosition();
		bubble.gameObject.transform.parent = this.gameObject.transform;

		spawnTimer.StartTimer( GetRandomTime() );
	}

	private float GetRandomTime() {
		return Random.Range(minSpawnTime, maxSpawnTime);
	}

	private void ClearSpawnedBubbles() {
		foreach(Transform child in transform) {
   			Destroy(child.gameObject);
		}	   
	}
}