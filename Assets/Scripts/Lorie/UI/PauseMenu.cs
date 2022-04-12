using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{
    public GameObject _pauseMenu;
    public GameObject _sombre;

    [Header ("Navigation Panel")]

    public Button _resumeGame;
    public Button _restartGame;
    public Button _openOptionsPanel;
    public Button _openGameController;
    public Button _exitGame;


    [Header ("Option Panel")]

    public GameObject _optionsPanel;
    public Slider _musicSlider;
    public Slider _sfxSlider;
    public Slider _ambientSlider;
    public Dropdown _resolution;
    public bool _isFull;
    public GameObject fullScreen;


    [Header ("Controller Screen")]

    public GameObject _controlScreen;
  
    [Header ("Audio")]

    public AudioMixer mixer;

    public static float _rangeToDecibel(float range)
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


    [Header ("Autre")]

    [SerializeField] private float _transitionTime;
    public Animator _transition;
    
    void Start()
    {
        _pauseMenu.SetActive(false);
        _sombre.SetActive(false);

    }


    void Update()
    {
        if(Input.GetButtonDown("Exit"))
        {
            Time.timeScale = 0;
            _pauseMenu.SetActive(true);
            _sombre.SetActive(true);
            _controlScreen.SetActive(false);
            _optionsPanel.SetActive(false);
        }

        _musicSlider.onValueChanged.AddListener(OnMusicSliderChange);
        _sfxSlider.onValueChanged.AddListener(OnSfxSliderChange);
        _ambientSlider.onValueChanged.AddListener(OnEnvSliderChange);
    }


// Boutons Principaux //

    public void ResumeGame()
    {
        _pauseMenu.SetActive(false);
        _sombre.SetActive(false);
        _controlScreen.SetActive(false);
        _optionsPanel.SetActive(false);

        Time.timeScale = 1;
    }
    
    public void RestartGame()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
    }
    IEnumerator LoadLevel(int levelIndex)
    {
        Time.timeScale = 1;
        _pauseMenu.SetActive(false);
        _sombre.SetActive(false);
        _controlScreen.SetActive(false);
        _optionsPanel.SetActive(false);
        _transition.SetTrigger("FadeIn");
        yield return new WaitForSeconds(_transitionTime);
        SceneManager.LoadScene(levelIndex);
    }

    public void QuitGame()
    {
        SceneManager.LoadScene(0);
    }


// Option Panel //

    public void OpenOptionPanel()
    {
        _controlScreen.SetActive(false);
        _optionsPanel.SetActive(true);
        
    }

// SLIDER OPTION //
    void OnMusicSliderChange(float value)
    {
        float volume = _rangeToDecibel(value);
        mixer.SetFloat("MusicVolume", volume);
    }
    void OnSfxSliderChange(float value)
    {
        float volume = _rangeToDecibel(value);
        mixer.SetFloat("SfxVolume", volume);
    }
    void OnEnvSliderChange(float value)
    {
        float volume = _rangeToDecibel(value);
        mixer.SetFloat("EnvVolume", volume);
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


// Controle Panel //
    public void OpenGameController()
    {
        _controlScreen.SetActive(true);
        _optionsPanel.SetActive(false);
    }
}