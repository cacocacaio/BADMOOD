using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimScript : MonoBehaviour
{
	public GameObject weapon;
	public Transform cursor;
	public Transform center;
	public float recover_speed;

	private float angle;
	private bool back;

    void Start()
    {
        
    }

	private void FixedUpdate()
	{
		angle = (Mathf.Rad2Deg * Mathf.Atan2((center.position.y - cursor.position.y), (center.position.x - cursor.position.x)));
	}

	void Update()
    {
		transform.eulerAngles = Vector3.forward * angle;
    }
}
