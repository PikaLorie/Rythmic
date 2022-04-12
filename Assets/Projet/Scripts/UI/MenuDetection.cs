using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuDetection : MonoBehaviour
{
    public GameObject EMessageCanvas;
    public bool isAtRange = false;
  
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isAtRange = true;
            EMessageCanvas.SetActive(true);
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isAtRange = false;
            EMessageCanvas.SetActive(false);
        }
    }
}
