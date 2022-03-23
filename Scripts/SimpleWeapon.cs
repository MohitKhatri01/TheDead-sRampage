using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleWeapon : MonoBehaviour
{
    [SerializeField]
    GameObject bloodPrefab;
    // Start is called before the first frame update
    void Start()
    {
       
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.GetComponent<Rigidbody2D>().gravityScale = .8f;
       if(collision.gameObject.GetComponent<Zombie>())
        {
            Instantiate<GameObject>(bloodPrefab, collision.gameObject.transform.position,
                Quaternion.identity);
            Destroy(gameObject, .001f);
            AudioManager.PlayAudio(AudioClipName.ArrowImpactEnemy);
        }
        
        Destroy(gameObject, 2f);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
