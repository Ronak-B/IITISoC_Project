using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireratePickup : MonoBehaviour {

    public float duration = 20f;
    public Text text;
    private void Awake()
    {
        text = GameObject.FindWithTag("Notification").GetComponent<Text>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            StartCoroutine(Notify());
            StartCoroutine(SpeedUp(other));
            
        }
    }

    IEnumerator Notify()
    {
        text.text = "Fire  Rate  Increased  !!";
        yield return new WaitForSeconds(1f);
        text.text = "";
    }
    IEnumerator SpeedUp(Collider player)
    {
        Debug.Log("picked");
        GetComponent<Animator>().enabled = false;
        GetComponentInChildren<MeshRenderer>().enabled = false;
        PlayerShooting playerShooting = player.GetComponentInChildren<PlayerShooting>();
        playerShooting.timeBetweenAttack = 0.05f;
        GetComponentInChildren<Light>().enabled = false;
        
        yield return new WaitForSeconds(duration);
        Debug.Log("c1");
        playerShooting.timeBetweenAttack = 0.10f;
        Destroy(gameObject);
    }
}
