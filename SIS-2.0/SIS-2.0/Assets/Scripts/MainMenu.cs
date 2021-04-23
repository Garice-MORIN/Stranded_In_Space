using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioSource effectSource;
    public Slider volumeSlider;
    public Slider effectSlider;
    public GameObject anchor;
    public Slider sensitivitySlider;
    public int inverted = 1;
    public Variables variables;
    public Text musicLevel;
    public Text effectlevel;

    private void Start()
    {
        volumeSlider.value = 0.5f;
        audioSource.volume = 0.5f;
        effectSlider.value = 0.5f;
        sensitivitySlider.value = 1125;
        variables.inverted = 1;
        musicLevel.text = "50 %";
        effectlevel.text = "50 %";
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
        variables.musicVolume = volumeSlider.value;
        musicLevel.text = Mathf.FloorToInt(volumeSlider.value * 100) + " %";
    }

    public void OnEffectValueChanged()
    {
        effectSource.volume = effectSlider.value;
        variables.effectVolume = effectSlider.value;
        effectlevel.text = Mathf.FloorToInt(effectSlider.value * 100) + " %";
    }

    public void OnToggleChanged()
    {
        variables.inverted = variables.inverted == 1 ? -1 : 1;
    }


    public void OnSensitivityChanged()
    {
        variables.mouseSensitivity = sensitivitySlider.value;
    }
}
