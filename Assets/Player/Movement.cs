using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    Rigidbody2D rb;
    public Transform _groundCheck;
    bool _canJump, _canWalk;
    bool _isWalk, _isJump;
    RaycastHit2D _hit;


    float dir;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, _groundCheck.position);
    }

    void Update()
    {
        dir = CrossPlatformInputManager.GetAxis("Horizontal") * moveSpeed;
        rb.velocity = new Vector2(dir, rb.velocity.y);

        if (CrossPlatformInputManager.GetButtonDown("Jump") && rb.velocity.y<0.001 && rb.velocity.y>-0.001)
        {
            rb.AddForce(Vector2.up * 500f);
        }

        if (_hit = Physics2D.Linecast(new Vector2(_groundCheck.position.x, _groundCheck.position.y + 0.2f), _groundCheck.position))
        {
            if (!_hit.transform.CompareTag("Player"))
            {
                _canJump = true;
                _canWalk = true;
            }
        }
        else _canJump = false;
    }

}
