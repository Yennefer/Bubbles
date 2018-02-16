using UnityEngine;

public class GameManager : MonoBehaviour {

	[SerializeField]
	private Spawner spawner;

	private static GameManager gameManager;
	private static GameManager instance {
		get {
			if (gameManager == null) {
				gameManager = FindObjectOfType<GameManager>();

				if (gameManager == null) {
					Debug.LogError ("There needs to be one GameManager script on a GameObject in scene");
				}
			}
			return gameManager;
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
				SpawnableObject so = hit.collider.gameObject.GetComponent<SpawnableObject>();

				if (so != null) {
    				Debug.Log("I get " + so.Pop() + " points");
				}
			}
		}
	}

	private void StartGame() {
		TimeManager.instance.StartGameTime(SecondUpdate, FinishGame);
		spawner.StartSpawn();
	}

	private void SecondUpdate() {

	}

	private void FinishGame() {
		spawner.StopSpawn();
	}
}