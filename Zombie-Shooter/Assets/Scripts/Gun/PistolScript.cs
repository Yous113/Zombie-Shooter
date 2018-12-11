using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolScript : MonoBehaviour
{

    public float damage;
    public float range;

    public ParticleSystem Muzzleflash;

    public AudioSource shootSound;

    public Camera fpsCam;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();

        }

    }

    void Shoot()
    {
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