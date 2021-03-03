using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Animations;

public class MainMenu : MonoBehaviour
{
    Animator animator;
    public void OnExitButton()
    {
        Application.Quit();
    }

    public void OnStartButton()
    {
        SceneManager.LoadScene("TestMap");
    }

    public void TestMapButton()
    {
        SceneManager.LoadScene("TestMap");
    }

    public void ResetAnimation()
    {
        
    }
}
