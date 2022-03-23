using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityCollectableScript : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision is CapsuleCollider2D)
           {
            AudioManager.PlayAudio(AudioClipName.PowerPickup);
                FindObjectOfType<SpeciaAbilityManageScript>().AddSpecialAbilityCount();
                Destroy(gameObject);

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
