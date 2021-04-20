using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Mirror;

public class PauseMenu : NetworkBehaviour
{
    private NetworkManager networkManager;
    public PlayerController playerController;
    public GameObject settingsMenu;
    public GameObject commandMenu;

    private void Start()
    {
        networkManager = NetworkManager.singleton;

    }

    //Revenir menu principal
    public void OnMainMenu()
    {
        if(isClientOnly)
        {
            networkManager.StopClient();
        }
        else
        {
            networkManager.StopHost();
        }
        SceneManager.LoadScene("MainMenu");
    }

    //Ouvrir Settings
    public void OnSettingsMenu()
    {
        playerController.pauseMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }
    //Quitter Settings
    public void OnSettingsBack()
    {
        playerController.pauseMenu.SetActive(true);
        settingsMenu.SetActive(false);
    }

    //Ouvrir commands dans settings
    public void OnCommand()
    {
        settingsMenu.SetActive(false);
        commandMenu.SetActive(true);
    }

    //Fermer commande
    public void OnCommandBack()
    {
        commandMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void AzertyIsOn()
    { 
        commandMenu.transform.GetChild(5).gameObject.SetActive(false); //Tableau Qwerty pas affiché
        commandMenu.transform.GetChild(4).gameObject.SetActive(true);  //Tabbleau Azerty affiché
       // qwerty.isOn = false;
    }

    public void QwertyIsOn()
    {
        commandMenu.transform.GetChild(4).gameObject.SetActive(false); //Tableau Azerty pas affiché
        commandMenu.transform.GetChild(5).gameObject.SetActive(true);  //Tabbleau Qwerty affiché
        //azerty.isOn = false;
    }
}
