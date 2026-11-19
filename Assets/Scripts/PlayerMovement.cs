using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 5;
    public int facingDirection = 1;
    
    public Rigidbody2D rb;
    public Animator anim;
    
    //Runs x50/s so it is more reliable
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (horizontal > 0 && transform.localScale.x < 0 ||
            horizontal < 0 && transform.localScale.x > 0)
        {
            Flip();
        }
        
        anim.SetFloat("horizontal", Math.Abs(horizontal));
        //anim.SetFloat("vertical", Math.Abs(vertical)); 
        
        rb.linearVelocity = new Vector2(horizontal, 0) * speed;
    }

    void Flip()
    {
        facingDirection *= -1;
        
        transform.localScale = new Vector3(transform.localScale.x *-1, transform.localScale.y, transform.localScale.z);
    }
}
