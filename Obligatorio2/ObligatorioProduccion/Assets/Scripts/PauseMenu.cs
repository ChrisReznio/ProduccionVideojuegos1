﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public static bool isPaused;
    public AudioMixer audioMixer;
    public GameObject audioSource;
    private bool isMenuOpen = false;
    public Slider slider;

    private void Start()
    {
       slider.value = PlayerPrefs.GetFloat("volume");
    }
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
        audioSource.SetActive(false);
    }

    public void DeactivateMenuUI()
    {
        isMenuOpen = false;
        Time.timeScale = 1;
        pauseMenuUI.SetActive(false);
        audioSource.SetActive(true);
        isPaused = false;
    }

    public void GoToMainMenu()
    {
        isPaused = false;
        SceneManager.LoadScene(0);
    }

    
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        PlayerPrefs.SetFloat("volume", volume);
    }

    public void RestartLevel()
    {
        StaticValues.ActualLife = PlayerPrefs.GetInt("maxHealth");
        Application.LoadLevel(Application.loadedLevel);
        DeactivateMenuUI();
    }
}
