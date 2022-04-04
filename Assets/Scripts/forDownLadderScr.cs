using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forDownLadderScr : MonoBehaviour
{
    Collider2D ggcol;
    Collider2D thiscol;
    int earnedMoney;
    public int minMoneyEarned, maxMoneyEarned;
    // Start is called before the first frame update

    void Start()
    {
        ggcol = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>();
        thiscol = GetComponent<Collider2D>();
        //thiscol.enabled = false;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            ggcol.isTrigger = false;
            GG_Moving.canMove = false;
            //thiscol.enabled = false;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "wchest" || collision.gameObject.tag == "gchest")
        {
            //scr for money up////
            earnedMoney = UnityEngine.Random.Range(minMoneyEarned, maxMoneyEarned);
            if (collision.gameObject.tag == "gchest")
                earnedMoney *= 10;
            Debug.Log("you earned now " + earnedMoney + " money");
            Stats.GG_CurrGold += earnedMoney;
            collision.gameObject.GetComponent<Animator>().enabled = true;
            collision.enabled = false;

        }
    }
    // Update is called once per frame
    void Update()
    {
    }
}
