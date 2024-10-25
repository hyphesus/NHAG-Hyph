using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject settingsMenu;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
           ToggleSettingsMenu(); 
        }
        
    }

    public void QuitGame()
    {
        // this command quits the game
        Application.Quit();
    }

    public void ToggleSettingsMenu()
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

}
