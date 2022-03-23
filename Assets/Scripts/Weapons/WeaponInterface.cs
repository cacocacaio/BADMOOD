using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInterface : MonoBehaviour
{
	public float recoil;
	public float special_recoil;
	public float cooldown;
	public Vector3 projectile_spawn_position;

	public GameObject projectile;
	public GameObject special_projectile;

	private Transform angle;

    // Start is called before the first frame update
    void Start()
    {
		angle = GetComponentInParent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public float Shoot(float r)
	{
		return recoil + r;
	}

	public float SpecialShoot(float r)
	{
		return recoil + r;
	}
}
