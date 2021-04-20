using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Mirror;

public class PauseMenu : NetworkBehaviour
{
    private NetworkManager networkManager;

    private void Start()
    {
        networkManager = NetworkManager.singleton;
    }

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
 
}
