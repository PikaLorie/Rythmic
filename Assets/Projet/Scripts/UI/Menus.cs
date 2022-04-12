using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Menus : MonoBehaviour
{
    [SerializeField] private CameraSwitch cameraSwitch = null;

    public GameObject MainMenu;

    [Header("Navigation Panel")]
    public Button Play;
    public Button Options;
    public Button Quit;

    [Header("Option Panel")]
    public GameObject OptionsPanel;
    public Slider musicSlider;
    public Slider sfxSlider;
    public Slider ambientSlider;
    public bool isFull;
    public GameObject fullScreen;

    [Header("Controller Screen")]
    public GameObject controlsScreen;

    [Header("Audio")]
    public AudioMixer mixer;

    [Header("Autre")]
    [SerializeField] private float transitionTime;
    public Animator transition;
    public GameObject transitionGameObject;


    void Update()
    {
        musicSlider.onValueChanged.AddListener(OnMusicSliderChange);
        sfxSlider.onValueChanged.AddListener(OnSfxSliderChange);
        ambientSlider.onValueChanged.AddListener(OnEnvSliderChange);
    }

    public void MainMenuDisplay()
    {
        MainMenu.SetActive(true);
    }

    // Boutons Principaux //
    public void StartGame()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transitionGameObject.SetActive(true);
        transition.SetTrigger("FadeIn");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }

    public void OpenOptionsPanel()
    {
        MainMenu.SetActive(false);
        OptionsPanel.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();
    }


    // Option Panel //
    public void ExitOptionsPanel()
    {
        MainMenu.SetActive(true);
        OptionsPanel.SetActive(false);
    }

    // SLIDER //
    void OnMusicSliderChange(float value)
    {
        float volume = RangeToDecibel(value);
        mixer.SetFloat("MusicVolume", volume);
    }
    void OnSfxSliderChange(float value)
    {
        float volume = RangeToDecibel(value);
        mixer.SetFloat("SfxVolume", volume);
    }
    void OnEnvSliderChange(float value)
    {
        float volume = RangeToDecibel(value);
        mixer.SetFloat("EnvVolume", volume);
    }

    public static float RangeToDecibel(float range)
    {
        if (range == 0)
        {
            return -80f;
        }
        return Mathf.Log(range, 5) * 20;
    }
    public static float _decibelToRange(float db)
    {
        if (db == -80f)
        {
            return 0;
        }
        return Mathf.Pow(5, db / 20);
    }

    // Ecran //
    public void FullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
        isFull = isFullScreen;
    }
    
    // Controle Panel //
    public void OpenGameController()
    {
        controlsScreen.SetActive(true);
        MainMenu.SetActive(false);
    }
    public void ExitGameController()
    {
        controlsScreen.SetActive(false);
        MainMenu.SetActive(true);
    }

    public void ExitSign()
    {
        cameraSwitch.SignCameraSwitchToPlayerCamera();
        MainMenu.SetActive(false);


    }
}
