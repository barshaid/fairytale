using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class bossDialog : MonoBehaviour
{
    public GameObject dialog1, dialog2;
    // Start is called before the first frame update
    void Start()
    {
        dialog1.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (CrossPlatformInputManager.GetButtonDown("Dialog"))
        {
            
            if (!dialog1.activeSelf && !dialog2.activeSelf)
            {
                dialog1.SetActive(true);
            }
            else if(dialog1.activeSelf)
            {
                dialog1.SetActive(false);
                dialog2.SetActive(true);
            }
            else
            {
                dialog2.SetActive(false);
                Time.timeScale = 1;
                gameObject.SetActive(false);
            }
        }
    }
}
