using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class combat : MonoBehaviour
{
    float knockbackcount;
    public float hp = 5;
    public float maxhp = 5;
    public float basepower=1;
    public float power;
    float speed;
    public float ice=3;
    public float fire=3;
    public float wind=3;
    public GameObject healthbar, deathUI;
    public UnityEngine.UI.Text icec,firec, windc;
    
    
    Animator anim;
    
    void Start()
    {
        Time.timeScale = 0;
        anim = GetComponentInChildren<Animator>();
        speed = GetComponent<Movement>().moveSpeed;
    }

    IEnumerator speedup()
    {

        anim.SetBool("wind", true);
        yield return new WaitForSeconds(3);
        anim.SetBool("wind", false);

    }

    IEnumerator timeout(string s)
    {

        GameObject.Find(s).GetComponent<UnityEngine.UI.Button>().interactable=false;
        
        yield return new WaitForSeconds(5);
        GameObject.Find(s).GetComponent<UnityEngine.UI.Button>().interactable = true;

    }

    // Update is called once per frame
    void Update()
    {
        
        firec.text = fire.ToString();
        icec.text = ice.ToString();
        windc.text = wind.ToString();
        healthbar.GetComponent<UnityEngine.UI.Image>().fillAmount = hp / maxhp;

        if (hp <= 0)
        {
            Destroy(transform.GetChild(0).gameObject);
            Time.timeScale = 0;
            deathUI.SetActive(true);
        }
        if (hp > maxhp)
            hp = maxhp;

        if (knockbackcount <= 0)
        {
            GetComponent<Movement>().start = true;
        }
        else
        {
            GetComponent<Movement>().start = false;
                GetComponent<Rigidbody2D>().AddForce(new Vector2(-transform.localScale.x * 2f, 1), ForceMode2D.Impulse);

            knockbackcount -= Time.deltaTime;
        }

        if (GetComponent<Movement>().start)
        {

            if (GetComponentInChildren<SpriteRenderer>().color == Color.white)
            {
                power = basepower;
                GetComponent<Movement>().moveSpeed = speed;

            }
            else if (GetComponentInChildren<SpriteRenderer>().color == Color.red)
            {
                power = basepower + 3;

            }
            else if (GetComponentInChildren<SpriteRenderer>().color == Color.green)
            {
                GetComponent<Movement>().moveSpeed = speed * 2;
            }


            anim.SetBool("atk", CrossPlatformInputManager.GetButtonDown("Sword"));



            if (CrossPlatformInputManager.GetButtonDown("Sword2") && GameObject.Find("Sword2").GetComponent<UnityEngine.UI.Button>().interactable)
            {
                if (fire > 0)
                {
                    StartCoroutine(timeout("Sword2"));
                    anim.SetBool("atk2", true);
                    fire--;
                }
            }
            else
            {
                anim.SetBool("atk2", false);
            }

            if (CrossPlatformInputManager.GetButtonDown("Ice") && GameObject.Find("Ice").GetComponent<UnityEngine.UI.Button>().interactable)
            {
                if (ice > 0)
                {
                    StartCoroutine(timeout("Ice"));
                    anim.SetBool("ice", true);
                    ice--;
                }
            }
            else
            {
                anim.SetBool("ice", false);
            }

            if (CrossPlatformInputManager.GetButtonDown("Wind") && GameObject.Find("Wind").GetComponent<UnityEngine.UI.Button>().interactable)
            {
                if (wind > 0)
                {
                    StartCoroutine(timeout("Wind"));
                    wind--;
                    StartCoroutine(speedup());
                }
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("enemy"))
        {
            knockbackcount = 0.3f;
            hp -= col.gameObject.GetComponent<enemy>().power;
        }
    }
}
