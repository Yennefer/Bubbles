using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour {

	private float speed = 0.5F;
		
	private void Update () {
		gameObject.transform.Translate(Vector2.up * speed * Time.deltaTime);
	}
}
