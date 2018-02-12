using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour {

	private float timePeriod = 0F;
	private float timeLeft = 0F;
	private UnityAction callback;
	private bool ticking = false;

	public static Timer AddAsComponent(GameObject gameObject, UnityAction callback) {
    	Timer timer = gameObject.AddComponent<Timer>();
    	timer.Init(callback);
    	return timer;
	}

	private void Init(UnityAction callback) {
		this.callback = callback;
	}

	public void StartTimer(float timePeriod) {
		this.timePeriod = timePeriod;
		this.timeLeft = timePeriod;
		ticking = true;
	}

	public void StopTimer() {
		ticking = false;
	}

	private void Update() {
		if (ticking) {
			timeLeft -= Time.deltaTime;
    		if (timeLeft <= 0) {
    			callback();
				timeLeft = timePeriod;
    		}
		}
	}
}