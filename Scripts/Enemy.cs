using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    int enemyHealth;

    [SerializeField]
    GameObject bloodPrefab;
    
    
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
      
      if (collision.gameObject.GetComponent<DealDamage>())
        {
            Instantiate<GameObject>(bloodPrefab, collision.gameObject.transform.position,
               Quaternion.identity);
            AudioManager.PlayAudio(AudioClipName.ArrowImpactEnemy);
            DealDamage dealDamage = collision.gameObject.GetComponent<DealDamage>();

            enemyHealth -= dealDamage.GetArrowHitPoints;
            dealDamage.KillArrow();
            if (enemyHealth <= 0)
            {
                Destroy(gameObject);
            }


        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

  
   

}
    


