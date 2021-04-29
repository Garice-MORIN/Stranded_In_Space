using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Mirror;

public class MainMenu : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioSource effectSource;
    public Slider volumeSlider;
    public Slider effectSlider;
    public GameObject anchor;
    public Slider sensitivitySlider;
    public int inverted;
    //public Variables variables;
    public Text musicLevel;
    public Text effectlevel;
    public NetworkManager networkManager;

    private void Start()
    {
        volumeSlider.value = 0.5f;
        audioSource.volume = 0.5f;
        effectSlider.value = 0.5f;
        sensitivitySlider.value = 1125;
        musicLevel.text = "50 %";
        effectlevel.text = "50 %";
        inverted = 1;
        PlayerPrefs.SetFloat("MusicVolume", 0.5f);
        PlayerPrefs.SetFloat("EffectVolume", 0.5f);
        PlayerPrefs.SetInt("MouseSensitivity", 1125);
        PlayerPrefs.SetInt("Inverted", 1);
    }

    public void OnExitButton()
    {
        Application.Quit();
    }

    public void OnStartButton()
    {
        networkManager.onlineScene = "FinalMap";
        SceneManager.LoadScene("FinalMap");
    }

    public void TestMapButton()
    {
        networkManager.onlineScene = "TestMap";
        SceneManager.LoadScene("TestMap");
    }

    public void MenuToCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void OnVolumeValueChanged()
    {
        audioSource.volume = volumeSlider.value;
        PlayerPrefs.SetFloat("MusicVolume", volumeSlider.value);
        musicLevel.text = Mathf.FloorToInt(volumeSlider.value * 100) + " %";
    }

    public void OnEffectValueChanged()
    {
        effectSource.volume = effectSlider.value;
        PlayerPrefs.SetFloat("MusicVolume", effectSlider.value);
        effectlevel.text = Mathf.FloorToInt(effectSlider.value * 100) + " %";
    }

    public void OnToggleChanged() //Coefficient qui permet d'inverser la souris
    {
        inverted = inverted == 1 ? -1 : 1;
        PlayerPrefs.SetInt("Inverted", inverted);
    }


    public void OnSensitivityChanged()
    {
        PlayerPrefs.SetFloat("MouseSensitivity", sensitivitySlider.value);
    }
}
