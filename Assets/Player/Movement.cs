using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Movement : MonoBehaviour
{
    public bool start = false;
    public float moveSpeed = 5f;
    Rigidbody2D rb;
    bool _canJump, _canWalk;
    bool _isWalk, _isJump;
    Animator anim;

    public float fallMult=2.5f;
    public float lowJumpMult = 2f;


    public LayerMask groundLayer;


    float dir;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    bool isGrounded()
    {
        Vector2 position = new Vector2(transform.position.x, transform.position.y - 4.2f);
        Vector2 direction = Vector2.down;
        float distance = 1f;

        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
        if (hit.collider != null)
        {
            return true;
        }
        return false;
    }

    void Update()
    {
        Debug.DrawRay(new Vector2(transform.position.x, transform.position.y - 4.3f), Vector2.down, Color.red);
        
        if (start)
        {
            dir = CrossPlatformInputManager.GetAxis("Horizontal") * moveSpeed;
            rb.velocity = new Vector2(dir, rb.velocity.y);

            Vector2 myScale = transform.localScale;
            bool rotate = false;

            if (CrossPlatformInputManager.GetAxis("Horizontal") < 0 && myScale.x < 0)
            {
                rotate = true;
            }
            else if (CrossPlatformInputManager.GetAxis("Horizontal") > 0 && myScale.x > 0)
            {
                rotate = true;
            }

            if (rotate)
            {
            
                myScale.x = myScale.x * -1;
                transform.localScale = myScale;
            }


            if (CrossPlatformInputManager.GetAxis("Horizontal") == 0)
            {
                anim.SetFloat("speed", 0);
            }

            anim.SetFloat("speed", Mathf.Abs(CrossPlatformInputManager.GetAxis("Horizontal")));

            if (CrossPlatformInputManager.GetButtonDown("Jump") && isGrounded())
            {
                rb.velocity = Vector2.up * 15;
                anim.SetBool("jump", true);
            }
            

            if (rb.velocity.y < 0)
            {
                rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMult - 1) * Time.deltaTime;
                anim.SetBool("land", false) ;
            }
            else if(rb.velocity.y>0 && !CrossPlatformInputManager.GetButton("Jump"))
            {
                
                rb.velocity+= Vector2.up * Physics2D.gravity.y * (lowJumpMult - 1) * Time.deltaTime;
            }
            
            
                anim.SetBool("land", isGrounded());
           
        }
    }

    private void OnCollisionStay2D(Collision2D col)
    {
        if (col.transform.tag == "ground")
        {
            start = true;
            anim.SetBool("jump", false);
        }

    }

}
