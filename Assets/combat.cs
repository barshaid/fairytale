using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class combat : MonoBehaviour
{
    public float hp = 5;
    Animator anim;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
            anim.SetBool("atk", CrossPlatformInputManager.GetButtonDown("Sword"));
            anim.SetBool("atk2", CrossPlatformInputManager.GetButtonDown("Sword2"));

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("enemy"))
        {
            hp--;
        }
    }
}
