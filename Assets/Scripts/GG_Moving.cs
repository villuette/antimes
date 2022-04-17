using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class GG_Moving : MonoBehaviour
{
    public static Rigidbody2D rb;
    public float speed;
    Animator anim;
    float originGravity;
    public float x;
    public static bool canMove;
    public bool upOrDown; // 1 is UP, 0 is DOWN
    public float speedOnLadder;
    public Collider2D ggcol;
    public bool doLaddering = false;
    public static bool CanDoLaddering = true;
    GameObject currLadderPos;
    float walkSpeed = 0;
    void Start()
    {

        ggcol = GetComponent<Collider2D>();        
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        transform.position = gameObject.transform.position;
        canMove = true;
        speedOnLadder = 1;
        originGravity = rb.gravityScale;
        currLadderPos = null;//GameObject.FindGameObjectWithTag("ladder");
    }
    void upDownCheck(GameObject ladder)
    {
        if (ladder.transform.position.y > transform.position.y)
            upOrDown = true;
        else
            upOrDown = false;
    }
    void FixedUpdate()
    {
        if (canMove)
        {
            Flip();
            rb.velocity = new Vector2(walkSpeed, rb.velocity.y);
            if (Math.Abs(rb.velocity.x) > 2e-3)
                anim.SetInteger("is_running", 1);
            if (Math.Abs(rb.velocity.x) < 2e-3)
            {
                anim.SetInteger("is_running", 0);
                //rb.velocity = new Vector2(0, rb.velocity.y);
            }

        }


    }
    private void Update()
    {
        walkSpeed = Input.GetAxis("Horizontal") * speed;

        if (CanDoLaddering)
            if (Input.GetKey(KeyCode.E))
                doLaddering = true;
            else doLaddering = false;
        else canMove = false;
    }
    void Flip()
    {
        if (canMove)
        {
            if (Input.GetAxis("Horizontal") > 0)
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            if (Input.GetAxis("Horizontal") < 0)
                transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground" && !upOrDown && !ggcol.isTrigger)
        {
            canMove = true;
            anim.SetBool("is_laddering", false);
            CanDoLaddering = true;
            if(currLadderPos!=null)
            upDownCheck(currLadderPos);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "ladder")
        {
            currLadderPos = collision.gameObject;
            if (doLaddering)
            {
                CanDoLaddering = false;
                doLaddering = false;
                anim.SetBool("is_laddering", true);
                //canMove = false;
                transform.position = new Vector3(collision.gameObject.transform.position.x, transform.position.y, transform.position.z); //поставить посреди лестницы
                rb.velocity = new Vector2(0, 0);
                if (upOrDown)
                {
                    rb.gravityScale = 0;
                    ggcol.isTrigger = true;
                    rb.velocity = new Vector2(0, speedOnLadder);
                }
                if (!upOrDown)
                {
                    rb.gravityScale = 0;
                    ggcol.isTrigger = true;
                    rb.velocity = new Vector2(0, speedOnLadder * -1);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ladder")
        {
            upDownCheck(collision.gameObject);
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ladder")
        {
            ggcol.isTrigger = false;
            rb.velocity = new Vector2(0, 0);
            rb.gravityScale = originGravity;
            anim.SetBool("is_laddering", false);
            upDownCheck(collision.gameObject);
            CanDoLaddering = true;
            canMove = true;
        }
    }
}
