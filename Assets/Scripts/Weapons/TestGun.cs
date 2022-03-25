using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGun : MonoBehaviour, WeaponInterface
{
	public float recoil;
	public float special_recoil;
	public float cooldown;
	public Transform projectile_spawn_position;

	public GameObject projectile;
	public GameObject special_projectile;

	private Transform angle;
	private float cool_countdown;

	private void Start()
	{
		angle = GetComponentInParent<Transform>();
	}

	private void FixedUpdate()
	{
		cool_countdown -= cool_countdown > 0 ? 1 : 0;
	}

	public float Shoot(float r)
	{
		if (cool_countdown > 0) return r;
		GameObject p = Instantiate(projectile, projectile_spawn_position.position, Quaternion.identity) as GameObject;
		p.GetComponent<ProjectileInterface>().angle = GetComponentInParent<Transform>().rotation.eulerAngles.z;
		cool_countdown = cooldown;
		return recoil + r;
	}

	public float SpecialShoot(float r)
	{
		return special_recoil + r;
	}
}
