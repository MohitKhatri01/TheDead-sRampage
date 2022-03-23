using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainHero : MonoBehaviour
{
    //config
    public Joystick joystick;
    [Header("PlayerDetails")]
    [SerializeField]
    float runSpeed = 5f;
    [SerializeField]
    float jumpSpeed = 20f;
    [SerializeField]
    GameObject heroWeapon;
    [SerializeField]
    GameObject specialAbilityWeapon;
    [SerializeField]
    float weaponSpeed = 100f;
    [SerializeField]
    float specialWeaponSpeed = 200f;

    [SerializeField]
    Slider specialAbilitySlider;
    [SerializeField]
    float timeTookToFillSlider = 50f;
    float startTime = 0;
    bool SliderFillingFinished = false;
    //cache
    Rigidbody2D rigidBody2d;
    Animator animator;
    BoxCollider2D boxCollider2D;
    CapsuleCollider2D capsuleCollider2D;
    SpeciaAbilityManageScript specialAbilityManagementScript;
    PlayerHealth playerHealth;


    //bool isAlive = true;

    bool shootAllow = true;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        specialAbilityManagementScript = FindObjectOfType<SpeciaAbilityManageScript>();
        playerHealth = GetComponent<PlayerHealth>();

    }

    #region PlayerMovements
    private void PlayerRun()
    {
        var horizontalInputValue = Input.GetAxis("Horizontal");
        Vector2 runVelocity = new Vector2(
            horizontalInputValue * runSpeed, rigidBody2d.velocity.y);
        rigidBody2d.velocity = runVelocity;

        bool isRunningHorizontally = Mathf.Abs(rigidBody2d.velocity.x) > Mathf.Epsilon;

        animator.SetBool("IsRunning", isRunningHorizontally);

    }

    public void PlayerJump()
    {
        if (playerHealth.GetIsAliveValue == false)
        {
            return;
        }
        bool isTouchingGround = boxCollider2D.IsTouchingLayers(LayerMask.GetMask("Ground"));
        if (isTouchingGround)
        {
            if (Input.GetButtonDown("Jump"))
            {

                Vector2 jumpVelocity = new Vector2(rigidBody2d.velocity.x, jumpSpeed);
            rigidBody2d.velocity += jumpVelocity;

            }
        }
        
    }

    private void FlipSprite()
    {
        bool isRunningHorizontally = Mathf.Abs(rigidBody2d.velocity.x) > Mathf.Epsilon;
        if (isRunningHorizontally)
        {
            gameObject.transform.localScale = new Vector3(Mathf.Sign(rigidBody2d.velocity.x)
                , transform.localScale.y, transform.localScale.z);
        }
    }

    private void PlayerAttack()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            if (SliderFillingFinished && specialAbilityManagementScript.IsEnoughAbilities())
            {
                AudioManager.PlayAudio(AudioClipName.SpecialArrowShoot);
                specialAbilityManagementScript.SubtractSpecialAbilityCount();
                specialAbilitySlider.value = 0;
                SliderFillingFinished = false;
                animator.SetTrigger("IsAttacking");
                StartCoroutine(AnimationComplitionDelay());

                var specialWeapon = Instantiate<GameObject>(specialAbilityWeapon, transform.position,
                    Quaternion.identity);


                specialWeapon.transform.localScale = new Vector3(gameObject.transform.localScale.x,
                    specialWeapon.transform.localScale.y, specialWeapon.transform.localScale.z);
                specialWeapon.GetComponent<Rigidbody2D>().gravityScale = 0;
                specialWeapon.GetComponent<Rigidbody2D>().velocity = new Vector2(specialWeaponSpeed *
                   Mathf.Sign(transform.localScale.x), 0);
            }
        }

        if (Input.GetButtonDown("Fire1"))
        {


            if (shootAllow == true)
            {
                shootAllow = false;
                animator.SetTrigger("IsAttacking");
                StartCoroutine(AnimationComplitionDelay());
                var weapon = Instantiate<GameObject>(heroWeapon,
                    transform.position, Quaternion.identity);
                weapon.transform.localScale = new Vector3(gameObject.transform.localScale.x,
                    weapon.transform.localScale.y, weapon.transform.localScale.z);
                weapon.GetComponent<Rigidbody2D>().gravityScale = 0;
                weapon.GetComponent<Rigidbody2D>().velocity = new Vector2(weaponSpeed
                    * Mathf.Sign(transform.localScale.x), 0);
                AudioManager.PlayAudio(AudioClipName.ArrowShoot);
                shootAllow = true;
            }


        }
    }




    //public void ArrowThrow()
    //{
    //    if (playerHealth.GetIsAliveValue == false)
    //    {
    //        return;
    //    }
    //    if (shootAllow == true)
    //    {
    //        shootAllow = false;
    //        animator.SetTrigger("IsAttacking");
    //        StartCoroutine(AnimationComplitionDelay());
    //        var weapon = Instantiate<GameObject>(heroWeapon,
    //            transform.position, Quaternion.identity);
    //        weapon.transform.localScale = new Vector3(gameObject.transform.localScale.x,
    //            weapon.transform.localScale.y, weapon.transform.localScale.z);
    //        weapon.GetComponent<Rigidbody2D>().gravityScale = 0;
    //        weapon.GetComponent<Rigidbody2D>().velocity = new Vector2(weaponSpeed
    //            * Mathf.Sign(transform.localScale.x), 0);
    //        AudioManager.PlayAudio(AudioClipName.ArrowShoot);
    //        shootAllow = true;
    //    }
    //}


    IEnumerator AnimationComplitionDelay()
        {
            yield return new WaitForSeconds(20f);
        }

    //public void MagicArrowThrow()
    //{
    //    if(playerHealth.GetIsAliveValue==false)
    //    {
    //        return;
    //    }
    //    if (SliderFillingFinished && specialAbilityManagementScript.IsEnoughAbilities())
    //    {
    //        AudioManager.PlayAudio(AudioClipName.SpecialArrowShoot);
    //        specialAbilityManagementScript.SubtractSpecialAbilityCount();
    //        specialAbilitySlider.value = 0;
    //        SliderFillingFinished = false;
    //        animator.SetTrigger("IsAttacking");
    //        StartCoroutine(AnimationComplitionDelay());

    //        var specialWeapon = Instantiate<GameObject>(specialAbilityWeapon, transform.position,
    //            Quaternion.identity);


    //        specialWeapon.transform.localScale = new Vector3(gameObject.transform.localScale.x,
    //            specialWeapon.transform.localScale.y, specialWeapon.transform.localScale.z);
    //        specialWeapon.GetComponent<Rigidbody2D>().gravityScale = 0;
    //        specialWeapon.GetComponent<Rigidbody2D>().velocity = new Vector2(specialWeaponSpeed *
    //           Mathf.Sign(transform.localScale.x), 0);
    //    }
    //}



    #endregion
    // Update is called once per frame
    void Update()
        {

            if (playerHealth.GetIsAliveValue)
            {
                PlayerRun();
                FlipSprite();
            PlayerJump();
            PlayerAttack();
            //PlayerDie();
        }

            FillSlider();
        }

        void FillSlider()
        {

            specialAbilitySlider.value += Time.deltaTime / timeTookToFillSlider;
            if (specialAbilitySlider.value >= 1)
            {
                SliderFillingFinished = true;
            }

        }


    
}
