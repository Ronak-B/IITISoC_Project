using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;

    public int currentHealth;
    public Image damageImage;
    public Slider slider;
    public AudioClip deathClip;
    public Color flashColor = new Color(1f, 0f, 0f, 0.1f);
    public float flashTime = 5f;

    Animator anim;
    PlayerMovement playerMovement;
    AudioSource audio;
    PlayerShooting playerShooting;
    bool IsDead;
    bool damaged;

    public int getCurrentHealth()
    {
        return currentHealth;
    }

    private void Awake()
    {
        playerShooting = GetComponentInChildren<PlayerShooting>();
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        audio = GetComponent<AudioSource>();
        IsDead = false;
        damaged = false;
        currentHealth = maxHealth;
    }

    void Update()
    {
        if(damaged)
        {
            damageImage.color = flashColor;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashTime * Time.deltaTime);
        }
        damaged = false;
    }

    public void TakeDamage(int amount)
    {
        damaged = true;
        currentHealth -= amount;
        audio.Play();
        slider.value = currentHealth;

        if(currentHealth<=0 && !IsDead)
        {
            Death();
        }
    }

    void Death()
    {
        
        audio.clip = deathClip;
        audio.Play();
        anim.SetTrigger("Die");
        IsDead = true;
        playerMovement.enabled = false;
        
        playerShooting.DisableEffects();
        playerShooting.enabled = false;
    }


}
