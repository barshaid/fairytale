using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class unicornboss : MonoBehaviour
{
    public float hp;
    public float maxhp = 15;
    public bool cutscene = false;
    GameObject player;
    GameObject dialog;
    public GameObject shadowOrb;
    public GameObject crystal;
    public GameObject healthbar;
    public GameObject winUI;
    bool canShoot = true;


    private void OnTriggerEnter2D(Collider2D col)
    {
        //check for incomming attack by the player
        if (col.CompareTag("attack"))
        {
            hp -= player.GetComponent<combat>().power;
            if (player.GetComponentInChildren<SpriteRenderer>().color == Color.cyan)
            {
                StartCoroutine(freeze());
            }
        }

    }

    //freeze 
    IEnumerator freeze()
    {
        GetComponent<Pathfinding.AIPath>().canMove = false;
        GetComponent<SpriteRenderer>().color = Color.cyan;
        float fps = GetComponent<Animator>().speed;
        GetComponent<Animator>().speed = GetComponent<Animator>().speed / 2;

        yield return new WaitForSeconds(5);

        GetComponent<Animator>().speed = fps;
    }

    void Start()
    {
        hp = maxhp;
        player = GameObject.Find("Player");
        dialog = GameObject.Find("bossDialog");
        dialog.SetActive(false);
    }


    void Update()
    {
        healthbar.GetComponent<UnityEngine.UI.Image>().fillAmount = hp / maxhp;

        //activate cutscene once
        if (Vector3.Distance(transform.position, player.transform.position) < 15 && !cutscene)
        {
            cutscene = true;
            Time.timeScale = 0;
            dialog.SetActive(true);
        }


        if (canShoot && cutscene)
        {
            canShoot = false;
            StartCoroutine(shadowAttack());
        }

        if (hp <= 0)
        {
            GameObject c = Instantiate(crystal, transform);

            Vector3 t;
            t = c.transform.localPosition;
            t.x *= 2;
            c.transform.localPosition = t;
            c.transform.parent = null;
            Destroy(gameObject);
            winUI.SetActive(true);
        }
    }

    IEnumerator shadowAttack()
    {
        yield return new WaitForSeconds(1);
        Vector3 t;
        GameObject clone;
        clone = Instantiate(shadowOrb, transform);
        clone.GetComponent<Rigidbody2D>().AddForce(Vector3.left * 500);
        t = clone.transform.localPosition;
        t.x -= 3;
        clone.transform.localPosition = t;
        clone.transform.parent = null;
        yield return new WaitForSeconds(2);
        canShoot = true;

    }


}
