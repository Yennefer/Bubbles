using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawner : MonoBehaviour {

	[SerializeField]
	private GameObject bubblePrefab;
	[SerializeField]
	private float minTimeBtwBubbles = 0.3F;
	[SerializeField]
	private float maxTimeBtwBubbles = 1F;

	private Timer spawnTimer;

	private void Awake() {
		if (!bubblePrefab) {
			Debug.LogError("You've forgotten to assign bubblePrefab parameter to BubbleSpawner script");
		}
	}

	private void Start() {
		spawnTimer = Timer.AddAsComponent(gameObject, SpawnBubble);
	}

	public void StartSpawn () {
		SpawnBubble();
	}

	public void StopSpawn() {
		spawnTimer.StopTimer();
	}

	public void SpawnBubble() {
		Vector2 bubblePosition = Camera.main.ScreenToWorldPoint( new Vector2(Random.Range(0, Screen.width), 0) );

		GameObject bubble = Instantiate(bubblePrefab, bubblePosition, Quaternion.identity);
		bubble.transform.parent = gameObject.transform;
		spawnTimer.StartTimer( GetRandomTime() );
	}

	private float GetRandomTime() {
		return Random.Range(minTimeBtwBubbles, maxTimeBtwBubbles);
	}
}