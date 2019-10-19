using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CameraViewTexture : MonoBehaviour
{
    void Start()
    {
        WebCamDevice[] devices = WebCamTexture.devices;
        WebCamDevice camera = new WebCamDevice();
        foreach (WebCamDevice cam in devices)
        {
            if (!cam.isFrontFacing)
            {
                camera = cam;
                break;
            }
        }

        if(String.IsNullOrWhiteSpace(camera.name))
            camera = WebCamTexture.devices[WebCamTexture.devices.Length - 1];

        var rawImage = GetComponent<RawImage>();
        WebCamTexture webcamTexture = new WebCamTexture(camera.name);
        rawImage.texture = webcamTexture;
        rawImage.material.mainTexture = webcamTexture;
        rawImage.color = new Color(1, 1, 1, 1);
        webcamTexture.Play();
    }
}
