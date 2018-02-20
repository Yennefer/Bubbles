using UnityEngine;
using UnityEngine.Events;

public class TimeManager : MonoBehaviour {

	[SerializeField]
	private int gameDurationInSec = 60;
	[SerializeField]
	private float speedAccelerationFactor = 0.2F;

	private static TimeManager instance;

	private float speedAcceleration = 0F;
	private bool gamePlaying = false;
	private float timeLeft = 1F;
	private Timer gameTimer;
	private UnityAction endGameCallback;
	private UnityAction timerUpdateCallback;

	private void Awake() {
		gameTimer = Timer.AddAsComponent(gameObject, EndGame);

		if (instance == null) {
            instance = this;
        } else if (instance != this) {
            Destroy(gameObject);
        }
	}

	private void Update() {
		if (gamePlaying) {
			timeLeft -= Time.deltaTime;
    		if (timeLeft <= 0) {
    			TimerUpdate();
				timeLeft = 1F;
    		}
		}
	}

	private void EndGame() {
		gamePlaying = false;
		gameTimer.StopTimer();
		endGameCallback.Invoke();
	}

	private void TimerUpdate() {
		speedAcceleration += speedAccelerationFactor;
		timerUpdateCallback.Invoke();
	}

	private void StartTimeManagment(UnityAction timerUpdateCallback, UnityAction endGameCallback) {
		this.endGameCallback = endGameCallback;
		this.timerUpdateCallback = timerUpdateCallback;
		gameTimer.StartTimer(gameDurationInSec);
		gamePlaying = true;
	}

	public static void StartGame(UnityAction timerUpdateCallback, UnityAction endGameCallback) {
		instance.StartTimeManagment(timerUpdateCallback, endGameCallback);
	}
	
	public static float GetSpeedAcceleration() {
		return instance.speedAcceleration;
	}
}
