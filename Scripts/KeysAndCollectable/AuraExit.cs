using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AuraExit : MonoBehaviour
{
    CrossFadeScript crossFadeScript;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        StartCoroutine(ExitCoroutine());
        
        
    }

    IEnumerator ExitCoroutine()
    {
        Time.timeScale = 0.1f;
        Camera.main.GetComponent<AudioSource>().volume = 0f;
        AudioManager.PlayAudio(AudioClipName.WinMusic);
        yield return new WaitForSecondsRealtime(7f);
        
        crossFadeScript.LoadNextLevel();
        Time.timeScale = 1;



    }
    // Start is called before the first frame update
    void Start()
    {
        crossFadeScript = FindObjectOfType<CrossFadeScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
