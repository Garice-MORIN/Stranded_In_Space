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
    public Variables mouseParameters;

    private void Start()
    {
        volumeSlider.value = 0.5f;
        audioSource.volume = 0.5f;
        effectSlider.value = 0.5f;
        sensitivitySlider.value = 1500;
        mouseParameters.inverted = 1;
        mouseParameters.mouseSensitivity = 1500;
        
    }

    public void OnExitButton()
    {
        Application.Quit();
    }

    public void HideAnchor()
    {
        GetComponent<Animator>().Play("Normal");
        anchor.SetActive(false);
    }

    public void ShowAnchor()
    {
        anchor.SetActive(true);
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
        mouseParameters.musicVolume = volumeSlider.value;
    }

    public void OnEffectValueChanged()
    {
        effectSource.volume = effectSlider.value;
    }

    public void OnToggleChanged()
    {
        mouseParameters.inverted = mouseParameters.inverted == 1 ? -1 : 1;
    }


    public void OnSensitivityChanged()
    {
        mouseParameters.mouseSensitivity = sensitivitySlider.value;
    }
}
