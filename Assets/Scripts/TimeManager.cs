using UnityEngine;
using UnityEngine.Events;

public class TimeManager : MonoBehaviour {

	private static TimeManager timeManager;
	public static TimeManager instance {
		get {
			if (timeManager == null) {
				timeManager = FindObjectOfType<TimeManager>();

				if (timeManager == null) {
					Debug.LogError ("There needs to be one TimeManager script on a GameObject in scene");
				}
			}
			return timeManager;
		}
	}

	[SerializeField]
	private int gameDurationInSec = 60;
	[SerializeField]
	private float speedAccelerationFactor = 0.2F;

	private float _speedAcceleration = 0F;
	private bool gamePLaying = false;
	private float timeLeft = 1F;
	private Timer gameTimer;
	private UnityAction timeRanOutCallback;
	private UnityAction secondPassedCallback;

	public float speedAcceleration { get { return _speedAcceleration; } }

	private void Awake() {
		gameTimer = Timer.AddAsComponent(gameObject, TimeRanOut);
	}

	private void Update() {
		if (gamePLaying) {
			timeLeft -= Time.deltaTime;
    		if (timeLeft <= 0) {
    			SecondPassed();
				timeLeft = 1F;
    		}
		}
	}

	public void StartGameTime(UnityAction secondPassedCallback, UnityAction timeRanOutCallback) {
		this.timeRanOutCallback = timeRanOutCallback;
		this.secondPassedCallback = secondPassedCallback;
		gameTimer.StartTimer(gameDurationInSec);
		gamePLaying = true;
	}
	
	public void TimeRanOut() {
		gamePLaying = false;
		gameTimer.StopTimer();
		timeRanOutCallback.Invoke();
	}

	public void SecondPassed() {
		_speedAcceleration += speedAccelerationFactor;
		secondPassedCallback.Invoke();
	}
}
