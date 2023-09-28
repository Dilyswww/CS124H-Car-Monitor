using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    // Change Camera Location
    [SerializeField] public GameObject maincamera;
    [SerializeField] public GameObject closeupcamera;
    [SerializeField] public GameObject backcamera;
    [SerializeField] public GameObject car;

    // Get Input
    private bool main;
    private bool close;
    private bool back;

    private void FixedUpdate() 
    {
        GetInput();
        ChangeCameraLocation();
    }

    private void GetInput()
    {
        main = Input.GetButtonDown("MainCamera");
        close = Input.GetButtonDown("CloseupCamera");
        back = Input.GetButtonDown("BackCamera");
    }

    private void ChangeCameraLocation()
    {
        if (main)
        {
            maincamera.SetActive(true);
            closeupcamera.SetActive(false);
            backcamera.SetActive(false);
        }

        if (close)
        {
            closeupcamera.SetActive(true);
            maincamera.SetActive(false);
            backcamera.SetActive(false);
        }

        if (back)
        {
            backcamera.SetActive(true);
            maincamera.SetActive(false);
            closeupcamera.SetActive(false);
        }
    }
}
