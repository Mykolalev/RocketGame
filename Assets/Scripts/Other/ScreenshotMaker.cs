using System;
using UnityEngine;

public class ScreenshotMaker : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ScreenCapture.CaptureScreenshot($"{DateTime.Now.ToString("yyyy.MM.dd.mm.ss")} .png", 4);
        }
    }
}