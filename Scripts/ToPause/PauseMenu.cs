using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public void HandleResumeButtonClick()
    {
        AudioManager.PlayAudio(AudioClipName.ClickSound);
        Time.timeScale = 1;
        Destroy(gameObject);

    }

    public void HandleMainMenuButtonClick()
    {
        AudioManager.PlayAudio(AudioClipName.ClickSound);
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
        Destroy(gameObject);
       
    }

    public void HandleShopButtonClick()
    {
        AudioManager.PlayAudio(AudioClipName.ClickSound);
        Time.timeScale = 0;
        Object shop = Instantiate(Resources.Load("Shop"));
    }

    public void HandleHelpButtonClick()
    {
        AudioManager.PlayAudio(AudioClipName.ClickSound);
        Time.timeScale = 0;
        Object helpDesk = Instantiate(Resources.Load("ControlsDesk"));
    }
    public void HandleAimButton()
    {
        AudioManager.PlayAudio(AudioClipName.ClickSound);
        Time.timeScale = 0;
        Object aimDesk = Instantiate(Resources.Load("AimDesk"));
    }
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
