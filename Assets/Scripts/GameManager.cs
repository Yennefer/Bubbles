using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	[SerializeField]
	private BubbleSpawner spawner;

	private void Awake() {
		if (!spawner) {
			Debug.LogError("You've forgotten to assign spawner parameter to GameManager script");
		}
	}

	private void Start () {
		StartGame();
	}

	private void StartGame() {
		spawner.StartSpawn();
	}
}
