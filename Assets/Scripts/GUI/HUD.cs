using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

	[SerializeField]
	private Text pointsText;
	[SerializeField]
	private Text timerText;

	private const string pointsTextConst = "Points: {0}";

	private void Awake() {
		if (!pointsText || !timerText) {
			Debug.LogError("You've forgotten to assign parameters to HUD script");
		}
	}

	public void UpdatePoints(int points) {
		pointsText.text = string.Format(pointsTextConst, points);
	}

	public void UpdateTimer(int time) {
		timerText.text = time.ToString();
	}
}