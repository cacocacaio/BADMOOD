using UnityEngine;

public class CharacterPhysics : MonoBehaviour, PhysicsInterface
{
	public float max_speed;
	public float max_fall_speed;
	public float acceleration;
	public float air_acceleration;
	public float jump_speed;

	private bool grounded;
	private bool control;
	private bool ceiling;
	private float can_jump = 1;

	private Vector2 v;

	public Vector2 Move(float x, float y)
	{
		if (y == 0 && !grounded) can_jump = 0;
		if (control)
		{
			v.x = Mathf.Lerp(v.x, x * max_speed, acceleration);
			v.y += can_jump * y * jump_speed;
		}
		else
		{
			v.x = Mathf.Lerp(v.x, 0, 0.1f);
		}
		if (Mathf.Abs(v.x) > max_speed) v.x = Mathf.Lerp(v.x, Mathf.Sign(v.x) * max_speed, 0.2f);
		if (!grounded && v.y>-max_fall_speed) v.y -= Mathf.Sqrt(Mathf.Abs(v.y)) + 4;
		if (v.y < -max_fall_speed) v.y += Mathf.Sqrt(Mathf.Abs(v.y)) + 4;
		return v;
	}

	public Vector2 Move(Vector2 v)
	{
		return Move(v.x, v.y);
	}

	public Vector2 ForceMove(float x, float y, float speed)
	{
		v.x = x*speed;
		v.y = y*speed;
		return v;
	}

	public Vector2 ForceMove(Vector2 v, float speed)
	{
		return ForceMove(v.x, v.y, speed);
	}

	public void GroundCheckIn()
	{
		grounded = true;
		can_jump = 1;
		if (control) v.y = 0;
		else v.y = -v.y;
	}

	public void GroundCheckOut()
	{
		grounded = false;
	}

	public void CeilingCheckIn()
	{
		ceiling = true;
		v.y = 0;
	}

	public void CeilingCheckOut()
	{
		ceiling = false;
	}

	public void Invoke(string name)
	{
		Invoke(name, 0f);
	}
}
