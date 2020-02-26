﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class enemy : MonoBehaviour
{
    public float hp;
    Rigidbody2D rb;
    float knockbackcount;
    public GameObject player;
    public float d;
    bool isfrozen = false;
   // AstarPath astar;
    float power = 1;
    float speed;
    float scale;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("attack"))
        {
            knockbackcount = 0.5f;
            hp-=player.GetComponent<combat>().power;
            if (player.GetComponentInChildren<SpriteRenderer>().color == Color.cyan)
            {
                Debug.Log(1);
                StartCoroutine(freeze());
            }
        }
    }

    IEnumerator freeze()
    {
        Debug.Log(2);

        //Finally freeze the body in place so forces like gravity or movement won't affect it
        GetComponent<Pathfinding.AIPath>().canMove = false;
        GetComponent<SpriteRenderer>().color = Color.cyan;
        isfrozen = true;
        //Wait for a bit (two seconds)
        float fps = GetComponent<Animator>().speed;
        GetComponent<Animator>().speed = GetComponent<Animator>().speed / 2;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        yield return new WaitForSeconds(5);
        //And unfreeze before restoring velocities
        isfrozen = false;
        rb.constraints = RigidbodyConstraints2D.None;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        GetComponent<Animator>().speed = fps;
        GetComponent<SpriteRenderer>().color = Color.white;
        //restore the velocities

    }

    private void Start()
    {
        scale = transform.localScale.x;
        rb = gameObject.GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        GetComponent<Pathfinding.AIPath>().maxSpeed = GetComponent<Pathfinding.AIPath>().maxSpeed / transform.localScale.x;
    }

    private void Update()
    {
        if (!isfrozen)
        {
            if (Vector2.Distance(transform.position, player.transform.position) > d)
            {
                GetComponent<Pathfinding.AIPath>().canSearch = false;
            }
            else
            {
                GetComponent<Pathfinding.AIPath>().canSearch = true;
            }

            if (GetComponent<Pathfinding.AIPath>().desiredVelocity.x >= 0.01f)
            {
                transform.localScale = new Vector3(-scale, scale, scale);
            }
            else if (GetComponent<Pathfinding.AIPath>().desiredVelocity.x <= -0.01f)
            {
                transform.localScale = new Vector3(scale, scale, scale);
            }

            if (knockbackcount <= 0 )
            {
                GetComponent<Pathfinding.AIPath>().canMove = true;
            }
            else
            {
                GetComponent<Pathfinding.AIPath>().canMove = false;

                rb.velocity = new Vector2(-GetComponent<Pathfinding.AIPath>().velocity.x * 1.5f, -GetComponent<Pathfinding.AIPath>().velocity.x);

                knockbackcount -= Time.deltaTime;
            }
        }
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
