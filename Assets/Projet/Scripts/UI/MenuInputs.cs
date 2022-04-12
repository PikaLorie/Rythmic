using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuInputs : MonoBehaviour
{
    [SerializeField] private MenuDetection menuDetection = null;
    [SerializeField] private CameraSwitch cameraSwitch = null;

    private void Update()
    {
        MenuPrincipal();

    }

    private void MenuPrincipal()
    {
        if (Input.GetKeyDown(KeyCode.E) && menuDetection.isAtRange == true)
        {
            menuDetection.EMessageCanvas.SetActive(false);
            cameraSwitch.PlayerCameraSwitchToSignCamera();  
        }

           

    }
   
}
