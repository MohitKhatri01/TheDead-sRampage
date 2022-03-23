using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAudioSource : MonoBehaviour
{
    private void Awake()
    {
        if(!AudioManager.isInitialized)
        {
            AudioSource audioSource = gameObject.AddComponent<AudioSource>();
            AudioManager.Initialization(audioSource);
            DontDestroyOnLoad(gameObject);
        }
        else
        {
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
