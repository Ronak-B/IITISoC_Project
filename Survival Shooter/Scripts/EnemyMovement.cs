using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    NavMeshAgent nav;
    Transform target;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    private void Start()
    {

        enemyHealth = GetComponent<EnemyHealth>();
        target = GameObject.FindWithTag("Player").transform;
        playerHealth = target.GetComponent<PlayerHealth>();
        nav = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        if (playerHealth.getCurrentHealth() > 0 && enemyHealth.currenthealth > 0)
        {
            nav.speed = 0.5f;
            nav.SetDestination(target.position);
        }
        else
        {
            nav.enabled = false;
        }
    }


}
