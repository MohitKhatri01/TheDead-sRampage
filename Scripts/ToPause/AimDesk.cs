using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimDesk : MonoBehaviour
{
    public void HandleBackButtonClick()
    {
        AudioManager.PlayAudio(AudioClipName.ClickSound);
        Destroy(gameObject);
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
