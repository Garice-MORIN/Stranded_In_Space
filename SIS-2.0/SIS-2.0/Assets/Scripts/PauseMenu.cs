using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Mirror;

public class PauseMenu : NetworkBehaviour
{
    private NetworkManager networkManager;
    public Variables variables;
    public PlayerController playerController;
    public GameObject settingsMenu;
    public GameObject commandMenu;
    public AudioSource audioSource;
    public AudioSource effectSource;
    public Slider audioSlider;
    public Slider effectSlider;
    public MainMenu mainMenu;


    void Start()
    { 
        networkManager = NetworkManager.singleton;
        //audioSource = mainMenu.audioSource;
        audioSlider = mainMenu.volumeSlider;
        //effectSource = mainMenu.effectSource;
        effectSlider = mainMenu.effectSlider;
    }

    public void _Debug()
    {
        Debug.Log("Hello");
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
        commandMenu.transform.GetChild(4).gameObject.SetActive(false); //Tableau Qwerty pas affiché
        commandMenu.transform.GetChild(3).gameObject.SetActive(true);  //Tabbleau Azerty affiché
       // qwerty.isOn = false;
    }

    public void QwertyIsOn()
    {
        commandMenu.transform.GetChild(3).gameObject.SetActive(false); //Tableau Azerty pas affiché
        commandMenu.transform.GetChild(4).gameObject.SetActive(true);  //Tabbleau Qwerty affiché
        //azerty.isOn = false;
    }

    public void OnVolumeValueChanged()
    {
        //audioSource.volume = audioSlider.value;
        audioSource.volume = audioSlider.value;
        variables.musicVolume = audioSlider.value;
    }

    public void OnEffectValueChanged()
    {
        //effectSource.volume = effectSlider.value;
        effectSource.volume = effectSlider.value;
        variables.effectVolume = effectSlider.value;
    }
}
