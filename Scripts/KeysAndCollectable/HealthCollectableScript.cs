using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectableScript : MonoBehaviour
{
    [SerializeField]
    int amountOfHealthToIncrease;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision is CapsuleCollider2D)
        {
            AudioManager.PlayAudio(AudioClipName.HealthPickup);
            collision.gameObject.GetComponent<PlayerHealth>().IncreaseHealthPlayer(
                amountOfHealthToIncrease);
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
