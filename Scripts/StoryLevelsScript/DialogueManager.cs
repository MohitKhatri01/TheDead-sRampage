using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{

    private Queue<string> sentences;
    public Dialogue dialogue;
    [SerializeField]
    TextMeshProUGUI storyText;

    CrossFadeScript crossFadeScript;
    // Start is called before the first frame update
    void Start()
    {
        crossFadeScript = FindObjectOfType<CrossFadeScript>();

        Camera.main.GetComponent<AudioSource>().volume = 1;
        sentences = new Queue<string>();
        sentences.Clear();
        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        
        if (sentences.Count==0)
        {
            AudioManager.PlayAudio(AudioClipName.ClickSound);
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(LetterByLetter(sentence));
    }

    void EndDialogue()
    {
        
        Camera.main.GetComponent<AudioSource>().volume = 0;
        StartCoroutine(LevelLoadDelay());
    }

    IEnumerator LevelLoadDelay()
    {
        yield return new WaitForSecondsRealtime(.6f);
        crossFadeScript.LoadNextLevel();


    }
    IEnumerator LetterByLetter(string sentence)
    {
        storyText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            storyText.text+= letter;
            yield return new WaitForFixedUpdate();
        }
    }
   
    // Update is called once per frame
    void Update()
    {
        
    }
}
