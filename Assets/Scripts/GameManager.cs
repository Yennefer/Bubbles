using UnityEngine;

public class GameManager : MonoBehaviour {

	[SerializeField]
	private Spawner spawner;

	private void Awake() {
		if (!spawner) {
			Debug.LogError("You've forgotten to assign spawner parameter to GameManager script");
		}
	}

	private void Start () {
		StartGame();
	}

	private void Update() {
		if (Input.GetMouseButtonDown(0)) {
			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

			if (hit.collider) {
				Bubble bubble = hit.collider.gameObject.GetComponent<Bubble>();

				if (bubble) {
    				Debug.Log("I get " + bubble.Pop() + " points");
				}	
			}
		}	
	}

	private void StartGame() {
		spawner.StartSpawn();
	}
}
