using UnityEngine;
using UnityEngine.Events;

public class GUIManager : MonoBehaviour {

    [SerializeField]
    private MainMenu menu;
    [SerializeField]
    private HUD hud;

	private static GUIManager instance;

    private void Awake() {
		if (!menu || !hud) {
			Debug.LogError("You've forgotten to assign parameters to GUIManager script");
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
        instance.hud.gameObject.SetActive(true);
    }

    public static void EndGame(int points) {
        instance.menu.UpdatePoints(points);
        instance.menu.gameObject.SetActive(true);
        instance.hud.gameObject.SetActive(false);
    }

    public static void UpdateTimer(int time) {
        instance.hud.UpdateTimer(time);
    }

    public static void UpdatePoints(int points) {
        instance.hud.UpdatePoints(points);
    }
}
