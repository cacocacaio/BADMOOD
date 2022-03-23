using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private float speed;
	[SerializeField] private float air_speed;
	[SerializeField] private float jump_speed;
	[SerializeField] private float jump_sustain;
	[SerializeField] private float term_vel;

	public CursorControll cursor;
	public Transform body;
	private Rigidbody2D rb2d;

	private bool jump;
	private bool grounded;
	private bool ceiling;
	private bool back;
	private float jump_sustained;
	private float x_speed = 0, y_speed = 0;

	// Start is called before the first frame update
	void Awake()
    {
		rb2d = GetComponent<Rigidbody2D>();
		jump = false;
		jump_sustained = jump_sustain;
		back = false;
    }

    // Update is called once per frame
    void FixedUpdate()
	{
		body.localScale = new Vector3(back?1:-1, 1, 1);

		if (!grounded && y_speed > term_vel)
		{
			y_speed -= (5);
		}

		if (jump && jump_sustained > 0)
		{
			y_speed = jump_speed;
			jump_sustained --;
		}

		rb2d.velocity = new Vector2(x_speed, y_speed);
    }

	void OnJump()
	{
		if (!grounded && !jump) return;
		jump = !jump;
	}

	void OnMove(InputValue v)
	{
		x_speed = v.Get<Vector2>().x * speed;
		if (x_speed > 0) back = false;
		else if (x_speed < 0) back = true;
	}

	void OnLook(InputValue v)
	{
		cursor.OnLook(v.Get<Vector2>());
	}

	void GroundCheckIn()
	{
		grounded = true;
		y_speed = 0;
		jump_sustained = jump_sustain;
	}

	void GroundCheckOut()
	{
		grounded = false;
	}

	void CeilingCheckIn()
	{
		ceiling = true;
		jump = false;
		y_speed = 0;
	}

	void CeilingCheckOut()
	{
		ceiling = false;
	}
}
