using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PauseMenu : MonoBehaviour
{
    public static bool _isPause = false;

    public GameObject menu;
    public Sprite resme;
    public GameObject button;
    // Update is called once per frame
    void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown("Menu"))
        {    
                pause();
        }
        if (CrossPlatformInputManager.GetButtonDown("Start"))
        {
            
            resume();
            button.GetComponent<UnityEngine.UI.Image>().sprite = resme;
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
