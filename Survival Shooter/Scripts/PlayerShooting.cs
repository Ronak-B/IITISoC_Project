using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public int damagePerAttack=20;
    public float timeBetweenAttack=0.15f;
    public float range = 100f;

    float timer;
    Ray shootRay = new Ray();
    RaycastHit shootHit;
    int shootableMask;
    LineRenderer gunline;
    ParticleSystem gunParticles;
    AudioSource audio;
    Light gunLight;
    float effectsDisplayTime=0.2f;

    private void Awake()
    {
        gunLight = GetComponent<Light>();
        gunline = GetComponent<LineRenderer>();
        shootableMask = LayerMask.GetMask("Shootable");
        gunParticles = GetComponent<ParticleSystem>();
        audio = GetComponent<AudioSource>();
        
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if(Input.GetButton("Fire1") && timer>=timeBetweenAttack)
        {
            Shoot();
        }

        if(timer>=timeBetweenAttack*effectsDisplayTime)
        {
            DisableEffects();
        }
    }

    public void DisableEffects()
    {
        gunLight.enabled = false;
        gunline.enabled = false;
    }

    void Shoot()
    {
        timer = 0f;
        audio.Play();
        gunLight.enabled = true;

        gunParticles.Stop();
        gunParticles.Play();

        gunline.enabled = true;
        gunline.SetPosition(0, transform.position);

        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;

        if (Physics.Raycast(shootRay, out shootHit, range, shootableMask))
        {
            EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damagePerAttack, shootHit.point);
            }
            gunline.SetPosition(1, shootHit.point);
        }
        else
        {
            gunline.SetPosition(1, shootRay.origin + shootRay.direction * range);
        }
    }
}






