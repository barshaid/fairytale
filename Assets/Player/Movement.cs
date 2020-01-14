using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    Rigidbody2D rb;
    bool _canJump, _canWalk;
    bool _isWalk, _isJump;
    RaycastHit2D _hit;


    float dir;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        dir = CrossPlatformInputManager.GetAxis("Horizontal") * moveSpeed;
        rb.velocity = new Vector2(dir, rb.velocity.y);

        if (CrossPlatformInputManager.GetAxis("Horizontal") == 0)
        {
            GetComponent<Animator>().SetFloat("speed", 0);
        }

        GetComponent<Animator>().SetFloat("speed", Mathf.Abs(CrossPlatformInputManager.GetAxis("Horizontal")));

        if (CrossPlatformInputManager.GetButtonDown("Jump") && rb.velocity.y<0.001 && rb.velocity.y>-0.001)
        {
            rb.AddForce(Vector2.up * 550f);
        }

    }

}
