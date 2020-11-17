using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public static bool isPaused;
    public AudioMixer audioMixer;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }
        if (isPaused)
        {
            ActivateMenuUI();
        }
        else
        {
            DeactivateMenuUI();
        }
    }

    private void ActivateMenuUI()
    {
        Time.timeScale = 0;
        pauseMenuUI.SetActive(true);
    }

    public void DeactivateMenuUI()
    {
        Time.timeScale = 1;
        pauseMenuUI.SetActive(false);
        isPaused = false;
    }

    public void GoToMainMenu()
    {
        isPaused = false;
        SceneManager.LoadScene(0);
    }

    
    public void SetVolume(float volume)
    {
        Debug.Log("volume");
        audioMixer.SetFloat("volume", volume);
    }

    public void RestartLevel()
    {
        Application.LoadLevel(Application.loadedLevel);
        DeactivateMenuUI();
    }
}
