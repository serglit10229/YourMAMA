using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHoles : MonoBehaviour {

	public float damage = 10f;
	public float range = 100f;
	public float fireRate = 15f;
	public float impactForce = 30f;
	public GameObject gun;

	public Camera fpsCam;
	public ParticleSystem muzzleFlash;
	public GameObject impactEffect;
	public GameObject[] bulletTex;

	private float nextTimeToFire = 0f;

	void Update()
	{

		if(Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
		{
			nextTimeToFire = Time.time + 1f/fireRate;
			gun.GetComponent<AnimationController>().anim["Fire"].speed = fireRate;
			Shoot();
		}

	}

	void Shoot()
	{
		gun.GetComponent<Animation>().Play("Fire");
		muzzleFlash.Play();
		Vector3 fwd = transform.TransformDirection(Vector3.forward);
		RaycastHit hit;
		if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
		{
			HealthDestroy target = hit.transform.GetComponent<HealthDestroy>();
			if(target != null)
			{
				target.TakeDamage(damage);
			}

			if(hit.rigidbody != null)
			{
				hit.rigidbody.AddForce(-hit.normal * impactForce);
			}

			GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
			Destroy(impactGO, 2f);
			Vector3 point = new Vector3(0.01f, 0.01f, 0.01f);
            GameObject bulletHole = Instantiate(bulletTex[0], hit.point + hit.normal*0.01f, Quaternion.FromToRotation(Vector3.up, hit.normal));
            bulletHole.transform.parent = hit.transform;
            //gun.GetComponent<Animation>().Stop();
            //muzzleFlash.Stop();
		}
		gun.GetComponent<Animation>().CrossFade("Idle");
	}
	/*
    public GameObject[] bulletTex;
	// Update is called once per frame
	void Update () {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        RaycastHit hit;
        Debug.DrawRay(transform.position, fwd * 10, Color.green);

        if (Input.GetMouseButtonDown(0) && Physics.Raycast(transform.position, fwd, out hit, 10))
        {
            Vector3 point = new Vector3(0.01f, 0.01f, 0.01f);
            Instantiate(bulletTex[0], hit.point + hit.normal*0.01f, Quaternion.FromToRotation(Vector3.up, hit.normal));

            Debug.Log(hit.normal);
        }
	}
	*/
}
