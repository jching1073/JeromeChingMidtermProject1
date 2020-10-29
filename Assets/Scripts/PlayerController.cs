using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float jumpForce = 100;
    [SerializeField] private float groundCheckRadius = 0.15f;
    [SerializeField] private Transform groundCheckPos;
    [SerializeField] private LayerMask whatIsGround;

    private Rigidbody2D rbody;
    private bool isGrounded = true;
    private Animator anim;
    private bool isFacingRight = true;
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>(); //call animator on start
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        float horiz = Input.GetAxis("Horizontal");
        isGrounded = GroundCheck();

        //JUmpCode
        if(isGrounded && Input.GetAxis("Jump") > 0)
        {

            rbody.AddForce(new Vector2(0.0f, jumpForce));
            isGrounded = false;
            Debug.Log("Jump");
            
        }
       
       
        rbody.velocity = new Vector2(horiz * speed, rbody.velocity.y);

        if ((isFacingRight && rbody.velocity.x < 0) || (!isFacingRight && rbody.velocity.x > 0))
        {
            Flip();
        }

        if (Input.GetAxisRaw("Vertical") < 0)
        {
            anim.SetBool("isDucking", true);
        }
        else 
        {
            anim.SetBool("isDucking", false);
        }
        //com with animator
        anim.SetFloat("xSpeed", Mathf.Abs( rbody.velocity.x));
        anim.SetFloat("ySpeed", rbody.velocity.y);
        anim.SetBool("isGrounded", isGrounded);
        //anim.SetBool("isDucking", false);
    }

    private bool GroundCheck()
    {
        return Physics2D.OverlapCircle(groundCheckPos.position, groundCheckRadius, whatIsGround);
    }
    private void Flip()
    {
        transform.Rotate(0f, 180f, 0f);
        /*
        Vector3 temp = transform.localScale;
        temp.x  *=  -1;
        transform.localScale = temp;*/

        isFacingRight = !isFacingRight;
    }
}
