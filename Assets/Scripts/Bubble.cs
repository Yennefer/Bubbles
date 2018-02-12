using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour {

	[SerializeField]
	private float speed = 0.5F;
	[SerializeField]
	private int cost = 10;
		
	private void Update () {
		gameObject.transform.Translate(Vector2.up * speed * Time.deltaTime);
	}

	public int Pop() {
		Destroy(gameObject);
		return cost;
	}
}
