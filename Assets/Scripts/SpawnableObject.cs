using UnityEngine;

public interface SpawnableObject {
	void Init ();
	int Pop();
	Vector2 CalculatePosition();
}
