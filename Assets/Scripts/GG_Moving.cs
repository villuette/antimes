using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GG_Moving : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    Animator anim;
    public float x;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        transform.position = gameObject.transform.position;
    }

    void FixedUpdate()
    {
        //CheckingLadder();
        Flip();
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);
        if (rb.velocity.x != 0)
            anim.SetInteger("is_running", 1);
        if (rb.velocity.x == 0)
            anim.SetInteger("is_running", 0);
    }

    void Flip()
    {
        if (Input.GetAxis("Horizontal") > 0)
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        if (Input.GetAxis("Horizontal") < 0)
            transform.localRotation = Quaternion.Euler(0, 180, 0);
    }

    public float check_RADIUS = 0.04f;
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(CHECK_ladder.position, check_RADIUS);
    }
    public Transform CHECK_ladder;
    public bool checkedLadder;
    public LayerMask LadderMask;
    //void CheckingLadder()
    //{
       // checkedLadder = Physics2D.OverlapPoint(CHECK_ladder.position, LadderMask);
   // }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger!");
        if (collision.gameObject.tag == "ladder")
        {
            checkedLadder = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ladder")
        {
            checkedLadder = false;
        }
    }
}
