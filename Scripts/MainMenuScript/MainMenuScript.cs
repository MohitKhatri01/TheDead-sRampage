using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    CrossFadeScript crossFadeScript;

    public void HandleQuitButton()
    {
        AudioManager.PlayAudio(AudioClipName.ClickSound);
        Application.Quit();
    }

    public void HandleStartButton()
    {
        AudioManager.PlayAudio(AudioClipName.ClickSound);
        Camera.main.GetComponent<AudioSource>().volume = 0;
        StartCoroutine(LevelLoadDelay());
        
    }
     IEnumerator LevelLoadDelay()
    {
        yield return new WaitForSecondsRealtime(.8f);

        crossFadeScript.LoadNextLevel();
        
    }
    public void HandleHelpButton()
    {
        AudioManager.PlayAudio(AudioClipName.ClickSound);
        Object helpDesk = Instantiate(Resources.Load("ControlsDesk"));
    }
    // Start is called before the first frame update
    void Start()
    {
        Camera.main.GetComponent<AudioSource>().volume = 1;
        crossFadeScript = FindObjectOfType<CrossFadeScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
