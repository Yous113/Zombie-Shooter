using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolScript : MonoBehaviour
{

    public float damage;
    public float range;
    public float fireRate = 15f;

    public ParticleSystem muzzleflash;

    public AudioSource shootSound;

    public Camera fpsCam;

    private float nextTimeToFire = 3f;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)            
        {
            Shoot();
            nextTimeToFire = Time.time + 1f / fireRate;
        }

    }

    void Shoot()
    {
        muzzleflash.Play();
        shootSound.Play();
        RaycastHit hit;

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            EnemyScript enemy = hit.transform.GetComponent<EnemyScript>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
    }
}