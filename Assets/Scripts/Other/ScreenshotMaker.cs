using System;
using System.Collections;
using System.Collections.Generic;
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
