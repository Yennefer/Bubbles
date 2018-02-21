using UnityEngine;

public class GameManager : MonoBehaviour {

	[SerializeField]
	private Spawner spawner;

	private int _points = 0;
	private int points {
		get {
			return _points;
		}
		set {
			_points = value;
			PointsUpdate();
		}
	}

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
				Bubble bubble = hit.collider.gameObject.GetComponent<Bubble>();

				if (bubble != null) {
    				points += bubble.Pop();
				}
			}
		}
	}

	private void StartGame() {
		InitGame();

		TimeManager.StartGame(TimerUpdate, EndGame);
		GUIManager.StartGame(StartGame);
		GUIManager.UpdateTimer(TimeManager.GetGameTimeLeft());

		spawner.StartSpawn();
	}

	private void InitGame() {
		points = 0;
	}

	private void TimerUpdate() {
		GUIManager.UpdateTimer(TimeManager.GetGameTimeLeft());
	}

	private void PointsUpdate() {
		GUIManager.UpdatePoints(points);
	}

	private void EndGame() {
		spawner.StopSpawn();

		GUIManager.EndGame(points);
	}
}