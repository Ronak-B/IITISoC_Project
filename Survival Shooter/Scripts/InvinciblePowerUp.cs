using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvinciblePowerUp : MonoBehaviour {
    public PlayerHealth playerHealth;
    public Text text;
    private Slider slider;

    private void Start()
    {
        slider = GameObject.FindWithTag("HUD").GetComponentInChildren<Slider>();
        text = GameObject.FindWithTag("Notification").GetComponent<Text>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Notify());
           Health(other);
        }
    }
    IEnumerator Notify()
    {
        text.text = "Health  Restored  !!";
        yield return new WaitForSeconds(1f);
        text.text = "";
    }
    public void Health(Collider other)
    {
        GetComponent<Animator>().enabled = false;
        playerHealth = other.GetComponent<PlayerHealth>();
        playerHealth.currentHealth = 100;
        slider.value = 200;
        GetComponentInChildren<Light>().enabled = false;
        Destroy(gameObject);    
    }
}
