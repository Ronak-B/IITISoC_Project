using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour {

    public int startingHealth=100;
    public int currenthealth;
    public AudioClip deathClip;
    public int damageAmount = 10;
    public float sinkSpeed = 2.5f;
    bool isDead;
    bool isSinking;

    CapsuleCollider capsuleCollider;
    Animator anim;
    AudioSource audio;
    ParticleSystem hitParticles;

    private void Awake()
    {
        anim=GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        hitParticles = GetComponentInChildren<ParticleSystem>();
        currenthealth = startingHealth;
        capsuleCollider = GetComponent<CapsuleCollider>();
    }

    void Update ()
    {
        if(isSinking)
        {
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
        }
		
	}

    public void TakeDamage(int amount , Vector3 hitpos)
    {
        if (isDead)
            return;
        Debug.Log("checking");
        currenthealth -= amount;
        //audio.Play();
        hitParticles.transform.position = hitpos;
        hitParticles.Play();

        if(currenthealth<=0 && !isDead)
        {
            Death();
        }
    }

    void Death()
    {
        isDead = true;
        capsuleCollider.isTrigger = true;
        audio.clip = deathClip;
        audio.Play();
        anim.SetTrigger("Die");
        Sinking();
    }   

    public void Sinking()
    {
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        isSinking = true;
        ScoreManager.score += damageAmount;
        Destroy(gameObject, 2f);
    }
}
