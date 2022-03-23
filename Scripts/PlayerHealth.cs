using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    int playerHealth = 100;

    [SerializeField]
    Slider healthSlider;

    Animator animator;

    bool isAlive = true;
    bool playerDead = false;

   
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        healthSlider.value = playerHealth;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int GetPlayerHealth
    {
        get { return playerHealth; }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        EnemyHits enemyHits = collision.gameObject.GetComponent<EnemyHits>();
        if (enemyHits && !playerDead)
        {
            AudioManager.PlayAudio(AudioClipName.PlayerPain);
            DecreaseHealth(enemyHits.GetEnemyHitPoints);
            
        }
    }

    public void IncreaseHealthPlayer(int amountToIncrease)
    {
      
        playerHealth += amountToIncrease;
        healthSlider.value = playerHealth;
        if (playerHealth >= 100)
        {
            playerHealth = 100;
            healthSlider.value = playerHealth;
        }

    }
    private void DecreaseHealth(int enemyHitPoints)
    {
        if (playerHealth > 1)
        {
            animator.SetTrigger("IsHurt");
        }

        
        playerHealth -= enemyHitPoints;
        healthSlider.value = playerHealth;
        
        if(playerHealth<=0)
        {
            playerDead = true;
            isAlive = false;
            AudioManager.PlayAudio(AudioClipName.PlayerDie);
            Time.timeScale = 0.5f;
            animator.SetTrigger("IsDead");
            StartCoroutine(DieDelay());
            
        }
       
    }
       
    IEnumerator DieDelay()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public bool GetIsAliveValue
    {
        get { return isAlive; }
    }
}
