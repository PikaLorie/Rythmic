using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField] private Menus menus = null;

    public GameObject VCAMplayer;
    public GameObject VCAMSign;

    public void PlayerCameraSwitchToSignCamera()
    {
        VCAMSign.SetActive(true);
        VCAMplayer.SetActive(false);

        StartCoroutine(MenuOpen());
    }

    private IEnumerator MenuOpen()
    {
        yield return new WaitForSeconds(1.1f);
        menus.MainMenuDisplay();
    }

    public void SignCameraSwitchToPlayerCamera()
    {
        VCAMSign.SetActive(false);
        VCAMplayer.SetActive(true);


    }
}
