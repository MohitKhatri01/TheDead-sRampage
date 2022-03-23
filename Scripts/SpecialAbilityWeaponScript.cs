using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialAbilityWeaponScript : MonoBehaviour
{
    [SerializeField]
    GameObject onImpactVfx;
    [SerializeField]
    float lifetime = 1.4f;
    //[SerializeField]
    //GameObject bloodPrefab;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Zombie>() ||
            collision.gameObject.GetComponent<Enemy>())
        {
            AudioManager.PlayAudio(AudioClipName.SpecialArrowImpact);
            Instantiate<GameObject>(onImpactVfx, collision.transform.position,
                Quaternion.identity);
            //Instantiate<GameObject>(bloodPrefab, collision.transform.position,
            //    Quaternion.identity);
            Destroy(collision.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
