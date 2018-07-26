using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    public float timebetweenAttacks;
    public int attackDamage = 10;

    bool InRange;
    float timer;
    Animator anim;
    GameObject player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
	
	void Awake ()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject==player)
        {
            InRange = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.gameObject==player)
        {
            InRange = false;
        }
    }

    void Update ()
    {
        timer += Time.deltaTime;
        if(InRange && timer>=timebetweenAttacks && enemyHealth.currenthealth>0)
        {
            Attack();
        }

        if(playerHealth.getCurrentHealth()<=0)
        {
            anim.SetTrigger("PlayerDead");
        }
		
	}

    void Attack()
    {
        if (playerHealth.getCurrentHealth() > 0)
        {
            playerHealth.TakeDamage(attackDamage);
        }
        timer = 0f;
    }
}
