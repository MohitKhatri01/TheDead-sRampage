using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHead : MonoBehaviour
{
    Rigidbody2D rigidbody;
    bool rotateAllow = false;
    [SerializeField]
    float rotationSpeed = 15f;

    [SerializeField]
    Transform CheckIfPlayerIsCloseTransform;

    int audioCounter = 0;
    
    
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        
    }

   
    private void Update()
    {
        IsAllowToRoll();
        if (rotateAllow)
        {
            if (audioCounter == 0)
            {

                AudioManager.PlayAudio(AudioClipName.ZombieHeadWakeUp);
                audioCounter++;
            }
            rigidbody.MoveRotation(rigidbody.rotation + rotationSpeed);
        }
        
    }

    private void IsAllowToRoll()
    {
       if(Physics2D.OverlapCircle(CheckIfPlayerIsCloseTransform.position,
           1f, LayerMask.GetMask("Hero")))
        {
            rotateAllow = true;
            
            Destroy(gameObject, 10f);
            GetComponent<Animator>().SetBool("IsAttacking", true);
        }
            
        
    }

}