using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour, SpawnableObject {

	[SerializeField]
	private float speed = 0.5F;
	[SerializeField]
	private int costMultiplier = 10;
	[SerializeField]
	private float minSize = 1;
	[SerializeField]
	private float maxSize = 5;

	private float size;
	private int cost;
	private SpriteRenderer spriteRenderer;
		
	private void Awake() {
		spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

		if (!spriteRenderer) {
			Debug.LogError("Object with Bubble script should have a SpriteRenderer component");
		}
	}

	private void Update () {
		gameObject.transform.Translate(Vector2.up * speed * Time.deltaTime);
	}

	public void Init() {
		float scale = Random.Range(minSize, maxSize);
		gameObject.transform.localScale = new Vector2(scale, scale);

		Color color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.8f, 1f, 1f, 1f);
		spriteRenderer.color = color;
	}

	public int Pop() {
		Destroy(gameObject);
		return cost;
	}
}
