using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScript : MonoBehaviour
{

    GameObject doorWay;

    // Start is called before the first frame update
    void Start()
    {
        doorWay = GameObject.FindGameObjectWithTag("Doorway");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<MainHero>())
        {
            AudioManager.PlayAudio(AudioClipName.MapCollect);
            Destroy(doorWay);
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
