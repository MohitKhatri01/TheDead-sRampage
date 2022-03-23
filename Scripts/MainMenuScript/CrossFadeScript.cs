using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrossFadeScript : MonoBehaviour
{
    [SerializeField]
    Animator animator;

   
    public void LoadNextLevel()
    {
        if(SceneManager.GetActiveScene().buildIndex+1==4)
        {
            SceneManager.LoadScene("MainMenu");
            return;
        }
        StartCoroutine(CrossFadeDelay(SceneManager.GetActiveScene().buildIndex+1));
    }

    IEnumerator CrossFadeDelay(int buildIndexOfNextScene)
    {
        animator.SetTrigger("Start");
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene(buildIndexOfNextScene);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
