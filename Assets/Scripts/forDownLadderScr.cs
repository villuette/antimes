using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forDownLadderScr : MonoBehaviour
{
    Collider2D ggcol;
    // Start is called before the first frame update
    
    void Start()
    {
        ggcol = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            ggcol.isTrigger = false;
            GG_Moving.canMove = false;
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
