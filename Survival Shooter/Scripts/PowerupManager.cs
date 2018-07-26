using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour {

    FireratePickup firerateRef;
    InvinciblePowerUp healthRef;
    public PlayerMovement playerMovement;
    public int size;
    public Transform[] Spwanpoints;
    public GameObject healthPowerup;
    public GameObject fireratePowerup;
    private void Awake()
    {
        firerateRef = GameObject.FindWithTag("Firerate").GetComponent<FireratePickup>();
        healthRef = GameObject.FindWithTag("Health").GetComponent<InvinciblePowerUp>();
        StartCoroutine(SpawnPowerup());
    }


    IEnumerator SpawnPowerup()
    {
        while (true)
        {
            int k = Random.Range(0, size);
            int i = Random.Range(0, 2);
            if(i==0)
                Instantiate(fireratePowerup, Spwanpoints[k].position, Spwanpoints[k].rotation);
            else Instantiate(healthPowerup, Spwanpoints[k].position, Spwanpoints[k].rotation);

            yield return new WaitForSeconds(10f);
        }
    }
}
