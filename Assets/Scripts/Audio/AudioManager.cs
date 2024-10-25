using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    /*private FMOD.Studio.EventInstance themeMusic;
    private FMOD.Studio.EventInstance titleMusic;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider SFXSlider;
    [SerializeField] private GameObject settingsMenu;

    void Awake()
    {
        titleMusic = FMODUnity.RuntimeManager.CreateInstance("event:/TitleTheme");
        themeMusic = FMODUnity.RuntimeManager.CreateInstance("event:/Level1"); //create music event
        ChangeMusicImmediate(SceneManager.GetActiveScene().name);
        if (PlayerPrefs.GetInt("openedPreviously") == 0)
        {
            PlayerPrefs.SetFloat("MusicVolume", 0.8f);
            PlayerPrefs.SetFloat("SFXVolume", 0.8f);
            PlayerPrefs.SetInt("openedPreviously", 1);
        }

        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        PlayThemeMusic();
        Debug.Log("played music and the music volume is " + PlayerPrefs.GetFloat("MusicVolume"));
    }

    void PlayThemeMusic()
    {
        themeMusic.setParameterByName("MusicVolume", PlayerPrefs.GetFloat("MusicVolume"));
        themeMusic.start(); //start music
    }

    void PlayTitleMusic()
    {
        titleMusic.setParameterByName("MusicVolume", PlayerPrefs.GetFloat("MusicVolume"));
        titleMusic.start();
    }

    void StopThemeMusic()
    {
        themeMusic.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        themeMusic.release();
    }

    void StopTitleMusic()
    {
        titleMusic.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        titleMusic.release();
    }

    public void ChangeMusicImmediate(string scene)
    {
        if (scene == "Level1")
        {
            StopTitleMusic();
            PlayThemeMusic();
        }
        else if (scene == "Title")
        {
            StopThemeMusic();
            PlayTitleMusic();
        }
    }

    void Update()
    {
        if (Input.GetKey("escape"))
        {
            ToggleMainMenu();
        }
    }

    public void SetMusicVolume(float volume)
    {
        PlayerPrefs.SetFloat("MusicVolume", volume);
        themeMusic.setParameterByName("MusicVolume", PlayerPrefs.GetFloat("MusicVolume"));
        titleMusic.setParameterByName("MusicVolume", PlayerPrefs.GetFloat("MusicVolume"));
    }

    public void SetSFXVolume(float volume)
    {
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }

    public void ToggleMainMenu()
    {
        if (settingsMenu.activeSelf)
        {
            settingsMenu.SetActive(false);
        }
        else
        {
            settingsMenu.SetActive(true);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

*/
}
