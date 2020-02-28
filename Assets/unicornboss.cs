using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class unicornboss : MonoBehaviour
{
    public float hp;
    public float maxhp=15;
   public bool cutscene = false;
    GameObject player;
    GameObject dialog;
    public GameObject shadowOrb;
    public GameObject crystal;
    public bool canShoot= true;
    

    void Start()
    {
        hp = maxhp;
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
        if (canShoot)
        {
            canShoot = false;
            StartCoroutine(shadowAttack());
        }

        if (hp <= 0)
        {
            GameObject c = Instantiate(crystal, transform.parent);
            
            Vector3 t;
            t = c.transform.localPosition;
            t.x *= 2;
            c.transform.localPosition = t;
            c.transform.parent = null;
            Destroy(gameObject);
        }
    }

    IEnumerator shadowAttack()
    {
        yield return new WaitForSeconds(1);
        Vector3 t;
        GameObject clone;
        clone = Instantiate(shadowOrb, transform);
        clone.GetComponent<Rigidbody2D>().AddForce(Vector3.left *500);
        t = clone.transform.localPosition;
        t.x -= 3;
        clone.transform.localPosition=t;
        clone.transform.parent = null;
        yield return new WaitForSeconds(2);
        canShoot = true;

    }


}
