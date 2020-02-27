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

    
    Animator anim;
    
    void Start()
    {
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
        Debug.Log("test");
        yield return new WaitForSeconds(5);
        GameObject.Find(s).GetComponent<UnityEngine.UI.Button>().interactable = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (hp > maxhp)
            hp = maxhp;

        if (GetComponent<Movement>().start)
        {
            if (knockbackcount <= 0)
            {

            }
            else
            {


                GetComponent<Rigidbody2D>().velocity = new Vector2(-GetComponent<Rigidbody2D>().velocity.x * 1.5f, -GetComponent<Rigidbody2D>().velocity.x);

                knockbackcount -= Time.deltaTime;
            }


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



            if (CrossPlatformInputManager.GetButtonDown("Sword2"))
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

            if (CrossPlatformInputManager.GetButtonDown("Ice"))
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

            if (CrossPlatformInputManager.GetButtonDown("Wind"))
            {
                StartCoroutine(timeout("Wind"));
                wind--;
                StartCoroutine(speedup());
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("enemy"))
        {
            knockbackcount = 0.5f;
            hp -= col.gameObject.GetComponent<enemy>().power;
        }
    }
}
