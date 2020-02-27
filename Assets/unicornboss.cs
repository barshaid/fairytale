using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class unicornboss : MonoBehaviour
{
   public bool cutscene = false;
    GameObject player;
    GameObject dialog;
    public GameObject shadowOrb;
    bool canShoot= true;
    

    void Start()
    {
        player = GameObject.Find("Player");
        dialog = GameObject.Find("bossDialog");
        dialog.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Vector3.Distance(transform.position, player.transform.position) < 15 && !cutscene)
        {
            cutscene = true;
            Time.timeScale = 0;
            dialog.SetActive(true);
        }
        if ( canShoot)
        {
            canShoot = false;
            StartCoroutine(shadowAttack());
        }

    }

    IEnumerator shadowAttack()
    {
        yield return new WaitForSeconds(1);
        Transform t = GetComponentInChildren<Transform>().transform;
       
        Instantiate(shadowOrb, t);
        
        yield return new WaitForSeconds(5);
        canShoot = true;

    }


}
