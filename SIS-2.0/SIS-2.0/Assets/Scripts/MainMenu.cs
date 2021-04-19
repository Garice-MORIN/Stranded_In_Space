using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using Mirror;

public class MainMenu : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioSource effectSource;
    public Slider volumeSlider;
    public Slider effectSlider;
    //public Slider sensitivitySlider;
    public float sensitivity;

    private void Start()
    {
        volumeSlider.value = 0.5f;
        audioSource.volume = 0.5f;
        effectSlider.value = 0.5f;
        //Screen.fullScreen = true;
    }

    public void OnExitButton()
    {
        Application.Quit();
    }

    public void OnStartButton()
    {
        SceneManager.LoadScene("FinalMap");
    }

    public void TestMapButton()
    {
        SceneManager.LoadScene("TestMap");
    }

    public void MenuToCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void OnVolumeValueChanged()
    {
        audioSource.volume = volumeSlider.value;
        //Debug.Log(audioSource.volume);
    }

    public void OnEffectValueChanged()
    {
        effectSource.volume = effectSlider.value;
    }


    /*public void OnSensitivityChanged() //Currently not working 
    {
        float truncaturedValue = Mathf.Round(sensitivitySlider.value * 100f) / 100f;
        sensitivity = truncaturedValue * 1500f;
    }*/
}
