using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    private Queue<string> sentences;
    public static bool isDialogActive = false;

    public Text dialogText;
    public GameObject dialogPanel;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    void Update()
    {
        if(isDialogActive && Input.GetKeyDown(KeyCode.Space))
        {
            DisplayNextSentence();
        }
        if (isDialogActive)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void StartDialog(Dialog dialog)
    {
        sentences.Clear();
        dialogPanel.SetActive(true);
        PauseMenu.isPaused = true;

        foreach (string sentence in dialog.sentences)
        {
            sentences.Enqueue(sentence);
        }
        isDialogActive = true;
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialog();
            return;
        }
        string sentence = sentences.Dequeue();
        dialogText.text = sentence;
    }

    public void EndDialog()
    {
        isDialogActive = false;
        dialogPanel.SetActive(false);
        PauseMenu.isPaused = false;
    }
}
