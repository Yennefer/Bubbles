using UnityEngine;

public class GameManager : MonoBehaviour {

	[SerializeField]
	private Spawner spawner;

	private int points = 0;

	private void Awake() {
		if (!spawner) {
			Debug.LogError("You've forgotten to assign spawner parameter to GameManager script");
		}
	}

	private void Start() {
		StartGame();
	}

	private void Update() {
		if (Input.GetMouseButtonDown(0)) {
			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

			if (hit.collider) {
				SpawnableObject so = hit.collider.gameObject.GetComponent<SpawnableObject>();

				if (so != null) {
    				points += so.Pop();
				}
			}
		}
	}

	private void StartGame() {
		points = 0;
		TimeManager.instance.StartGameTime(SecondUpdate, FinishGame);
		GUIManager.instance.StartGame(StartGame);
		spawner.StartSpawn();
	}

	private void SecondUpdate() {

	}

	private void FinishGame() {
		spawner.StopSpawn();
		GUIManager.instance.EndGame(points);
	}
}