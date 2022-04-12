using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{ 
    public GameObject _MainMenu;

    [Header ("Navigation Panel")]
    public Button Play;
    public Button Options;
    public Button Quit;

    [Header ("Option Panel")]
    public GameObject _OptionsPanel;
    public Slider _musicSlider;
    public Slider _sfxSlider;
    public bool _isFull;
    public GameObject fullScreen;
    public Dropdown _resolution;
    
    [Header ("Audio")]
    public AudioMixer mixer;

    [Header ("Autre")]
    [SerializeField] private float _transitionTime;
    public Animator _transition;
    public GameObject _transitionGameObject;
    

    void Update()
    {
        _musicSlider.onValueChanged.AddListener(OnMusicSliderChange);
        _sfxSlider.onValueChanged.AddListener(OnSfxSliderChange);
    }


// Boutons Principaux //
    public void StartGame()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }
    IEnumerator LoadLevel(int levelIndex)
    {
        _transitionGameObject.SetActive(true);
        _transition.SetTrigger("FadeIn");
        yield return new WaitForSeconds(_transitionTime);
        SceneManager.LoadScene(levelIndex);
    }
    public void OpenOptionPanel()
    {
        _MainMenu.SetActive(false);
        _OptionsPanel.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

// Option Panel //
    public void ExitOptionPanel()
    {
        _MainMenu.SetActive(true);
        _OptionsPanel.SetActive(false);
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

    public static float RangeToDecibel(float range)
    {
        if(range == 0)
        {
            return -80f;
        }
        return Mathf.Log(range, 5) * 20;
    }
    public static float _decibelToRange(float db)
    {
        if(db == -80f)
        {
            return 0;
        }
        return Mathf.Pow(5, db / 20);
    }

// Ecran //
    public void FullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
        _isFull = isFullScreen;
    }
    public void SetResolution()
    {
        if(_isFull == true)
        {
            switch (_resolution.value)
            {
                case 0:
                    break;

                case 1:
                    Screen.SetResolution(640, 360, true);
                    break;

                case 2:
                    Screen.SetResolution(960, 540, true);
                    break;

                case 3:
                    Screen.SetResolution(1280, 720, true);
                    break;

                case 4:
                    Screen.SetResolution(1920, 1080, true);
                    break;

                case 5:
                    Screen.SetResolution(2560, 1440, true);
                    break;
            }
        }
        else
        {
            switch (_resolution.value)
            {
                case 0:
                    break;

                case 1:
                    Screen.SetResolution(640, 360, false);
                    break;

                case 2:
                    Screen.SetResolution(960, 540, false);
                    break;

                case 3:
                    Screen.SetResolution(1280, 720, false);
                    break;

                case 4:
                    Screen.SetResolution(1920, 1080, false);
                    break;

                case 5:
                    Screen.SetResolution(2560, 1440, false);
                    break;
            }
        }
    }
}
