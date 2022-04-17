using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rendering : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("ground") || collision.CompareTag("Enemy"))
        collision.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        
    }
    private void OnnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("ground") || collision.CompareTag("Enemy"))
            collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
