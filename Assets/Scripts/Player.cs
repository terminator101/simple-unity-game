using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public int movespeed;
    public Transform groundCheck;
    public float groundCheckradius;
    public LayerMask whatIsGround;
    public bool onGround;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movespeed = 2;
    }

    // Update is called once per frame
    void Update()
    {
        //Move the object and keep moving
        //rb.velocity = new Vector2(movespeed, rb.velocity.y);
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-movespeed, rb.velocity.y);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(movespeed, rb.velocity.y);
        }
        if (Input.GetKey(KeyCode.Space) && onGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, 5);
        }
    }

    private void FixedUpdate()
    {
        onGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckradius, whatIsGround);
    }
}
