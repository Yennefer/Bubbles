using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class MainMenu : MonoBehaviour {

	[SerializeField]
	private Text pointsText;
	[SerializeField]
	private Button restartButton;
	
	private const string pointsTextConst = "You have collected: {0} points";

	private void Awake() {
		if (!pointsText || !restartButton) {
			Debug.LogError("You've forgotten to assign parameters to MainMenu script");
		}
	}

	public void UpdatePoints(int points) {
		pointsText.text = string.Format(pointsTextConst, points);
	}	 

	public void SetRestartAction(UnityAction restartAction) {
		restartButton.onClick.AddListener(restartAction);
	}
}
