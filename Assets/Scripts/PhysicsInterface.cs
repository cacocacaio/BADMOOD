using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface PhysicsInterface
{
	Vector2 Move(float x, float y);

	Vector2 Move(Vector2 v);

	Vector2 ForceMove(float x, float y, float speed);

	Vector2 ForceMove(Vector2 v, float speed);

	void GroundCheckIn();

	void GroundCheckOut();

	void CeilingCheckIn();

	void CeilingCheckOut();

	void Invoke(string name);
}
