using UnityEngine;
using UnityEngine.Events;

public class GUIManager : MonoBehaviour {

    [SerializeField]
    private MainMenu menu;

	private static GUIManager instance;

    private void Awake() {
		if (!menu) {
			Debug.LogError("You've forgotten to assign menu parameter to GUIManager script");
		}

        if (instance == null) {
            instance = this;
        } else if (instance != this) {
            Destroy(gameObject);
        }
	}

    public static void StartGame(UnityAction restartAction) {
        instance.menu.SetRestartAction(restartAction);
        instance.menu.gameObject.SetActive(false);
    }

    public static void EndGame(int points) {
        instance.menu.UpdatePoints(points);
        instance.menu.gameObject.SetActive(true);
    }

    public static void UpdateTimer() {
        
    }

    public static void UpdatePoints(int points) {}
}
