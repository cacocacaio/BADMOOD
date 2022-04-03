using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private float jump_sustain;
	[SerializeField] private float dash_cooldown;
	[SerializeField] private float dash_count;

	public CursorControll cursor;
	public Transform body;
	public AimScript weapon;
	private Rigidbody2D rb2d;
	private PhysicsInterface p;
	
	private bool back;
	private float jump_sustained;
	private float dash_recovery;
	private float dash_stored;
	private float x = 0, y = 0;

	// Start is called before the first frame update
	void Awake()
    {
		rb2d = GetComponent<Rigidbody2D>();
		p = GetComponent<PhysicsInterface>();
		jump_sustained = jump_sustain;
		back = false;
		dash_recovery = 0;
		dash_stored = dash_count;
    }

    // Update is called once per frame
    void FixedUpdate()
	{
		body.localScale = new Vector3(back?1:-1, 1, 1);

		if (y == 1 && jump_sustained > 0)
		{
			jump_sustained--;
		}
		else if (jump_sustained <= 0)
		{
			jump_sustained = jump_sustain;
			y = 0;
		}

		if (dash_recovery == 0)
		{
			if ()
			{

			}
		}
		else
		{
			dash_recovery--;
		}

		rb2d.velocity = p.Move(x, y);
		if (rb2d.velocity.x > 0) back = false;
		else if (rb2d.velocity.x < 0) back = true;
	}

	void OnDashUp()
	{

	}

	void OnDashDown()
	{

	}

	void OnDashRight()
	{

	}

	void OnDashLeft()
	{

	}

	void OnJumpOn()
	{
		y = 1;
	}

	void OnJumpOff()
	{
		y = 0;
	}

	void OnMove(InputValue v)
	{
		if (x != 2) x = Mathf.Clamp(v.Get<Vector2>().x, -1, 1);
	}

	void OnLook(InputValue v)
	{
		cursor.OnLook(v.Get<Vector2>());
	}

	void OnFire()
	{
		weapon.Shoot();
	}
}
