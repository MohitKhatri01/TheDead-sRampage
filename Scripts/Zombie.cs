using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{

    //cache
    Rigidbody2D rigidBody2D;
    Collider2D collider2D;
    CircleCollider2D circleCollider2D;
    Animator animator;

    //config
    [SerializeField]
    float moveSpeed = 1f;
    
    [SerializeField]
    GameObject bloodPrefab;
    [SerializeField]
    GameObject onImpaceVfx;


    
    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        collider2D = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
        circleCollider2D = GetComponent<CircleCollider2D>();
        gameObject.GetComponent<AudioSource>().pitch = Random.Range(-2f, 2f);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector3(-Mathf.Sign(rigidBody2D.velocity.x),
            transform.localScale.y, transform.localScale.z);
    }
    // Update is called once per frame
    void Update()
    {
        if (IsFacingRight())
        {
            rigidBody2D.velocity = new Vector2(moveSpeed, 0f);
           
        }
        else
        {
            rigidBody2D.velocity = new Vector2(-moveSpeed, 0f);
            
        }

        ZombieDie();
    }

    private bool IsFacingRight()
    {
        bool isFacingRight = transform.localScale.x > Mathf.Epsilon;
        return isFacingRight;
    }

    private void ZombieDie()
    {
        bool isTouchingWeaponsLayer = circleCollider2D.IsTouchingLayers
            (LayerMask.GetMask("Weapons"));
        if (isTouchingWeaponsLayer)
        {
            AudioManager.PlayAudio(AudioClipName.ZombieDie);
            StartCoroutine(ZombieDieCoroutine());

        }
    }


    IEnumerator ZombieDieCoroutine()
    {
        Instantiate<GameObject>(bloodPrefab, gameObject.transform.position
            , Quaternion.identity);
        animator.SetBool("ZombieDie", true);
        yield return new WaitForSeconds(.8f);
        Destroy(gameObject);

    }

  

}
