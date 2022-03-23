using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{

    [SerializeField]
    GameObject keyForChest;
    [SerializeField]
    GameObject abilityCollectable;
    [SerializeField]
    GameObject healthCollectable;
    [SerializeField]
    GameObject CrateDestroyVfx;
    [SerializeField]
    GameObject pearlCollectable;
    [SerializeField]
    bool doesHaveKey = false;
    [SerializeField]
    bool doesHaveHealth = false;
    [SerializeField]
    bool doesHavePowerUp = false;
    [SerializeField]
    bool doesHavePearl = false;
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<SimpleWeapon>())
        {
            AudioManager.PlayAudio(AudioClipName.CrateBlast);
            Instantiate<GameObject>(CrateDestroyVfx, gameObject.transform.position,
                Quaternion.identity);
            if(doesHaveKey)
            {
                Instantiate<GameObject>(keyForChest, gameObject.transform.position+ 
                    new Vector3(0, 0.4f, 0),
                    Quaternion.identity);

            }
            if(doesHaveHealth)
            {
                Instantiate<GameObject>(healthCollectable, gameObject.transform.position+
                    new Vector3(0, 0.4f, 0),
                    Quaternion.identity);
            }
            if(doesHavePowerUp)
            {
                Instantiate<GameObject>(abilityCollectable, gameObject.transform.position
                    +new Vector3(0,0.4f,0),
                    Quaternion.identity);
            }
            if (doesHavePearl)
            {
                Instantiate<GameObject>(pearlCollectable, gameObject.transform.position
                    + new Vector3(0, 0.4f, 0),
                    Quaternion.identity);
            }

            Destroy(gameObject);
        }

       
    }
}
