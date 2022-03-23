using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScript : MonoBehaviour
{
    [SerializeField]
    GameObject mapCollectable;
    [SerializeField]
    GameObject vfx;

    KeysAndCollectableManagementScript keysAndCollectableManagementScript;

    private void Start()
    {
        keysAndCollectableManagementScript = FindObjectOfType<KeysAndCollectableManagementScript>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<MainHero>() && (keysAndCollectableManagementScript.GetTotalKeysCount
            >=4))
        {
            AudioManager.PlayAudio(AudioClipName.ChestBlast);
            Instantiate<GameObject>(mapCollectable, gameObject.transform.position +
                new Vector3(0, 0.6f, 0), Quaternion.identity);
            Instantiate<GameObject>(vfx, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }


}
