using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public static bool _isPause = false;

    public GameObject menu;
    public Sprite resme;
    public GameObject button, tut, next, prev, done;
    int currpage = 0;
    
    public GameObject[] pages;
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
        if (CrossPlatformInputManager.GetButtonDown("Tutorial"))
        {
            tut.SetActive(true);
            pages[currpage].SetActive(true);
        }
        if (CrossPlatformInputManager.GetButtonDown("Done"))
        {
            pages[currpage].SetActive(false);
            tut.SetActive(false);
            currpage = 0;
        }

        if (CrossPlatformInputManager.GetButtonDown("Prev"))
        {
            pages[currpage].SetActive(false);
            currpage--;
            pages[currpage].SetActive(true);
            
        }
        if (CrossPlatformInputManager.GetButtonDown("Next"))
        {
            pages[currpage].SetActive(false);
            currpage++;
            pages[currpage].SetActive(true);

        }

        if (CrossPlatformInputManager.GetButtonDown("Restart"))
        {
            SceneManager.LoadScene("testscene");
        }

        if (pages[0].activeSelf)
        {
            prev.SetActive(false);
        }
        if (pages[1].activeSelf)
        {
            prev.SetActive(true);
        }
        if (pages[pages.Length-1].activeSelf)
        {
            next.SetActive(false);
            done.SetActive(true);
        }
        else
        {
            next.SetActive(true);
            done.SetActive(false);
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
