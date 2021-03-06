﻿using UnityEngine;

public class Bubble : MonoBehaviour {

	[SerializeField]
	private float minSize = 1F;
	[SerializeField]
	private float maxSize = 5f;
	[SerializeField]
	private float minSpeed = 0.5F;
	[SerializeField]
	private float maxSpeed = 1f;
	[SerializeField]
	private int minCost = 1;
	[SerializeField]
	private int maxCost = 10;

	private float size;
	private float speed;
	private int cost;
	private SpriteRenderer spriteRenderer;
		
	private void Awake() {
		spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

		if (!spriteRenderer) {
			Debug.LogError("Object with Bubble script should have a SpriteRenderer component");
		}
	}

	private void Update() {
		gameObject.transform.Translate(Vector2.up * speed * Time.deltaTime);
	}

	void OnBecameInvisible() {
        Destroy(gameObject);
    }

	public void Init() {
		// Set random size
		float scale = Random.Range(minSize, maxSize);
		gameObject.transform.localScale = new Vector2(scale, scale);

		// Calculate multiplier for speed and cost
		float multiplier = 1 - ((scale - minSize) / (maxSize - minSize));

		// Set speed and cost
		speed = minSpeed + multiplier * (maxSpeed - minSpeed) + TimeManager.GetSpeedAcceleration();
		cost = (int) System.Math.Round( minCost + multiplier * (maxCost - minCost) );

		// Set random color
		Color color = Random.ColorHSV(0f, 1f, 0f, 1f, 0.8f, 1f, 1f, 1f);
		spriteRenderer.color = color;
	}

	public Vector2 CalculatePosition() {
		float spriteRadius = spriteRenderer.bounds.size.x / 2;
		Vector2 leftBottomLimit = Camera.main.ScreenToWorldPoint( new Vector2(0, 0) );
		Vector2 rightBottomLimit = Camera.main.ScreenToWorldPoint( new Vector2(Screen.width, 0) );

		float leftPosLimit = leftBottomLimit.x + spriteRadius;
		float rightPosLimit = rightBottomLimit.x - spriteRadius;
		float topPosLimit = leftBottomLimit.y - spriteRadius;
		Vector2 position = new Vector2(Random.Range(leftPosLimit, rightPosLimit), topPosLimit);

		return position;
	}

	public int Pop() {
		Destroy(gameObject);
		return cost;
	}
}