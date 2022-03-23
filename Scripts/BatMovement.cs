using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatMovement : MonoBehaviour
{
    [SerializeField]
    GameObject batPath;
    [SerializeField]
    float batMoveSpeed = 10;
    [SerializeField]
    Transform CheckIfPlayerIsClosePos;
    float waitForDie = .3f;


    List<Transform> listOfWayPoints = new List<Transform>();

    bool moveAllow = false;
    Animator animator;
    CapsuleCollider2D capsuleCollider;
    
    int wayPointsIndex = 0;

    int audioCount = 0;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        FillListOfWayPoints();

    }
     
    void FillListOfWayPoints()
    {
      
        foreach(Transform transform in batPath.transform)
        {

            listOfWayPoints.Add(transform);
        }
        
        
       
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    private void BatMoveAllow()
    {
       if (Physics2D.OverlapCircle(CheckIfPlayerIsClosePos.position,
            1f, LayerMask.GetMask("Hero")))
        {
            moveAllow = true;
            animator.SetBool("IsAttacking", true);
            

        }

    }

    

    // Update is called once per frame
    void Update()
    {
        BatMoveAllow();
        if (moveAllow)
        {
            if (audioCount == 0)
            {
                AudioManager.PlayAudio(AudioClipName.BatMovement);
                audioCount++;
            }
            MoveBat();
        }

        
    }

   
    void MoveBat()
    {
        
        if (wayPointsIndex <= listOfWayPoints.Count - 1)
        {
            var targetPosition = listOfWayPoints[wayPointsIndex].transform.position;
            float moveSpeed = batMoveSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position,
                targetPosition, moveSpeed);
            if(targetPosition == transform.position)
            {
                wayPointsIndex++;
            }
            

        }
        else
        {
            Destroy(gameObject,waitForDie);
        }
    }
}
