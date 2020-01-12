using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PauseMenu : MonoBehaviour
{
    public static bool _isPause = false;

    public GameObject menu;

    // Update is called once per frame
    void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown("Menu"))
        {
            if (_isPause)
                resume();
            else
                pause();
        }
    }

    void pause()
    {
        Time.timeScale = 0;
        _isPause = true;
        menu.SetActive(true);

    }

    void resume()
    {
        Time.timeScale = 1;
        _isPause = false;
        menu.SetActive(false);
    }
}
