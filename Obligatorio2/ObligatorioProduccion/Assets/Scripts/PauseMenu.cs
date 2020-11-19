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
    private bool isMenuOpen = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !DialogManager.isDialogActive)
        {
            isPaused = !isPaused;
            if(isMenuOpen == false)
            {
                ActivateMenuUI();
            }
            else
            {
                DeactivateMenuUI();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && DialogManager.isDialogActive)
        {
            if (isMenuOpen == false)
            {
                ActivateMenuUI();
            }
            else
            {
                DeactivateMenuUI();
            }
            isPaused = true;
        }
    }

    private void ActivateMenuUI()
    {
        isMenuOpen = true;
        Time.timeScale = 0;
        pauseMenuUI.SetActive(true);
    }

    public void DeactivateMenuUI()
    {
        isMenuOpen = false;
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
