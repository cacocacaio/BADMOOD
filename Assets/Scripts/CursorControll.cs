using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CursorControll : MonoBehaviour
{

    private Animator anim;
    public AimObject gun;

	private Vector2 cursor_pos;

    void Start()
    {
		cursor_pos = Vector2.zero;
        Cursor.visible = false;
        //anim = GetComponent<Animator>();
    }
	
    void Update()
    {

    }

    private void FixedUpdate()
    {
        transform.position = cursor_pos;
    }

	public void OnLook(Vector2 v)
	{
		cursor_pos += v;
	}
}
