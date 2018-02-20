using UnityEngine;
using UnityEngine.Events;

public class GUIManager : MonoBehaviour {

    [SerializeField]
    private MainMenu menu;

	private static GUIManager guiManager;
	public static GUIManager instance {
		get {
			if (guiManager == null) {
				guiManager = FindObjectOfType<GUIManager>();

				if (guiManager == null) {
					Debug.LogError ("There needs to be one GUIManager script on a GameObject in scene");
				}
			}
			return guiManager;
		}
	}

    private void Awake() {
		if (!menu) {
			Debug.LogError("You've forgotten to assign menu parameter to GUIManager script");
		}
	}

    public void StartGame(UnityAction restartAction) {
        menu.SetRestartAction(restartAction);
        menu.gameObject.SetActive(false);
    }

    public void EndGame(int points) {
        menu.UpdatePoints(points);
        menu.gameObject.SetActive(true);
    }
}
