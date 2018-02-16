using UnityEngine;

public class GameManager : MonoBehaviour {

	[SerializeField]
	private Spawner spawner;
	[SerializeField]
	private int gameDurationInSec = 60;
	[SerializeField]
	private int speedAccelerationFactor = 10;

	private Timer gameTimer;

	private void Awake() {
		if (!spawner) {
			Debug.LogError("You've forgotten to assign spawner parameter to GameManager script");
		}

		gameTimer = Timer.AddAsComponent(gameObject, EndGame);
	}

	private void Start () {
		StartGame();
	}

	private void Update() {
		if (Input.GetMouseButtonDown(0)) {
			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

			if (hit.collider) {
				SpawnableObject so = hit.collider.gameObject.GetComponent<SpawnableObject>();

				if (so != null) {
    				Debug.Log("I get " + so.Pop() + " points");
				}
			}
		}
	}

	private void StartGame() {
		gameTimer.StartTimer(gameDurationInSec);
		spawner.StartSpawn();
	}

	private void EndGame() {
		spawner.StopSpawn();
		gameTimer.StopTimer();
	}
}