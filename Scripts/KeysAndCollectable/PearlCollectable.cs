using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PearlCollectable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision is CapsuleCollider2D)
        {
            AudioManager.PlayAudio(AudioClipName.PearlCollect);
            FindObjectOfType<KeysAndCollectableManagementScript>().AddToPearlsCount();
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
