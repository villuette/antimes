using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingCheck : MonoBehaviour
{
    bool fly = false;
    [SerializeField] private float flyTime = 0.0f;
    public float deadFlyTime = 4f;

    private void FixedUpdate()
    {
        if (fly)
        {
            flyTime += Time.deltaTime;
            if (flyTime >= deadFlyTime)
            {
                //Destroy(GameObject.Find("GG"));
                Debug.Log("Time dead");
            }
        }
        else
        {
            flyTime = 0.0f;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ground"))
        {
            fly = false;
        }
        if(collision.CompareTag("ground") && GG_Moving.rb.velocity.y < -4)
        {
            Stats.GG_Health -= (int)((1 - Stats.GG_Armor) * (GG_Moving.rb.velocity.y * (-20)));
            Debug.Log("GG: " + Stats.GG_Health);
            if (Stats.GG_Health <= 0)
            {
                //Destroy(GameObject.Find("GG"));
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("ground"))
        {
            fly = true;
        }
    }
}
